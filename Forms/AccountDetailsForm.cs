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
            FileStorage.LoadAccounts(); // Load account data from file storage

            LoadAccountDetails(); // Populate DataGridView with account details
        }

        private void LoadAccountDetails()
        {
            try
            {
                // Clear previous rows but keep column structure
                dataGridView1.Rows.Clear();

                // If columns haven't been added yet, define them
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("AccountName", "Account Name");
                    dataGridView1.Columns.Add("AccountNumber", "Account Number");
                    dataGridView1.Columns.Add("Balance", "Balance");
                    dataGridView1.Columns.Add("AccountType", "Account Type");
                }

                // Check if accounts exist
                if (DataStore.accounts != null && DataStore.accounts.Any())
                {
                    foreach (var account in DataStore.accounts)
                    {
                        dataGridView1.Rows.Add(
                            account.AccountName,
                            account.AccountNumber,
                            account.Balance.ToString("C"), // Format balance as currency
                            account.AccountType
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No account data available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Adjust UI properties
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true; // Make it read-only to prevent editing
            }
            catch(Exception ex) 
            {
                MessageBox.Show( ex.Message);
            }
        }


       
    }
}
