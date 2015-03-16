using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModels;
using BLL;
using GridsAndColumns;

namespace OOP2CreditUnion
{
    public partial class ViewTransaction : Form
    {
        int AccountNumber { get; set; }
        TransactionBLLManager transactionBLL = new TransactionBLLManager();

        
        public ViewTransaction(int accountNumber)
        {
            InitializeComponent();
            AccountNumber = accountNumber;
            //Pre-populating label to display account number
            lblAccount.Text += string.Format(" {0}", accountNumber);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            //Setting the data source of the data grid to displaya transactions
            transactionBLL = new TransactionBLLManager();
            DataSet ds = transactionBLL.GetDetailsForViewGrid(AccountNumber);
            dgvDisplay.DataSource = ds.Tables[0];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (PrintTransactions printView = new PrintTransactions(AccountNumber))
            {
                printView.ShowDialog();
            }
        }
    }
}
