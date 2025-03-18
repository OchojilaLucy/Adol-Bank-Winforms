using System;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class AccountBalanceForm : Form
    {
        private List<Account> accounts = new List<Account>(); 

        public AccountBalanceForm()
        {
            InitializeComponent();
        }

        private void AccountBalanceForm_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must be logged in to check account balance.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            
            FileStorage.LoadAccounts();
            accounts = DataStore.accounts;
        }

        private Account FindAccountByNumber(string accountNumber)
        {
            return accounts.Find(account => account.AccountNumber == accountNumber);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!UserSession.IsLoggedIn)
                {
                    MessageBox.Show("Please log in first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string accountNumber = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(accountNumber))
                {
                    MessageBox.Show("Please enter an account number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Account account = FindAccountByNumber(accountNumber);

                if (account == null)
                {
                    MessageBox.Show("Invalid account number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Account Balance: {account.Balance:C}", "Balance Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
