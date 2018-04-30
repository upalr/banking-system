using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project_1
{
    class Customer
    {
        private DateTime dateOfBirth;
        private string contactNumber;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                DateTime CurrentDate = DateTime.Now;
                if (CurrentDate.Year - value.Year >= 16)
                {
                    dateOfBirth = value;
                }
                else
                {
                    Console.WriteLine("Customer must be at age of 16 or above.");

                }
            }
        }
        public string ContactNumber {
            get
            {
                return contactNumber;
            }
            set
            {
                if (value.Length == 10)
                {
                    contactNumber = value;
                }
                else
                {
                    Console.WriteLine("contact number must contain exactly 10 digits.");
                }
            }
        }
        public string Email { get; set; }

        private readonly List<Account> AccountList;

        public Customer(string firstName, string lastName, string address, DateTime dateOfBirth, string contactNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            DateOfBirth = dateOfBirth;
            ContactNumber = contactNumber;
            Email = email;
            AccountList = new List<Account>();
        }

        public Customer(string firstName, string lastName, string address, DateTime dateOfBirth, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            DateOfBirth = dateOfBirth;
            ContactNumber = string.Empty;
            Email = email;
            AccountList = new List<Account>();
        }

        public Customer(string firstName, string lastName, string address, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            DateOfBirth = dateOfBirth;
            ContactNumber = string.Empty;
            Email = string.Empty;
            AccountList = new List<Account>();
        }
        public override string ToString()
        {
            //string contact = ContactNumber == 0 ? String.Empty : ContactNumber.ToString();
            return "Name:  " + FirstName +
                " " + LastName +
                "   Address:  " + Address +
                "   DOB:  " + DateOfBirth.ToString("dd/MM/yyyy") +
                "  Contact:  " + ContactNumber +
                "  Email:  " + Email +
                "   Total Balance:  " + SumBalance();
        }

        private double SumBalance()
        {
            var totalBalance = 0.0;
            foreach (var account in AccountList)
            {
                totalBalance += account.balance;
            }
            return totalBalance;
        }

        public List<Account> GetAccounts()
        {
            return AccountList;
        }
    }
}
