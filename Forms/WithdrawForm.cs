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
    public partial class WithdrawForm : Form
    {
        Customer customer;
        TransactionService transactionService =  new TransactionService();

        public WithdrawForm()
        {
            InitializeComponent();
        }

        private void WithdrawForm_Load(object sender, EventArgs e)
        {
            FileStorage.LoadAccounts();
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to make a withdrawal.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            customer = UserSession.LoggedInCustomer;
        }
        private Account FindAccountByNumber(Customer customer, string accountNumber)
        {

            return DataStore.accounts
                .FirstOrDefault(account => account.AccountNumber == accountNumber );
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
             
                string accountNumber = textBox1.Text.Trim();

                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    MessageBox.Show("Please enter an account number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textBox2.Text.Trim(), out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Invalid deposit amount. Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Account account = FindAccountByNumber(customer, accountNumber);

                if (account == null)
                {
                    MessageBox.Show("Account not found.");
                }

                
                if (amount > account.Balance)
                {
                    MessageBox.Show("Insufficient Funds!");

                }

                if (account.AccountType == AccountType.Savings)
                {
                    if (account.Balance - amount < account.MinBalance)
                    {
                        MessageBox.Show("Insufficient Funds. Minimum balance for savings account is 1000");

                    }
                   
                }
                account.Balance -= amount;
                var description = $"Withdrawal by {customer.FullName}";

                transactionService.CreateTransaction(description, amount, accountNumber);

                await FileStorage.SaveAccountsAsync(DataStore.accounts);


                MessageBox.Show("Withdrawal successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        
    }
}
