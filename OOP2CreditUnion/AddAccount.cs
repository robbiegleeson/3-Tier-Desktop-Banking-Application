using BLL;
using DataModels;
using GridsAndColumns;
using System;
using System.Windows.Forms;

namespace OOP2CreditUnion
{
    public partial class AddAccount : Form
    {

        private int _AccountID;
        private int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                if (value > 0)
                {
                    _AccountID = value;
                }
            }
        }

        public AddAccount()
        {
            InitializeComponent();
            ClearValidationErrors();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            //bllAccountManager bll = new bllAccountManager();
            AccountBLLManager accountBll = new AccountBLLManager();

            string accType = string.Empty;
            //Hard-code account type
            if (rdoCurrent.Checked)
                accType = "Current Account";
            if (rdoSavings.Checked)
                accType = "Savings Account";

            Customer newCustomer = new Customer();
            //Checking that all fields are validated using ValidateFields bool
            if (ValidateFields())
            {
                newCustomer.FirstName = txtFirstName.Text; //Perform validation here
                newCustomer.Surname = txtSurname.Text;
                newCustomer.Email = txtEmail.Text;
                newCustomer.Phone = txtPhone.Text;
                newCustomer.AddressLine1 = txtAddress1.Text;
                newCustomer.AddressLine2 = txtAddress2.Text;
                newCustomer.City = txtCity.Text;
                newCustomer.County = cboCounties.SelectedValue.ToString();
                newCustomer.OnlineCustomer = false;

                //Instantiate Account class for new account
                Account newAccount = new Account();

                newAccount.AccountType = accType;
                newAccount.Balance = accountBll.FormatCurrency(txtInitialBalance.Text);//FormatCurrency method to covert from ##.## to int
                newAccount.OverDraftLimit = accountBll.FormatCurrency(txtOverdraftLimit.Text);

                if (accountBll.CreateAccount(newCustomer, newAccount))
                {
                    MessageBox.Show("Account created.");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Please ensure all fields are filled out correctly");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        bool ValidateFields()
        //Passing values into Validation class to perform validation of fields
        {
            bool result = true;
            if (!Validation.IsTextFormat(txtFirstName.Text))
            {
                lblValidateFName.Visible = true;
                result = false;
            }
            if (!Validation.IsTextFormat(txtSurname.Text))
            {
                lblValidateSname.Visible = true;
                result = false;
            }
            if (!Validation.IsEmailFormat(txtEmail.Text))
            {
                lblValidateEmail.Visible = true;
                result = false;
            }
            if (!Validation.IsPhoneNumberFormat(txtPhone.Text))
            {
                lblValidatePhone.Visible = true;
                result = false;
            }
            if (!Validation.IsTextFormat(txtAddress1.Text))
            {
                lblValidateAddress1.Visible = true;
                result = false;
            }
            if (!Validation.IsTextFormat(txtAddress2.Text))
            {
                lblValidateAddress2.Visible = true;
                result = false;
            }
            if (!Validation.IsTextFormat(txtAddress1.Text))
            {
                lblValidateAddress1.Visible = true;
                result = false;
            }
            if (!Validation.IsTextFormat(txtCity.Text))
            {
                lblValidateCity.Visible = true;
                result = false;
            }
            if (!Validation.IsCurrencyFormat(txtInitialBalance.Text))
            {
                lblValidateBalance.Visible = true;
                result = false;
            }
            if (!Validation.IsCurrencyFormat(txtOverdraftLimit.Text))
            {
                lblValidateOverDraft.Visible = true;
                result = false;
            }
            if (!rdoCurrent.Checked && !rdoSavings.Checked)
            {
                lblCheckAccountType.Visible = true;
                result = false;
            }

            if (!result)
                return result;
            else
            {
                ClearValidationErrors();
                return true;
            }
        }

        //hide the error pointers
        void ClearValidationErrors()
        {
            lblValidateFName.Visible = false;
            lblValidateSname.Visible = false;
            lblValidateEmail.Visible = false;
            lblValidatePhone.Visible = false;
            lblValidateAddress1.Visible = false;
            lblValidateAddress2.Visible = false;
            lblValidateCity.Visible = false;
            lblValidateBalance.Visible = false;
            lblValidateOverDraft.Visible = false;
            lblCheckAccountType.Visible = false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            //Loading combo-box with values from Enum
            cboCounties.DataSource = Enum.GetValues(typeof(Counties));
        }

        private void rdoSavings_CheckedChanged(object sender, EventArgs e)
        {
            txtOverdraftLimit.Enabled = false;
            txtOverdraftLimit.Text = "0.00";
        }

        private void rdoCurrent_CheckedChanged(object sender, EventArgs e)
        {
            txtOverdraftLimit.Enabled = true;
        }

    }
}
