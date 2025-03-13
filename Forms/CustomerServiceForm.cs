using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdolBankWinforms.Forms
{
    public partial class CustomerServiceForm : Form
    {
        public CustomerServiceForm()
        {
            InitializeComponent();
        }

        private void CustomerServiceForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
