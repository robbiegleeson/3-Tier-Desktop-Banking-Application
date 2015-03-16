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

        public bool CreateAccount(Customer newCustomer, Account newAccount)
        {
            return accountDAL.CreateAccount(newCustomer, newAccount);
        }

        public bool OpenNewAccount(Account newAccount)
        {
            return accountDAL.OpenNewAccount(newAccount);
        }

        public Account GetAccountDetails(int accountNum)
        {
            return accountDAL.GetAccountDetails(accountNum);
        }

        public DataSet GetDetailsForMainGrid()
        {
            return accountDAL.GetDetailsForMainGrid();
        }

        public bool UpdateAccountBalance(Account updateBalance)
        {
            return accountDAL.UpdateAccountBalance(updateBalance);
        }

        public bool ExternalTransfer(Account fromAccount, Account toAccount)
        {
            return accountDAL.ExternalTransfer(fromAccount, toAccount);
        }

        public bool Transfer(Account fromAccount, Account toAccount)
        {
            return accountDAL.Transfer(fromAccount, toAccount);
        }

        public Account SearchAccountDetails(int AccountNumber)
        {
            return accountDAL.SearchAccountDetails(AccountNumber);
        }

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

        public int FormatCurrency(string input)
        {
            double balance = double.Parse(input);
            int formattedBalance = Convert.ToInt32(balance * 100);
            return formattedBalance;
        }

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

        public int TransferTo(int accountBalance, int amount)
        {
            return accountBalance + amount;
        }

        public int MakeDeposit(int balance, int deposit)
        {
            return balance + deposit;
        }
    }
}
