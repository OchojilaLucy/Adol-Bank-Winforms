using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class DisplayAccountStatementForm : Form
    {
        private Customer customer;

        public DisplayAccountStatementForm()
        {
            InitializeComponent();
        }

        private void DisplayAccountStatementForm_Load(object sender, EventArgs e)
        {
            FileStorage.LoadAccounts();
             FileStorage.LoadTransactions();
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("You must log in to view your account statement.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string accountNumber = textBox2.Text.Trim();

                if (string.IsNullOrEmpty(accountNumber))
                {
                    MessageBox.Show("Please enter an account number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Account account = FindAccountByNumber(accountNumber);
                if (account == null)
                {
                    MessageBox.Show("Invalid account number or does not belong to you.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                label2.Text = $"ACCOUNT STATEMENT FOR ACCOUNT NUMBER: {account.AccountNumber}";

               
                var accountTransactions = DataStore.transactions
                    .Where(t => t.AccountNumber == accountNumber)
                    .OrderByDescending(t => t.TransactionDate)
                    .ToList();

                UpdateTransactionGrid(accountTransactions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTransactionGrid(List<Transaction> transactions)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Date", "Transaction Date");
                dataGridView1.Columns.Add("Description", "Description");
                dataGridView1.Columns.Add("Amount", "Amount");
                dataGridView1.Columns.Add("Balance", "Balance");
            }

            if (transactions.Any())
            {
                foreach (var transaction in transactions)
                {
                    dataGridView1.Rows.Add(
                        transaction.TransactionDate,
                        transaction.TransactionType,
                        $"{transaction.Amount:C}",
                        $"{transaction.Balance:C}"
                    );
                }
            }
            else
            {
                MessageBox.Show("No transactions available for this account.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }
    }
}
