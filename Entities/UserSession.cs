using System;
using AdolBankWinforms;
using AdolBank;


namespace AdolBankWinforms
{
    public static class UserSession
    {
        public static Customer LoggedInCustomer { get; private set; } = null;
        public static bool IsLoggedIn => LoggedInCustomer != null;

        public static void SetCustomer(Customer customer)
        {
            LoggedInCustomer = customer;
        }

        public static void Clear()
        {
            LoggedInCustomer = null;
        }
    }

}