using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int DestinationAccountNumber { get; set; }
        public int DestinationSortCode { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionReference { get; set; }
        public int AccountNumber { get; set; }
    }
}
