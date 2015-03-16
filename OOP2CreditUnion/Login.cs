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
    public partial class Login : Form
    {
        UserBLLManager userMngr = new UserBLLManager();

        public bool loginStatus;
        public bool userLevel;
        public string userName;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User cUser = new User();
            loginStatus = UserLogin(cUser);
            userLevel = cUser.IsAdmin;
            userName = txtUsername.Text;
            this.Close();
        }

        bool UserLogin(User currentUser)
        {
            if (!Validation.IsTextFormat(txtUsername.Text))
            {
                MessageBox.Show("Please Enter a UserName", "ERROR!");
                return false;
            }
            else if (!Validation.IsPasswordFormat(txtPassword.Text))
            {
                MessageBox.Show("Invalid Password!", "ERROR!");
                return false;
            }
            else
            {
                currentUser.UserName = txtUsername.Text;
                currentUser.Password = PasswordProtect.Protect(txtPassword.Text);
                return userMngr.UserLogin(currentUser);
            }
        }
    }
    
}
