using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdolBank;


namespace AdolBankWinforms.Forms
{
    public partial class AccountServiceForm : Form
    {

        Customer customer { get; set; }
        public AccountServiceForm()
        {
            InitializeComponent();
        }


        
        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountDetailsForm accountDetailsForm = new AccountDetailsForm();
            accountDetailsForm.Show();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DepositForm depositForm = new DepositForm();
            depositForm.Show();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            WithdrawForm withdrawForm = new WithdrawForm();
            withdrawForm.Show();
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            TransferForm transferForm = new TransferForm();
            transferForm.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisplayAccountStatementForm accountStatementForm = new DisplayAccountStatementForm();
            accountStatementForm.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AccountBalanceForm accountBalanceForm = new AccountBalanceForm();
            accountBalanceForm.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LogoutForm logoutForm = new LogoutForm();
            logoutForm.Show();
            
        }

        private void AccountServiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}

