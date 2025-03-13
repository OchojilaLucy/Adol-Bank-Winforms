using System;
using AdolBank;

namespace AdolBankWinforms.Helpers
{
    public class Authenticate
    {
        public static Customer customer { get; set; }

        public static Customer Login(string email, string password)
        {
            Validation validation = new Validation();
            Customer user = validation.IsValidLogin(email, password);
            if (user != null)
            {
                customer = user;
                return user;
            }
            else
            {

                return null;
            }
        }
    }
}

