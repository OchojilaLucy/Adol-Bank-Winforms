using System;
using System.Text.RegularExpressions;
using System.Linq;
using AdolBank;

namespace AdolBankWinforms.Helpers
{
    public class Validation
    {
        public static bool IsValidAccountNumber(string accountNumber)
        {
            if (accountNumber.Length != 10)
            {
                return false;
            }
            return true;
        }
        public bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && char.IsUpper(name[0]) && !Regex.IsMatch(name, @"[\d\W]");
        }
        public bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Length >= 8 &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"\d") &&
                   Regex.IsMatch(password, @"[\W_]") &&
                   !password.Contains(" ");
        }
        public Customer IsValidLogin(string email, string password)
        {
            Customer customer = DataStore.customers.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            if (customer != null)
            {
                return customer;
            }

            return null;
        }
        public bool IsEmailExist(string email)
        {
            if (!DataStore.customers.Exists(c => c.Email == email))
            {
                return false;
            }
            return true;
        }



    }
}