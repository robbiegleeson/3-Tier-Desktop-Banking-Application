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
using GridsAndColumns;


namespace OOP2CreditUnion
{
    public partial class Main : Form
    {
        public string CurrentUserUserName { get; set; }

        public Main()
        {
            InitializeComponent();
            pbMain.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrimeGrid();
        }

        //Calling method in the account business logic layer to populate data grid.
        private void PrimeGrid()
        {
            AccountBLLManager accountBll = new AccountBLLManager();
            DataSet ds = accountBll.GetDetailsForMainGrid();
            //Setting the data source for the data grid
            dgvAccounts.DataSource = ds.Tables[0];
        }

        //Method to identify selected field in data grid view which is used to pre-populate contorls within a form.
        private void ViewAccountDetails(int tabIndex)
        {
            DataTable dTable = dgvAccounts.DataSource as DataTable;
            if (dTable != null && dTable.Rows.Count > 0)
            {
                DataGridViewRow dgvRow = dgvAccounts.CurrentRow;
                //If a selection is made
                if (dgvRow != null)
                {
                    int accountNumber = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.AccountNumber)].Value);
                    int customerID = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.CustomerID)].Value);
                    using (ViewAccount frmViewAccount = new ViewAccount(accountNumber, customerID, tabIndex))
                    {
                        //Populate the ViewAccount form with selected values
                        frmViewAccount.ShowDialog();
                    }
                    PrimeGrid();
                }
                else
                    MessageBox.Show("No Selection Made", "ERROR");
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Login frmLogin = new Login())
            {
                //Setting control(s) visability depending on login status and access level.
                frmLogin.ShowDialog();
                if (frmLogin.loginStatus)
                {
                    logoutToolStripMenuItem.Enabled = true;
                    logoutToolStripMenuItem.Visible = true;
                    accountToolStripMenuItem.Enabled = true;
                    accountToolStripMenuItem.Visible = true;
                    loginToolStripMenuItem.Enabled = false;
                    loginToolStripMenuItem.Visible = false;
                   
                    optionsToolStripMenuItem.Enabled = true;
                    optionsToolStripMenuItem.Visible = true;
                    dgvAccounts.Visible = true;
                    grpWelcome.Visible = false;
                    pbMain.Visible = true;

                    if (frmLogin.userLevel)
                    {
                        manageUsersToolStripMenuItem.Enabled = true;
                        manageUsersToolStripMenuItem.Visible = true;
                    }

                    if (frmLogin.userName == "admin")
                    {
                        resetPasswordToolStripMenuItem.Enabled = true;
                        resetPasswordToolStripMenuItem.Visible = true;
                        removeUsersToolStripMenuItem.Enabled = true;
                        removeUsersToolStripMenuItem.Visible = true;
                    }
                    CurrentUserUserName = frmLogin.userName;
                }
                else
                    MessageBox.Show("Login Failed", "ERROR");
            }
        }

        private void newAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (AddAccount frmAddAccount = new AddAccount())
            {
                //Open AddAccount form
                frmAddAccount.ShowDialog();
                this.Hide();
            }
            PrimeGrid();
            this.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to quit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //On logout, reset control(s) visability depending on login status
            if (MessageBox.Show("Are you sure you wish to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logoutToolStripMenuItem.Enabled = false;
                logoutToolStripMenuItem.Visible = false;
                accountToolStripMenuItem.Enabled = false;
                accountToolStripMenuItem.Visible = false;
                manageUsersToolStripMenuItem.Enabled = false;
                manageUsersToolStripMenuItem.Visible = false;
                loginToolStripMenuItem.Enabled = true;
                loginToolStripMenuItem.Visible = true;
                optionsToolStripMenuItem.Enabled = false;
                optionsToolStripMenuItem.Visible = false;
                dgvAccounts.Visible = false;
                pbMain.Visible = false;
            }
            
        }

        private void viewAccountToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewAccountDetails(Convert.ToInt32(ViewTabIndex.AccountDetails));
        }

        private void depositFundsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewAccountDetails(Convert.ToInt32(ViewTabIndex.Deposit));
        }

        //Identify selected row value and open pre-populated form, ViewTransactions
        private void viewTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dTable = dgvAccounts.DataSource as DataTable;
            if (dTable != null && dTable.Rows.Count > 0)
            {
                DataGridViewRow dgvRow = dgvAccounts.CurrentRow;

                if (dgvRow != null)
                {
                    int AccountNumber = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.AccountNumber)].Value);
                    int CustomerID = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.CustomerID)].Value);
                    using (ViewTransaction frmView = new ViewTransaction(AccountNumber))
                    {
                        frmView.ShowDialog();
                    }
                    PrimeGrid();
                }
                else
                {
                    MessageBox.Show("No Selection Made", "ERROR!");
                }
            }
        }

        //Identify selected row value and open pre-populated form, EditAccountDetails
        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dTable = dgvAccounts.DataSource as DataTable;
            if (dTable != null && dTable.Rows.Count > 0)
            {
                DataGridViewRow dgvRow = dgvAccounts.CurrentRow;

                if (dgvRow != null)
                {
                    int AccountNumber = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.AccountNumber)].Value);
                    int CustomerID = Convert.ToInt32(dgvRow.Cells[Convert.ToInt32(MainGridCloumns.CustomerID)].Value);
                    using (EditAccountDetails editAccount = new EditAccountDetails(AccountNumber, CustomerID))
                    {
                        editAccount.ShowDialog();
                    }
                    PrimeGrid();
                }
                else
                    MessageBox.Show("No Selection Made", "ERROR!");
            }
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAccountDetails(Convert.ToInt32(ViewTabIndex.Withdraw));
        }

        private void transferFundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAccountDetails(Convert.ToInt32(ViewTabIndex.Transfer));
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddUser frmAddUser = new AddUser())
            {
                frmAddUser.ShowDialog();
            }
            PrimeGrid();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePassword frmChangePassword = new ChangePassword())
            {
                frmChangePassword.ShowDialog();
            }
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ResetPasswords frmResetPassword = new ResetPasswords(CurrentUserUserName))
            {
                frmResetPassword.ShowDialog();
            }
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ViewUsers frmViewUsers = new ViewUsers())
            {
                frmViewUsers.ShowDialog();
            }
        }

        private void removeUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RemoveUser frmRemoveUser = new RemoveUser())
            {
                frmRemoveUser.ShowDialog();
            }
        }
    }
}
