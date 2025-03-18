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

    public partial class LoginForm : Form
    {
        Customer customer = Authenticate.customer;
        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string email = textBox1.Text.Trim();

                string password = textBox2.Text.Trim();

                Customer authenticatedCustomer = Authenticate.Login(email, password);

                if (authenticatedCustomer != null)
                {
                    MessageBox.Show("Login successful");
                    
                    UserSession.SetCustomer(authenticatedCustomer);

                    AccountServiceForm accountServiceForm = new AccountServiceForm();
                    accountServiceForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
