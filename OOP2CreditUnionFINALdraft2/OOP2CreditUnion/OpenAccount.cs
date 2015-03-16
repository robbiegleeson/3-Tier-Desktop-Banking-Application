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

namespace OOP2CreditUnion
{
    public partial class OpenAccount : Form
    {
        AccountBLLManager accountBLL = new AccountBLLManager();

        string CustomerName { get; set; }
        int ID { get; set; }

        Account newAccount = new Account();

        public OpenAccount(string customerName, int customerId)
        {
            InitializeComponent();

            CustomerName = customerName;
            ID = customerId;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (ValidatedFields())
            {
                newAccount.Balance = accountBLL.FormatCurrency(txtInitialBalance.Text);
                newAccount.CustomerID = ID;
                newAccount.OverDraftLimit = accountBLL.FormatCurrency(txtOverdraftLimit.Text);

                if (rdoCurrent.Checked)
                    newAccount.AccountType = "Current Account";
                else
                    newAccount.AccountType = "Savings Account";

                if (accountBLL.OpenNewAccount(newAccount))
                    MessageBox.Show("Account Created Customers Account Number is: " + newAccount.AccountNumber, "SUCCESS!");
                else
                    MessageBox.Show("Error creating account", "ERROR");
                this.Close();
            }
            else
                MessageBox.Show("Please insure all filled are filled out correctly.", "ERROR!");
        }

        public bool ValidatedFields()
        {
            bool validated = true;

            if (!Validation.IsCurrencyFormat(txtInitialBalance.Text))
            {
                validated = false;
                lblValidateBalance.Visible = true;
            }

            if (!Validation.IsCurrencyFormat(txtOverdraftLimit.Text))
            {
                validated = false;
                lblValidateOverDraft.Visible = true;
            }

            if (!rdoCurrent.Checked && !rdoSavings.Checked)
            {
                validated = false;
                lblCheckAccountType.Visible = true;
            }
            else
            {
                validated = true;
                ClearValidationErrors();
            }

            return validated;
        }

        public void ClearValidationErrors()
        {
            lblCheckAccountType.Visible = false;
            lblValidateBalance.Visible = false;
            lblValidateOverDraft.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void OpenAccount_Load(object sender, EventArgs e)
        {
            txtCustomerName.Text = CustomerName;
        }
    }
}
