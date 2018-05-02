using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project_1
{
    class Customer
    {
        private string _FirstName;
        private string _LastName;
        private string _Address;
        private DateTime _DateOfBirth;
        private string _ContactNumber;
        private string _Email;
        private List<Account> _AccountList;


        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                DateTime CurrentDate = DateTime.Now;
                if (CurrentDate.Year - value.Year >= 16)
                {
                    _DateOfBirth = value;
                }
                else
                {
                    Console.WriteLine("Customer must be at age of 16 or above.");

                }
            }
        }

        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                if (value.Length == 10)
                {
                    _ContactNumber = value;
                }
                else
                {
                    Console.WriteLine("Contact number must contain exactly 10 digits.");
                }
            }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public ReadOnlyCollection<Account> AccountList
        {
            get { return _AccountList.AsReadOnly(); }
        }


        //Constractor
        public Customer(string firstName, string lastName, string address, DateTime dateOfBirth, string contactNumber = "", string email = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            DateOfBirth = dateOfBirth;
            ContactNumber = contactNumber;
            Email = email;
            _AccountList = new List<Account>();
        }

        //Copy constractor
        public Customer(Customer customer)
        {
            _FirstName = customer.FirstName;
            _LastName = customer.LastName;
            _Address = customer.Address;
            _DateOfBirth = customer.DateOfBirth;
            _ContactNumber = customer.ContactNumber;
            _Email = customer.Email;
            _AccountList = new List<Account>(customer._AccountList);
        }

        //Add account for one customer
        public void AddAccount(Account account)
        {
            _AccountList.Add(account);
        }

        // Total balance calculated by adding all account's of one customer 
        private double SumBalance()
        {
            var totalBalance = 0.0;
            foreach (var account in _AccountList)
            {
                totalBalance = totalBalance + account.Balance;// total
            }
            return totalBalance;
        }

        //String representation of the class
        public override string ToString()
        {
            return "Name:  " + FirstName +
                " " + LastName +
                "   Address:  " + Address +
                "   DOB:  " + DateOfBirth.ToString("dd/MM/yyyy") +
                "  Contact:  " + ContactNumber +
                "  Email:  " + Email +
                "   Total Balance:  " + SumBalance().ToString("0,0.0");
        }
    }
}
