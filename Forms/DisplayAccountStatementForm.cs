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
        Customer customer = Authenticate.customer;

        public DisplayAccountStatementForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private Account FindAccountByNumber(Customer customer, string accountNumber)
        {
            
            return DataStore.accounts.Find(account => account.AccountNumber == accountNumber);
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

                Account account = FindAccountByNumber(customer, accountNumber);
                if (account == null)
                {
                    MessageBox.Show("Invalid account number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                label2.Text = "ACCOUNT STATEMENT ON ACCOUNT NUMBER: " + account.AccountNumber;

                // Run transaction loading in a separate thread
                //List<Transaction> transactions = await Task.Run(() => FileStorage.LoadTransactions());

                //DataStore.transactions = transactions.FindAll(t => t.AccountNumber == account.AccountNumber);

                // Update UI on the main thread
                UpdateTransactionGrid(DataStore.transactions);
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

            if (transactions != null && transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    dataGridView1.Rows.Add(
                        transaction.TransactionDate,
                        transaction.TransactionType,
                        transaction.Amount,
                        transaction.Balance
                    );
                }
            }
            else
            {
                MessageBox.Show("No transactions available for this account.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void DisplayAccountStatementForm_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
