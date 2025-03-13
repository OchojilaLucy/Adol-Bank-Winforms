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
    public partial class CreateAccountForm : Form
    {
        Customer customer = Authenticate.customer;
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        public void Savings()
        {
            try
            {
                string accountNumber = GenerateAccountNumber();
                AccountType accountType = AccountType.Savings;
                Account account = new Account(customer.FullName, accountNumber, accountType);
                DataStore.accounts.Add(account);
                FileStorage.SaveAccountsAsync(DataStore.accounts);

                MessageBox.Show($"\tAccount name: {customer.FullName}\n\tAccount number: {account.AccountNumber}\n\tAccount type: {account.AccountType}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void Current()
        {
            try
            {
                string accountNumber = GenerateAccountNumber();
                AccountType accountType = AccountType.Current;
                Account account = new Account(customer.FullName, accountNumber, accountType);
                DataStore.accounts.Add(account);
                FileStorage.SaveAccountsAsync(DataStore.accounts);

                MessageBox.Show($"\tAccount name: {customer.FullName}\n\tAccount number: {account.AccountNumber}\n\tAccount type: {account.AccountType}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(1000000000, 1999999999).ToString(); // Generates a 10-digit number
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Savings();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Current();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {

        }
    }

}
