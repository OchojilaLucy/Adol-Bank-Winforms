using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class TransferForm : Form
    {
        Customer customer;
        TransactionService transactionService = new TransactionService();
        public TransferForm()
        {
            InitializeComponent();
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            FileStorage.LoadAccounts();
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to transfer.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            customer = UserSession.LoggedInCustomer;
        }

        public Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            

            return DataStore.accounts
                .FirstOrDefault(account => account.AccountNumber == accountNumber);
        }
        
        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sourceNo = textBox1.Text.Trim();
                string beneficiaryNo = textBox2.Text.Trim();
                if (string.IsNullOrWhiteSpace(sourceNo) || string.IsNullOrWhiteSpace(beneficiaryNo))
                {
                    MessageBox.Show("Please enter both source and beneficiary account numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textBox2.Text.Trim(), out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Invalid deposit amount. Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Account sourceAccount = FindAccountByNumber(customer, sourceNo);
                Account destinationAccount = FindAccountByNumber(customer, beneficiaryNo);

                if (sourceAccount == null || destinationAccount == null)
                {
                    MessageBox.Show("One or both account numbers are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               

                if (amount > sourceAccount.Balance)
                {
                    MessageBox.Show("Insufficient Funds!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (sourceAccount.AccountType == AccountType.Savings && (sourceAccount.Balance - amount) < sourceAccount.MinBalance)
                {
                    MessageBox.Show("Insufficient Funds: You must maintain the minimum balance for a savings account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;

                var sDescription = $"Transfer to {customer.FullName}";
                var dDescription = $"Transfer by {customer.FullName}";

                transactionService.CreateTransaction(sDescription, amount, sourceNo);
                transactionService.CreateTransaction(dDescription, amount, beneficiaryNo);

                await FileStorage.SaveAccountsAsync(DataStore.accounts);


                MessageBox.Show("Transfer successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       
        
        
    }
}
