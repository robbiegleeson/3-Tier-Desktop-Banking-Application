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
        //Returns dataset for the ViewTransactions grid
        public DataSet ViewTransactions(int accountNumber)
        {
            return transactionDAL.ViewTransactions(accountNumber);
        }
        //records (un)successful transaction
        public bool RecordTransaction(Transaction newTransaction)
        {
            return transactionDAL.RecordTransaction(newTransaction);
        }
        //records (un)successful withdrawl
        public bool RecordTransactionWithdraw(Transaction newTransaction)
        {
            return transactionDAL.RecordTransactionWithdraw(newTransaction);
        }
        //records (un)successful transfer
        public bool RecordTransactionTransfer(Transaction newTransaction)
        {
            return transactionDAL.RecordTransactionTransfer(newTransaction);
        }
        //returns dataset for print transactions form
        public DataSet GetDetailsForViewGrid(int AccountNumber)
        {
            return transactionDAL.GetDetailsForViewGrid(AccountNumber);
        }
    }
}
