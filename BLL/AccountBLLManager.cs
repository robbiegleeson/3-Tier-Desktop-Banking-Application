using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataModels;
using System.Data;
using System.IO;

namespace BLL
{
    public class AccountBLLManager
    {
        AccountDALManager accountDAL = new AccountDALManager();
        //Creates a customer and account linked to them
        public bool CreateAccount(Customer newCustomer, Account newAccount)
        {
            return accountDAL.CreateAccount(newCustomer, newAccount);
        }
        //Creates account based on passed in customer ID (from OpenAccount Form)
        public bool OpenNewAccount(Account newAccount)
        {
            return accountDAL.OpenNewAccount(newAccount);
        }
        //returns informatin on an account
        public Account GetAccountDetails(int accountNum)
        {
            return accountDAL.GetAccountDetails(accountNum);
        }
        //pulls all info of accounts for the main datagrid on Main Form
        public DataSet GetDetailsForMainGrid()
        {
            return accountDAL.GetDetailsForMainGrid();
        }
        //returns (un)successful account update
        public bool UpdateAccountBalance(Account updateBalance)
        {
            return accountDAL.UpdateAccountBalance(updateBalance);
        }
        //Returns (un)successful Transfer 
        public bool ExternalTransfer(Account fromAccount, Account toAccount)
        {
            return accountDAL.ExternalTransfer(fromAccount, toAccount);
        }
        //Returns (un)successful internal Transfer 
        public bool Transfer(Account fromAccount, Account toAccount)
        {
            return accountDAL.Transfer(fromAccount, toAccount);
        }
        //returns an account (if found) to be tranfered into
        public Account SearchAccountDetails(int AccountNumber)
        {
            return accountDAL.SearchAccountDetails(AccountNumber);
        }
        //will check if an account has sufficient funds or if there is enough in
        //the overdraft to accomadate the transfer
        public bool HasSufficientFunds(int oldBalance, int amount, int overDraft)
        {
            if (overDraft == 0)
            {
                if ((oldBalance - amount) >= 0)
                    return true;
                else
                    return false;
            }
            else
            {
                int newBalance = oldBalance - amount;
                if ((overDraft - newBalance) >= 0)
                    return true;
                else
                    return false;
            }
        }
        //coverts displayed curreny (#.##) to database (int) format
        public int FormatCurrency(string input)
        {
            double balance = double.Parse(input);
            int formattedBalance = Convert.ToInt32(balance * 100);
            return formattedBalance;
        }
        //charges balance from account
        public bool TransferFrom(int accountBalance, int amount, out int result)
        {
            if (accountBalance - amount >= 0)
            {
                result = accountBalance - amount;
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }
        //Adds transfer amount into destination account
        public int TransferTo(int accountBalance, int amount)
        {
            return accountBalance + amount;
        }
        //ands amount to destination account balance
        public int MakeDeposit(int balance, int deposit)
        {
            return balance + deposit;
        }
    }
}
