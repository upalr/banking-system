using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_1
{
    class Customer
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        public int contactNumber { get; set; }
        public string email { get; set; }

        private List<Account> accountList = new List<Account>();

        public Customer(string firstName, string lastName, string address, DateTime dateOfBirth, int contactNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.dateOfBirth = dateOfBirth;
            this.contactNumber = contactNumber;
            this.email = email;
        }

        public override string ToString()
        {
            return "First Name: " + firstName +
                "Last Name: " + lastName + 
                "Address: " + address +
                "Date of birth: " + dateOfBirth + 
                "Contact Number: " + contactNumber + 
                "Email: " + email +
                "Total Balance: " + SumBalance();
        }

        private string SumBalance()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts()
        {
            return accountList;
        }
    }
}
