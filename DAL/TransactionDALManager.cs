using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataModels;

namespace DAL
{
    public class TransactionDALManager : ConnectionManager
    {
        SqlConnection cxn;
        SqlCommand cmd;

        public DataSet ViewTransactions(int accountNumber)
        {
            DataSet dsTransactions = null;
            try
            {
                using (cxn = new SqlConnection(this.ConnectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dsTransactions = new DataSet();

                    using (cmd = new SqlCommand("spViewTransactions", cxn))
                    {
                        cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = accountNumber;

                        dataAdapter.SelectCommand = cmd;

                        cxn.Open();
                        dataAdapter.Fill(dsTransactions);
                        cxn.Close();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return dsTransactions;
        }
        
        

        public bool RecordTransaction(Transaction newTransaction)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spTransactionRecord", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransactionType", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionType;
                    cmd.Parameters.Add("@TransactionAmount", SqlDbType.Int).Value = newTransaction.Amount;
                    cmd.Parameters.Add("@TransactionDateTime", SqlDbType.DateTime).Value = newTransaction.TransactionDate;
                    cmd.Parameters.Add("@TransactionReference", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionReference;
                    cmd.Parameters.Add("@TransactionAccountNumber", SqlDbType.Int).Value = newTransaction.AccountNumber;
                    cmd.Parameters.Add("@DestinationAccountNumber", SqlDbType.Int).Value = newTransaction.DestinationAccountNumber;
                    cmd.Parameters.Add("@TransactionDescription", SqlDbType.NVarChar, 100).Value = newTransaction.TransactionDescription;
                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool RecordTransactionWithdraw(Transaction newTransaction)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spTransactionRecord", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransactionType", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionType;
                    cmd.Parameters.Add("@TransactionAmount", SqlDbType.Int).Value = newTransaction.Amount;
                    cmd.Parameters.Add("@TransactionDateTime", SqlDbType.DateTime).Value = newTransaction.TransactionDate;
                    cmd.Parameters.Add("@TransactionReference", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionReference;
                    cmd.Parameters.Add("@TransactionAccountNumber", SqlDbType.Int).Value = newTransaction.AccountNumber;
                    cmd.Parameters.Add("@DestinationAccountNumber", SqlDbType.Int).Value = newTransaction.DestinationAccountNumber;
                    cmd.Parameters.Add("@TransactionDescription", SqlDbType.NVarChar, 100).Value = newTransaction.TransactionDescription;
                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool RecordTransactionTransfer(Transaction newTransaction)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spTransactionRecord", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TransactionType", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionType;
                    cmd.Parameters.Add("@TransactionAmount", SqlDbType.Int).Value = newTransaction.Amount;
                    cmd.Parameters.Add("@TransactionDateTime", SqlDbType.DateTime).Value = newTransaction.TransactionDate;
                    cmd.Parameters.Add("@TransactionReference", SqlDbType.NVarChar, 50).Value = newTransaction.TransactionReference;
                    cmd.Parameters.Add("@TransactionAccountNumber", SqlDbType.Int).Value = newTransaction.AccountNumber;
                    cmd.Parameters.Add("@DestinationAccountNumber", SqlDbType.Int).Value = newTransaction.DestinationAccountNumber;
                    cmd.Parameters.Add("@TransactionDescription", SqlDbType.NVarChar, 100).Value = newTransaction.TransactionDescription;
                    cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            } //bool wil always return true here need int row and 
        }

        public DataSet GetDetailsForViewGrid(int AccountNumber)
        {
            DataSet dsTransactions = null;
            try
            {
                using (cxn = new SqlConnection(this.ConnectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dsTransactions = new DataSet();

                    using (cmd = new SqlCommand("spViewTransactions", cxn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TransactionAccountNumber", SqlDbType.Int).Value = AccountNumber;

                        dataAdapter.SelectCommand = cmd;

                        cxn.Open();
                        dataAdapter.Fill(dsTransactions);
                        cxn.Close();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return dsTransactions;
        }
    }
}
