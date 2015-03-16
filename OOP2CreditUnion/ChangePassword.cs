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
using DataModels;

namespace OOP2CreditUnion
{
    public partial class ChangePassword : Form
    {
        UserBLLManager userBLL = new UserBLLManager();

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            UpdatePassword();
            this.Close();
        }

        public void UpdatePassword()
        {
            //Validating updated password. If Validated, success. Else error will be displayed
            if (Validation.IsPasswordFormat(txtOldPassword.Text) && Validation.IsPasswordFormat(txtNewPassword.Text) && Validation.IsPasswordFormat(txtConfirm.Text))
            {
                if (txtNewPassword.Text != txtConfirm.Text)
                    MessageBox.Show("Passwords do not match", "ERROR");
                else
                {
                    if (userBLL.ChangePassword(PasswordProtect.Protect(txtOldPassword.Text), PasswordProtect.Protect(txtNewPassword.Text)))
                        MessageBox.Show("Password Changed", "SUCCESS");
                    else
                        MessageBox.Show("Invalid Password", "ERROR");
                }
            }
                //Propmt correct format for validation
            else
                MessageBox.Show("Please use password format 4 characters and at least 1 number", "ERROR");
        }
    }
}
