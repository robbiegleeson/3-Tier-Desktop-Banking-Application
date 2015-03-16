using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DAL;
using System.Data;

namespace BLL
{
    public class TransactionBLLManager
    {
        TransactionDALManager transactionDAL = new TransactionDALManager();

        public DataSet ViewTransactions(int accountNumber)
        {
            return transactionDAL.ViewTransactions(accountNumber);
        }

        public bool RecordTransaction(Transaction newTransaction)
        {
            return transactionDAL.RecordTransaction(newTransaction);
        }

        public bool RecordTransactionWithdraw(Transaction newTransaction)
        {
            return transactionDAL.RecordTransactionWithdraw(newTransaction);
        }

        public bool RecordTransactionTransfer(Transaction newTransaction)
        {
            return transactionDAL.RecordTransactionTransfer(newTransaction);
        }

        public DataSet GetDetailsForViewGrid(int AccountNumber)
        {
            return transactionDAL.GetDetailsForViewGrid(AccountNumber);
        }
    }
}
