using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;
using AdolBankWinforms.Helpers;

namespace AdolBankWinforms.Forms
{
    public partial class RegisterForm : Form
    {
        private Validation validation = new Validation();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private async Task RegisterAsync()
        {
            try
            {
                string firstName = textBox1.Text.Trim();
                string lastName = textBox2.Text.Trim();
                string email = textBox3.Text.Trim();
                string password = textBox4.Text;
                string confirmPassword = textBox5.Text;

               
                if (!validation.IsValidName(firstName) || !validation.IsValidName(lastName))
                {
                    MessageBox.Show("Name must start with an uppercase letter and must not contain numbers or special characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (!validation.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid Email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                FileStorage.LoadCustomers();
                if (validation.IsEmailExist(email))
                {
                    MessageBox.Show("Email already exists. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!validation.IsValidPassword(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include an uppercase letter, a lowercase letter, a number, and a special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                Customer customer = new Customer(firstName, lastName, email, password);
                DataStore.customers.Add(customer);
                await FileStorage.SaveCustomersAsync(DataStore.customers);

                MessageBox.Show("Customer created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                this.Hide();
                CustomerServiceForm customerServiceForm = new CustomerServiceForm();
                customerServiceForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            await RegisterAsync();
        }
    }
}
