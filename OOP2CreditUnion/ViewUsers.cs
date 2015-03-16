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
    public partial class ViewUsers : Form
    {
        UserBLLManager userBLL = new UserBLLManager();
        public ViewUsers()
        {
            InitializeComponent();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            //Setting DataGrid data source from BLL GetUserLogs; displays Username, Last Login and Is Admin
            dgvUsers.DataSource = userBLL.GetUserLogs().Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
