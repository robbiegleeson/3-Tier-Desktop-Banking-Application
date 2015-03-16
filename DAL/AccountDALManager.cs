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
    public class AccountDALManager : ConnectionManager
    {
        SqlConnection cxn;
        SqlCommand cmd;
        //The DAL managers contain methods that assign parameters to Procedures Stored
        //in the Database. each method return relevant infromation - dataSets that binds
        //to grids, objects and values to be assigned and used and true/false values so
        //show if information in the DB has been entered/replaced/updated
        public bool CreateAccount(Customer newCustomer, Account newAccount)
        {
            bool userCreated = false, accountCreated = false;

            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spCreateCustomer", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = newCustomer.FirstName;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 50).Value = newCustomer.Surname;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = newCustomer.Email;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = newCustomer.Phone;
                    cmd.Parameters.Add("@AddressLine1", SqlDbType.NVarChar, 50).Value = newCustomer.AddressLine1;
                    cmd.Parameters.Add("@AddressLine2", SqlDbType.NVarChar, 50).Value = newCustomer.AddressLine2;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = newCustomer.City;
                    cmd.Parameters.Add("@County", SqlDbType.NVarChar, 50).Value = newCustomer.County;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@OnlineCustomer", SqlDbType.Bit).Value = newCustomer.OnlineCustomer;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                    {
                        newCustomer.CustomerID = Convert.ToInt32(cmd.Parameters["@CustomerID"].Value);
                        newAccount.CustomerID = newCustomer.CustomerID;
                        userCreated = true;
                    }
                }

                using (cmd = new SqlCommand("spCreateAccount", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountType", SqlDbType.NVarChar, 50).Value = newAccount.AccountType;
                    cmd.Parameters.Add("@SortCode", SqlDbType.Int, 8).Value = newAccount.SortCode;
                    cmd.Parameters.Add("@InitialBalance", SqlDbType.Int, 8).Value = newAccount.Balance;
                    cmd.Parameters.Add("@OverDraft", SqlDbType.Int, 8).Value = newAccount.OverDraftLimit;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = newAccount.CustomerID;
                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int, 8).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                    {
                        newAccount.AccountNumber = Convert.ToInt32(cmd.Parameters["@AccountNumber"].Value);
                        accountCreated = true;
                    }
                }
                if (userCreated && accountCreated)
                    return true;
                else
                    return false;
            }
        }

        public bool OpenNewAccount(Account newAccount)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spCreateAccount", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountType", SqlDbType.NVarChar, 50).Value = newAccount.AccountType;
                    cmd.Parameters.Add("@SortCode", SqlDbType.Int, 8).Value = newAccount.SortCode;
                    cmd.Parameters.Add("@InitialBalance", SqlDbType.Int, 8).Value = newAccount.Balance;
                    cmd.Parameters.Add("@OverDraft", SqlDbType.Int, 8).Value = newAccount.OverDraftLimit;
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = newAccount.CustomerID;
                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int, 8).Direction = ParameterDirection.Output;

                    cxn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (rows > 0)
                    {
                        newAccount.AccountNumber = Convert.ToInt32(cmd.Parameters["@AccountNumber"].Value);
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public Account GetAccountDetails(int accountNum)
        {
            Account currentAcc = null;
            try
            {
                using (cxn = new SqlConnection(this.ConnectionString))
                {
                    using (cmd = new SqlCommand("spGetAccInformation", cxn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = accountNum;
                        cxn.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        currentAcc = new Account();
                        currentAcc.AccountNumber = accountNum;

                        while (dataReader.Read())
                        {
                            currentAcc.AccountType = dataReader["AccountType"].ToString();
                            currentAcc.Balance = Convert.ToInt32(dataReader["Balance"].ToString());
                            currentAcc.OverDraftLimit = int.Parse(dataReader["OverDraftLimit"].ToString());
                        }
                        dataReader.Close();
                        cxn.Close();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return currentAcc;
        }

        public DataSet GetDetailsForMainGrid()
        {
            DataSet dsMainForm = null;
            try
            {
                using (cxn = new SqlConnection(this.ConnectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dsMainForm = new DataSet();
                    using (cmd = new SqlCommand("spGetDetailsForMainGrid", cxn))
                    {

                        dataAdapter.SelectCommand = cmd;

                        cxn.Open();
                        dataAdapter.Fill(dsMainForm);
                        cxn.Close();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return dsMainForm;
        }
        
        public bool UpdateAccountBalance(Account updateAccount)
        {
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUpdateBalance", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = updateAccount.AccountNumber;
                    cmd.Parameters.Add("@Balance", SqlDbType.Int).Value = updateAccount.Balance;

                    cxn.Open();
                    int row = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (row > 0)
                        return true;
                    else
                        return false;
                }
            }

        }

        public bool ExternalTransfer(Account fromAccount, Account toAccount)
        {
            bool transferTo = false;

            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUpdateFromTransfer", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = fromAccount.AccountNumber;
                    cmd.Parameters.Add("@Balance", SqlDbType.Int).Value = fromAccount.Balance;

                    cxn.Open();
                    int row = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (row > 0)
                        transferTo = true;
                    else
                        transferTo = false;
                }
            }
            return transferTo;
        }

        public bool Transfer(Account fromAccount, Account toAccount)
        {
            bool transferTo = false;
            bool transferFrom = false;

            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUpdateFromTransfer", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = fromAccount.AccountNumber;
                    cmd.Parameters.Add("@Balance", SqlDbType.Int).Value = fromAccount.Balance;

                    cxn.Open();
                    int row = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (row > 0)
                        transferTo = true;
                    else
                        transferTo = false;
                }
            }

            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spUpdateToTransfer", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = toAccount.AccountNumber;
                    cmd.Parameters.Add("@Balance", SqlDbType.Int).Value = toAccount.Balance;

                    cxn.Open();
                    int row = cmd.ExecuteNonQuery();
                    cxn.Close();

                    if (row > 0)
                        transferFrom = true;
                    else
                        transferFrom = false;
                }
            }
            return transferTo && transferFrom;
        }

        public Account SearchAccountDetails(int AccountNumber)
        {
            Account account = null;
            using (cxn = new SqlConnection(this.ConnectionString))
            {
                using (cmd = new SqlCommand("spSearch", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountNumber", SqlDbType.Int).Value = AccountNumber;
                    cxn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    account = new Account();
                    account.AccountNumber = AccountNumber;

                    while (dataReader.Read())
                    {
                        account.Balance = Convert.ToInt32(dataReader["Balance"].ToString());
                        account.AccountType = dataReader["AccountType"].ToString();
                    }
                    dataReader.Close();
                    cxn.Close();
                }
                return account;
            }
        }

    }
}
