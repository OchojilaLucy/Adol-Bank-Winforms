using System;
using System.Collections;
using AdolBank;
using System.IO;

using System.Linq;
using AdolBankWinforms.Forms;
using AdolBankWinforms.Helpers;


namespace AdolBank

{
    public class TransactionService
    {
        public static int IdCount { get; set; } = 0;
        Customer customer = Authenticate.customer;
        public void CreateTransaction(string transactionType, decimal amount, string accountNumber)
        {
            var transaction = new Transaction(IdCount, transactionType, amount, accountNumber);
            DataStore.transactions.Add(transaction);

            //FileStorage.SaveAccountsAsync(DataStore.accounts);
            //FileStorage.SaveTransactionsAsync(DataStore.transactions).Wait();

            IdCount++;
            //FileStorage.LoadAccounts();
            TransferForm transferForm = new TransferForm();
            Account account = transferForm.FindAccountByNumber(customer, accountNumber);    
            

            transaction.Balance = account.Balance;
        }

        
    }
}