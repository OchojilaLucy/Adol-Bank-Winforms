using System;

namespace AdolBank
{
    public class Transaction

    {
        public Transaction(int transactionId, string transactionType, decimal amount, string accountNumber)
        {
            TransactionId = transactionId;
            TransactionType = transactionType;
            Amount = amount;
            TransactionDate = DateTime.Now.ToString("MM/dd/yyyy");
            AccountNumber = accountNumber;  
        }
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}