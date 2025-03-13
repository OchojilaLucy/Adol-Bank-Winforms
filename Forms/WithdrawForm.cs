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
        Customer customer = Authenticate.customer;
        TransactionService transactionService =  new TransactionService();

        public WithdrawForm()
        {
            InitializeComponent();
        }
        private Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            FileStorage.LoadAccounts();
            return DataStore.accounts.Find(account => account.AccountNumber == accountNumber);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal minBalance = 1000;

                string accountNumber = textBox1.Text;

                
                Account account = FindAccountByNumber(customer, accountNumber);
                if (account == null)
                {
                    MessageBox.Show("Account not found.");
                }

                if (!decimal.TryParse(textBox2.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Invalid amount");
                }
                if (amount > account.Balance)
                {
                    MessageBox.Show("Insufficient Funds!");

                }

                if (account.AccountType == AccountType.Savings)
                {
                    if (account.Balance - amount < minBalance)
                    {
                        MessageBox.Show("Insufficient Funds. Minimum balance for savings account is 1000");

                    }
                    account.Balance -= amount;
                }
                account.Balance -= amount;
                var description = $"Withdrawal by {customer.FullName}";
                transactionService.CreateTransaction(description, amount, accountNumber);
                MessageBox.Show("Withdrawal successful");
            }
            catch (Exception )
            {
                MessageBox.Show($"try again.");
            }
        }
        private void WithdrawForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
