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

namespace OOP2CreditUnion
{
    public partial class EditAccountDetails : Form
    {
        AccountBLLManager accountBLL = new AccountBLLManager();
        CustomerBLLManager customerBLL = new CustomerBLLManager();

        Account currentAccount;
        Customer currentCust;

        public Customer UpdateCustomer { get; set; }
        private int AccountNumber { get; set; }
        private int CustomerID { get; set; }

        public EditAccountDetails(int accountNumber, int customerID)
        {
            InitializeComponent();
            AccountNumber = accountNumber;
            CustomerID = customerID;
        }

        private void EditAccountDetails_Load(object sender, EventArgs e)
        {
            if (AccountNumber > 0)
            {
                currentAccount = accountBLL.GetAccountDetails(AccountNumber);
                currentCust = customerBLL.GetCustomerDetails(CustomerID);

                if (currentAccount != null && currentCust != null)
                {
                    txtFirstName.Text = currentCust.FirstName;
                    txtSurname.Text = currentCust.Surname;
                    txtEmail.Text = currentCust.Email;
                    txtPhone.Text = currentCust.Phone;
                    txtAddress1.Text = currentCust.AddressLine1;
                    txtAddress2.Text = currentCust.AddressLine2;
                    txtCity.Text = currentCust.City;
                    txtCounty.Text = currentCust.County;
                    txtCustomerID.Text = currentCust.CustomerID.ToString();
                }
                   else
                    MessageBox.Show("Error returning record, check account number.", "ERROR!");
            }
            else
                this.Close();
                
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            accountBLL = new AccountBLLManager();

            UpdateCustomer = new Customer();
            if (ValidateFields())
            {
                UpdateCustomer.FirstName = txtFirstName.Text;
                UpdateCustomer.Surname = txtSurname.Text;
                UpdateCustomer.Email = txtEmail.Text;
                UpdateCustomer.Phone = txtPhone.Text;
                UpdateCustomer.AddressLine1 = txtAddress1.Text;
                UpdateCustomer.AddressLine2 = txtAddress2.Text;
                UpdateCustomer.City = txtCity.Text;
                UpdateCustomer.County = txtCounty.Text;
                UpdateCustomer.CustomerID = int.Parse(txtCustomerID.Text);

                if (customerBLL.UpdateCustomer(UpdateCustomer))
                {
                    MessageBox.Show("Account Updated", "Success");
                    this.Close();
                }
            }
            else
                MessageBox.Show("please ensure all fields are filled out correctly", "Error");
        }

        bool ValidateFields()
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
            if (!Validation.IsTextFormat(txtCounty.Text))
            {
                lblValidateCounty.Visible = true;
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
            lblValidateCounty.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    
}
