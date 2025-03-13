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
                string email = textBox1.Text;

                string password = textBox2.Text;

                customer = new Customer("", "", email, password);


                if (Authenticate.Login(email, password) != null)
                {
                    MessageBox.Show("Login successful");
                    customer.FirstName = Authenticate.customer.FirstName;
                    AccountServiceForm accountServiceForm = new AccountServiceForm();
                    accountServiceForm.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid email or password");

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void LoginForm_Load(object sender, EventArgs e)
        //{

        //}
    }
}
