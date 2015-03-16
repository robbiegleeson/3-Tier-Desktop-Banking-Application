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
using BLL;

namespace OOP2CreditUnion
{
    public partial class AddUser : Form
    {
        UserBLLManager UserBll = new UserBLLManager();

        public AddUser()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            //Passing values into Validation class to validate fields
            if (Validation.IsUserNameFormat(txtUsername.Text) && Validation.IsTextFormat(txtFname.Text) && Validation.IsTextFormat(txtLname.Text))
            {
                newUser.UserName = txtUsername.Text;
                newUser.Password = PasswordProtect.Protect("password1");
                newUser.FullName = txtFname.Text + " " + txtLname.Text;
                newUser.IsAdmin = cbIsAdmin.Checked;

                if (UserBll.AddUser(newUser))
                    MessageBox.Show("User Added.", "SUCCESS!");
                else
                    MessageBox.Show("Error adding record, username exists", "ERROR");
                this.Close(); // Close or just clear fields
            }
            else
                MessageBox.Show("Please ensure all fields are filled out correctly", "ERROR!");
        }
    }
}
