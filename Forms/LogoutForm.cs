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
    public partial class LogoutForm : Form
    {
        public LogoutForm()
        {
            InitializeComponent();
        }

        

        private void LogoutForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Successful");
            return;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AccountServiceForm accountServiceForm = new AccountServiceForm();
            accountServiceForm.ShowDialog();
        }
    }
}
