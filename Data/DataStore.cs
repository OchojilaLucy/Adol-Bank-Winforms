using System;
using System.Collections.Generic;
using System.IO;



namespace AdolBank
{
    public class DataStore
    {
        public static List<Account> accounts = new List<Account>();
        
        public static List<Transaction> transactions = new List<Transaction>();
        public static List<Customer> customers = new List<Customer>();
        static DataStore()
        {
            
            customers = FileStorage.LoadCustomers();
            accounts = FileStorage.LoadAccounts();
            transactions = FileStorage.LoadTransactions();
        }
    }

}