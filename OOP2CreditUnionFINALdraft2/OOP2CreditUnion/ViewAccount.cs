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
using DataModels;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OOP2CreditUnion
{
    public partial class ViewAccount : Form
    {
        AccountBLLManager accountBLL = new AccountBLLManager();
        CustomerBLLManager customerBLL = new CustomerBLLManager();
        TransactionBLLManager transactionBLL = new TransactionBLLManager();
        Account currentAccount;
        Customer currentCustomer;

        private int AccountNumber { get; set; }
        private int CustomerID { get; set; }
        int selectTabIndex;

        public ViewAccount(int accountNumber, int customerID, int tabIndex)
        {
            InitializeComponent();
            AccountNumber = accountNumber;
            CustomerID = customerID;
            selectTabIndex = tabIndex;
        }

        private void ViewAccount_Load(object sender, EventArgs e)
        {
            SelectDepositFundsTab();

            if (AccountNumber > 0 && CustomerID > 0)
            {
                currentAccount = accountBLL.GetAccountDetails(AccountNumber);
                currentCustomer = customerBLL.GetCustomerDetails(CustomerID);

                if (currentAccount != null && currentCustomer != null)
                {
                    //--Account Info--
                    txtAccountNumber.Text = currentAccount.AccountNumber.ToString();
                    txtAccountType.Text = currentAccount.AccountType;
                    txtOverdraftLimit.Text = currentAccount.DisplayODLimit;
                    txtInitialBalance.Text = currentAccount.DisplayBalance;

                    txtViewAccountNumber.Text = currentAccount.AccountNumber.ToString();

                    txtAccountNumber.Text = currentAccount.AccountNumber.ToString();

                    txtWithdrawAccountNumber.Text = currentAccount.AccountNumber.ToString();
                    txtWithdrawBalance.Text = currentAccount.DisplayBalance;

                    txtFromAccountNumber.Text = currentAccount.AccountNumber.ToString();
                    txtFromBalance.Text = currentAccount.DisplayBalance;

                    //--Customer Info--
                    txtFirstName.Text = currentCustomer.FirstName;
                    txtSurname.Text = currentCustomer.Surname;
                    txtEmail.Text = currentCustomer.Email;
                    txtPhone.Text = currentCustomer.Phone;
                    txtAddress1.Text = currentCustomer.AddressLine1;
                    txtAddress2.Text = currentCustomer.AddressLine2;
                    txtCity.Text = currentCustomer.City;
                    txtCounty.Text = currentCustomer.County;
                    txtCurrentBalance.Text = txtInitialBalance.Text;
                }
                else
                    MessageBox.Show("Error returning record, check account number.");

            }
            else
                this.Close();
        }

        private void btnDeposit_Click_1(object sender, EventArgs e)
        {
            AccountBLLManager accountBLL = new AccountBLLManager();
            Account updateBalance = new Account();

            int oldBalance, deposit;

            if (Validation.IsCurrencyFormat(txtAmountToDeposit.Text))
            {
                oldBalance = accountBLL.FormatCurrency(txtFromBalance.Text);
                deposit = accountBLL.FormatCurrency(txtAmountToDeposit.Text);
                updateBalance.Balance = accountBLL.MakeDeposit(oldBalance, deposit);

                updateBalance.AccountNumber = int.Parse(txtFromAccountNumber.Text);
                

                try
                {
                    if (accountBLL.UpdateAccountBalance(updateBalance))
                    {
                        try
                        {

                            Transaction newTransaction = new Transaction();
                            TransactionBLLManager transactionBLL = new TransactionBLLManager();

                            newTransaction.TransactionType = txtTransactionType.Text;
                            newTransaction.Amount = accountBLL.FormatCurrency(txtAmountToDeposit.Text);
                            newTransaction.TransactionDate = DateTime.Now;
                            newTransaction.TransactionReference = txtReference.Text;
                            newTransaction.AccountNumber = int.Parse(txtAccountNumber.Text);
                            newTransaction.TransactionDescription = txtDescription.Text;

                            if(transactionBLL.RecordTransaction(newTransaction))
                                MessageBox.Show("Deposit Success", "SUCCESS!");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("Deposit Failure", "ERROR!");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                MessageBox.Show("Please enter currency format: 0.00");
        }

        public void SelectDepositFundsTab()
        {
            tabControl1.SelectTab(selectTabIndex);
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to go back?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            AccountBLLManager accountBLL = new AccountBLLManager();
            Account updateBalance = new Account();

            int oldBalance, withdraw, newBalance;

            if(Validation.IsCurrencyFormat(txtAmountToWithdraw.Text))
            {
                oldBalance = accountBLL.FormatCurrency(txtFromBalance.Text);
                withdraw = accountBLL.FormatCurrency(txtAmountToWithdraw.Text);

                if (accountBLL.HasSufficientFunds(oldBalance, withdraw, Convert.ToInt32(accountBLL.FormatCurrency(txtOverdraftLimit.Text))))
                {
                    newBalance = oldBalance - withdraw;
                    updateBalance.AccountNumber = int.Parse(txtFromAccountNumber.Text);
                    updateBalance.Balance = newBalance;

                    if (accountBLL.UpdateAccountBalance(updateBalance))
                    {
                        try
                        {

                            Transaction newTransaction = new Transaction();
                            TransactionBLLManager transactionBLL = new TransactionBLLManager();

                            newTransaction.TransactionType = txtWithdrawTransactionType.Text;
                            newTransaction.Amount = accountBLL.FormatCurrency(txtAmountToWithdraw.Text);
                            newTransaction.TransactionDate = DateTime.Now;
                            newTransaction.TransactionReference = txtWithdrawReference.Text;
                            newTransaction.AccountNumber = int.Parse(txtWithdrawAccountNumber.Text);
                            newTransaction.TransactionDescription = txtWithdrawDescription.Text;

                            if (transactionBLL.RecordTransactionWithdraw(newTransaction))
                                MessageBox.Show("Withdrawl Success", "SUCCESS!");
                            else
                                MessageBox.Show("Error In Withdrawl", "ERROR!");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("Error in withdrawl", "ERROR!");
                }
                else
                    MessageBox.Show("Insufficient Funds", "ERROR!");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            AccountBLLManager accountBLL = new AccountBLLManager();
            Account fromAccount = new Account();
            Account toAccount = new Account();

            fromAccount.AccountNumber = int.Parse(txtFromAccountNumber.Text);
            toAccount.AccountNumber = int.Parse(txtToAccountNumber.Text);

            int amount = accountBLL.FormatCurrency(txtAmountToTransfer.Text);
            int updateSourceAccBalance;

            if (Validation.IsCurrencyFormat(txtFromBalance.Text) && Validation.IsCurrencyFormat(txtAmountToTransfer.Text))
            {
                //Trying to push logic out to the BLL
                if (accountBLL.TransferFrom(accountBLL.FormatCurrency(txtFromBalance.Text), amount, out updateSourceAccBalance))
                {
                    toAccount.Balance = accountBLL.TransferTo(accountBLL.FormatCurrency(txtToBalance.Text), amount);
                    fromAccount.Balance = updateSourceAccBalance;

                    try
                    {
                        if (accountBLL.Transfer(fromAccount, toAccount))
                        {
                            try
                            {
                                Transaction newTransaction = new Transaction();
                                TransactionBLLManager transactionBLL = new TransactionBLLManager();

                                newTransaction.TransactionType = txtTransferTransactionType.Text;
                                newTransaction.Amount = accountBLL.FormatCurrency(txtAmountToTransfer.Text);
                                newTransaction.TransactionDate = DateTime.Now;
                                newTransaction.TransactionReference = txtTransferReference.Text;
                                newTransaction.AccountNumber = int.Parse(txtFromAccountNumber.Text);
                                newTransaction.DestinationAccountNumber = int.Parse(txtToAccountNumber.Text);
                                newTransaction.TransactionDescription = txtTransferDescription.Text;

                                if (transactionBLL.RecordTransactionTransfer(newTransaction))
                                    MessageBox.Show("Transfer Success", "SUCCESS!");
                                else
                                    MessageBox.Show("Error in DB, contact Admin", "ERROR!");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            this.Close();
                        }
                        else
                            MessageBox.Show("Error in transfer", "ERROR!");

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    MessageBox.Show("Insufficient Funds", "ERROR!");
            }
            else
                MessageBox.Show("Please enter currency in 0.00 format");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validation.IsNumberFormat(txtSearchAccount.Text))
            {
                int searchAccountNumber = int.Parse(txtSearchAccount.Text);

                Account queriedAccount = new Account();
                queriedAccount = accountBLL.SearchAccountDetails(searchAccountNumber);

                if (queriedAccount.AccountType != null)
                {
                    txtToAccountNumber.Text = queriedAccount.AccountNumber.ToString();
                    txtToBalance.Text = queriedAccount.DisplayBalance;
                }
                else
                    MessageBox.Show("No Account Found.", "ERROR!");
            }
            else
                MessageBox.Show("Please Enter a valid Account Number.", "ERROR!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtCancelDeposit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnWithdrawCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            using (EditAccountDetails frmEdit = new EditAccountDetails(currentAccount.AccountNumber, currentCustomer.CustomerID))
            {
                frmEdit.ShowDialog();
                if (frmEdit.UpdateCustomer != null)
                {
                    txtFirstName.Text = frmEdit.UpdateCustomer.FirstName;
                    txtSurname.Text = frmEdit.UpdateCustomer.Surname;
                    txtEmail.Text = frmEdit.UpdateCustomer.Email;
                    txtPhone.Text = frmEdit.UpdateCustomer.Phone;
                    txtAddress1.Text = frmEdit.UpdateCustomer.AddressLine1;
                    txtAddress2.Text = frmEdit.UpdateCustomer.AddressLine2;
                    txtCounty.Text = frmEdit.UpdateCustomer.County;
                    txtCity.Text = frmEdit.UpdateCustomer.City; 
                }
            }
        }

        private void btnOpenAccount_Click(object sender, EventArgs e)
        {
            using (OpenAccount frmOpenAccount = new OpenAccount(txtFirstName.Text + " " + txtSurname.Text, currentCustomer.CustomerID))
            {
                frmOpenAccount.ShowDialog();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            sfdXML.InitialDirectory = @"c:\";
            sfdXML.FileName = "account_" + currentAccount.AccountNumber + ".xml";
            sfdXML.Filter = "(*.xml)|*.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Account));
            XmlWriter xmlWriter;

            if (sfdXML.ShowDialog() == DialogResult.OK)
            {
                xmlWriter = XmlWriter.Create(sfdXML.FileName);
                xmlSerializer.Serialize(xmlWriter, currentAccount);
                xmlWriter.Close();
            }
        }

    }
}
