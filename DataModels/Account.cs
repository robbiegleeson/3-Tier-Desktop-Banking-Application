using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataModels
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public int OverDraftLimit { get; set; }
        public int CustomerID { get; set; }
        public int SortCode { get; set; }

        public Account()
        {
            string sortcode = ConfigurationManager.AppSettings["DBSCUsortcode"];
            SortCode = int.Parse(sortcode);
        }

        public string DisplayBalance
        {
            get
            {
                double moneyFormat = Convert.ToDouble(Balance);
                return string.Format("{0:##.00}", moneyFormat / 100);
            }
        }

        public string DisplayODLimit
        {
            get
            {
                double moneyFormat = Convert.ToDouble(OverDraftLimit);
                return string.Format("{0:##.00}", moneyFormat / 100);
            }
        }
    }
}
