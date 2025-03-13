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
        Customer customer = Authenticate.customer;
        TransactionService transactionService = new TransactionService();
        public TransferForm()
        {
            InitializeComponent();
        }
        public Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            FileStorage.LoadAccounts();
            return DataStore.accounts.Find(account => account.AccountNumber == accountNumber);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sourceNo = textBox1.Text;
                string beneficiaryNo = textBox2.Text;
                 
               
                Account sourceAccount = FindAccountByNumber(customer, sourceNo);
                Account destinationAccount = FindAccountByNumber(customer, beneficiaryNo);

                if (sourceAccount == null || destinationAccount == null)
                {
                    MessageBox.Show("One or both account numbers are invalid.");

                }

                if (!decimal.TryParse(textBox3.Text, out decimal amount) || amount <= 0)
                {
                    MessageBox.Show("Invalid amount");
                }

                if (amount > sourceAccount.Balance)
                {
                    MessageBox.Show("Insufficient Funds!");

                }
                if (sourceAccount.AccountType == AccountType.Savings)
                {
                    if (sourceAccount.Balance <= sourceAccount.MinBalance)
                    {
                        MessageBox.Show("Insufficient Funds");
                        return;
                    }
                    sourceAccount.Balance -= amount;
                    destinationAccount.Balance += amount;
                }
                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;

                var sDescription = $"Transfer to {customer.FullName}";
                var dDescription = $"Transfer by {customer.FullName}";
                transactionService.CreateTransaction(sDescription, amount, sourceNo);
                transactionService.CreateTransaction(dDescription, amount, beneficiaryNo);
                MessageBox.Show("Transfer successful");
            }
            catch (Exception )
            {
                MessageBox.Show($"Please try again.");
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TransferForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
