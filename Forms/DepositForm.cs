using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class DepositForm : Form
    {
        private Customer customer;
        private TransactionService transactionService = new TransactionService();

        public DepositForm()
        {
            InitializeComponent();
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {
            FileStorage.LoadAccounts();
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to make a deposit.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            customer = UserSession.LoggedInCustomer;
        }

        private Account FindAccountByNumber(string accountNumber)
        {
            

            return DataStore.accounts
                .FirstOrDefault(account => account.AccountNumber == accountNumber);
        }

        private async void button1_Click_1(object sender, EventArgs e)
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

                Account account = FindAccountByNumber(accountNumber);
                if (account == null)
                {
                    MessageBox.Show("Account not found or does not belong to you.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (account.AccountType == AccountType.Savings && amount < account.MinBalance)
                {
                    MessageBox.Show("Minimum deposit for savings accounts is 1000.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                account.Balance += amount;

                var description = $"Deposit of {amount:C} by {customer.FullName}";
                transactionService.CreateTransaction(description, amount, accountNumber);

                await FileStorage.SaveAccountsAsync(DataStore.accounts);
                

                MessageBox.Show($" Deposit successful!\n\nNew Balance: {account.Balance:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
