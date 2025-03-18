using System;
using System.Linq;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class AccountDetailsForm : Form
    {
        public AccountDetailsForm()
        {
            InitializeComponent();
        }

        private void AccountDetailsForm_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to view account details.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            FileStorage.LoadAccounts(); 

            LoadAccountDetails(); 
        }

        private void LoadAccountDetails()
        {
            try
            {
                dataGridView1.Rows.Clear(); 

                
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("AccountName", "Account Name");
                    dataGridView1.Columns.Add("AccountNumber", "Account Number");
                    dataGridView1.Columns.Add("Balance", "Balance");
                    dataGridView1.Columns.Add("AccountType", "Account Type");
                }

                Customer loggedInCustomer = UserSession.LoggedInCustomer;

                
                var customerAccounts = DataStore.accounts.Where(account => account.AccountName == loggedInCustomer.FullName);
                
                if (customerAccounts != null)
                {
                    foreach (var account in customerAccounts)
                    {
                        dataGridView1.Rows.Add(
                            account.AccountName,
                            account.AccountNumber,
                            account.Balance.ToString("C"), 
                            account.AccountType
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No accounts found for this user.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Adjust DataGridView settings
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading account details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
