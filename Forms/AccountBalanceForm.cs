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
    public partial class AccountBalanceForm : Form
    {
        Customer customer = Authenticate.customer;
        public AccountBalanceForm()
        {
            InitializeComponent();
        }

        private void AccountBalanceForm_Load(object sender, EventArgs e)
        {

        }
        private Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            FileStorage.LoadAccounts();
            return DataStore.accounts.Find(account => account.AccountNumber == accountNumber);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string accountNumber = textBox1.Text;

                Account account = FindAccountByNumber(customer, accountNumber);
                if (account == null)
                {
                    MessageBox.Show("Invalid account number.");
                }
                MessageBox.Show($"Account Balance: {account.Balance}");
            }
            catch (Exception) 
            {
                MessageBox.Show("error");
            }
        }

        
        
    }
}
