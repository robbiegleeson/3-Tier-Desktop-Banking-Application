using BLL;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace OOP2CreditUnion
{
    public partial class PrintTransactions : Form
    {
        int AccountNumber { get; set; }
        TransactionBLLManager transactionBLL = new TransactionBLLManager();

        public PrintTransactions(int accountNumber)
        {
            InitializeComponent();
            AccountNumber = accountNumber;
            transactionBLL = new TransactionBLLManager();
            DataSet ds = transactionBLL.GetDetailsForViewGrid(AccountNumber);
            dgvTransactions.DataSource = ds.Tables[0];
            lblAccNum.Text = AccountNumber.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<Transaction> list = new List<Transaction>(dgvTransactions.Rows.Count);

            sfdXml.InitialDirectory = "C:/";
            sfdXml.FileName = AccountNumber.ToString() + " Transactions.xml";
            sfdXml.Filter = "(*.xml)| *.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Transaction));
            XmlWriter xmlWriter;

            if (sfdXml.ShowDialog() == DialogResult.OK)
            {
                xmlWriter = XmlWriter.Create(sfdXml.FileName);

                foreach (Transaction transaction in list)
                {
                    xmlSerializer.Serialize(xmlWriter, transaction);
                }
                xmlWriter.Close();
            }
        }
    }
}
