using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AdolBank;

public static class FileStorage
{
    private static readonly string customerFilePath = "customers.json";
    private static readonly string accountFilePath = "accounts.json";
    private static readonly string transactionFilePath = "transactions.json";

    
    public static Task SaveCustomersAsync(List<Customer> customers)
    {
        return Task.Run(() =>
        {
            try
            {
                string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(customerFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving customers: {ex.Message}");
            }
        });
    }

    
    public static List<Customer> LoadCustomers()
    {
        try
        {
            if (File.Exists(customerFilePath))
            {
                string json = File.ReadAllText(customerFilePath);
                return JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading customers: {ex.Message}");
        }
        return new List<Customer>();
    }

    
    public static Task SaveAccountsAsync(List<Account> accounts)
    {
        return Task.Run(() =>
        {
            try
            {
                string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(accountFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving accounts: {ex.Message}");
            }
        });
    }

    
    public static List<Account> LoadAccounts()
    {
        try
        {
            if (File.Exists(accountFilePath))
            {
                string json = File.ReadAllText(accountFilePath);
                return JsonSerializer.Deserialize<List<Account>>(json) ?? new List<Account>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading accounts: {ex.Message}");
        }
        return new List<Account>();
    }

    
    public static Task SaveTransactionsAsync(List<Transaction> transactions)
    {
        return Task.Run(() =>
        {
            try
            {
                string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(transactionFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transactions: {ex.Message}");
            }
        });
    }

    
    public static List<Transaction> LoadTransactions()
    {
        try
        {
            if (File.Exists(transactionFilePath))
            {
                string json = File.ReadAllText(transactionFilePath);
                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading transactions: {ex.Message}");
        }
        return new List<Transaction>();
    }
}
