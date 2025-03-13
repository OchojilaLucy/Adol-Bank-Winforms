using System;

namespace AdolBank
{
    public class Account
    {   
        public  string AccountNumber { get; set; }   
        public  string AccountName { get; set; }
        public  AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public decimal MinBalance = 1000;
        public Account(string accountName, string accountNumber, AccountType accountType)
        {
            AccountNumber = accountNumber;
           AccountName = accountName;
            AccountType = accountType;
            


        }
       
    }


}