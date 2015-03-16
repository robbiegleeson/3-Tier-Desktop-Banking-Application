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
    public partial class ResetPasswords : Form
    {
        UserBLLManager userBLL = new UserBLLManager();
        string SessionUser;

        public ResetPasswords(string sessionUser)
        {
            InitializeComponent();
            SessionUser = sessionUser;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset user password
            if (MessageBox.Show("Are you sure you want to reset " + cboUserNames.SelectedItem.ToString() +"'s password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (userBLL.ResetPassword(SessionUser, cboUserNames.SelectedItem.ToString()))
                    MessageBox.Show("Password Reset", "SUCCESS!");
                else
                    MessageBox.Show("Error in Database", "ERROR!");
            }
        }

        private void ResetPasswords_Load(object sender, EventArgs e)
        {
            //Populating combo-box with List of usernames by calling GetUserNames in the BLL.
            List<string> userNames = userBLL.GetUserNames();
            cboUserNames.DataSource = userNames;
        }
    }
}
