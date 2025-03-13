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
    public partial class RegisterForm : Form
    {
        Validation validation = new Validation();
        public RegisterForm()
        {
            InitializeComponent();
        }
        public void Register()
        {
            try
            {
                string firstName = textBox1.Text;

                if (!validation.IsValidName(firstName))
                {
                    MessageBox.Show("Name must start with an uppercase letter and must not contain numbers or special characters.");
                }

                string lastName = textBox2.Text;

                if (!validation.IsValidName(lastName))
                {
                    MessageBox.Show("Name must start with an uppercase letter and must not contain numbers or special characters.");
                }

                string email = textBox3.Text;

                if (!validation.IsValidEmail(email))
                {
                    MessageBox.Show("Invalid Email format.");


                }

                if (validation.IsEmailExist(email))
                {
                    MessageBox.Show("Email already exists. Please try again.");
                    return;
                }


                string password = textBox4.Text;

                if (!validation.IsValidPassword(password))
                {
                    MessageBox.Show("Password must contain at least 8 characters, including at least an uppercase letter, a lowercase letter, number and special character");
                    //return;
                }


                string confirmPassword = textBox5.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please try again.");
                    return;
                }

                Customer customer = new Customer(firstName, lastName, email, password);
                DataStore.customers.Add(customer);
                FileStorage.SaveCustomersAsync(DataStore.customers);

                MessageBox.Show("Customer created successfully!");
                CreateAccountForm createAccountForm = new CreateAccountForm();
                createAccountForm.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Register();
        }

        
    }
}
