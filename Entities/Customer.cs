using System;

namespace AdolBank
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; }}
        public string Email { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public Customer(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            
            Email = email;
            Password = password;
        }
    }
}