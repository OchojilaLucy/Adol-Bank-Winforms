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
    public partial class DepositForm : Form
    {
        Customer customer = Authenticate.customer;
        TransactionService transactionService = new TransactionService();
        public DepositForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            FileStorage.LoadAccounts();
            return DataStore.accounts.Find(account => account.AccountNumber == accountNumber);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("Invalid amount. ");

                }
                if (account.AccountType == AccountType.Savings)
                {
                    if (amount < minBalance)
                    {
                        MessageBox.Show("Minimum balance for savings account is 1000");
                    }
                }
                account.Balance += amount;
                var description = $"Deposit by {customer.FullName}";
                transactionService.CreateTransaction(description, amount, accountNumber);
                MessageBox.Show("Deposit successful");
            }
            catch(Exception )
            {

                MessageBox.Show("Please try again");
            }

            

        }

        private void DepositForm_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
