using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class CreateAccountForm : Form
    {
        private Customer customer;

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to create an account.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            customer = UserSession.LoggedInCustomer;
        }

        private async void CreateAccount(AccountType accountType)
        {
            try
            {
                if (customer == null)
                {
                    MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (customer.Accounts.Any(a => a.AccountType == accountType))
                {
                    MessageBox.Show($"You already have a {accountType} account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string accountNumber = GenerateUniqueAccountNumber();
                Account account = new Account(customer.FullName, accountNumber, accountType);

                customer.Accounts.Add(account);

                DataStore.accounts.Add(account);

                await FileStorage.SaveAccountsAsync(DataStore.accounts);

                MessageBox.Show($" Account created successfully!\n\n" +
                                $"Account Name: {customer.FullName}\n" +
                                $" Account Number: {account.AccountNumber}\n" +
                                $" Account Type: {account.AccountType}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateUniqueAccountNumber()
        {
            Random random = new Random();
            string accountNumber;

            do
            {
                accountNumber = random.Next(1000000000, 1999999999).ToString();
            } while (DataStore.accounts.Any(a => a.AccountNumber == accountNumber));

            return accountNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAccount(AccountType.Savings);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount(AccountType.Current);
        }
    }
}
