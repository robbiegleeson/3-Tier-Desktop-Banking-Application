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

        //sortcode is assigned through account constructor, pulled from app.config
        public Account()
        {
            string sortcode = ConfigurationManager.AppSettings["DBSCUsortcode"];
            SortCode = int.Parse(sortcode);
        }

        //DisplayBalance and DisplayODLimit change the amounts from the DB (int) and
        // coverts it's into a display friendly format
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
