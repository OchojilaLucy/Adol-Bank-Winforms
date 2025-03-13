using AdolBankWinforms;
using AdolBankWinforms.Forms;

namespace AdolBankWinforms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Task.Run(() => FileStorage.LoadTransactions());
            Task.Run(() => FileStorage.LoadAccounts());
            Task.Run(() => FileStorage.LoadCustomers());

            Application.Run(new CustomerServiceForm());
            
        }
    }
}