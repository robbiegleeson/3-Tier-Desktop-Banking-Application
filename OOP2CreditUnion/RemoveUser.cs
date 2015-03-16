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
    public partial class RemoveUser : Form
    {
        UserBLLManager userBLL = new UserBLLManager();
        public RemoveUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Deleting user
            if (MessageBox.Show("Are you sure you wish to Delete User, This cannnot be undone?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Calling userBLL method userToDelete
                string userToDelete = cboUserNames.SelectedItem.ToString();
                if (userBLL.RemoveUser(userToDelete))
                {
                    MessageBox.Show("User deleted.", "SUCCESS!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error removing record");
            }

        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {
            cboUserNames.DataSource = userBLL.GetUserNames();
        }
    }
}
