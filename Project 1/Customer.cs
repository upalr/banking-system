using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [ReadOnly(true)]
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
            string contact = contactNumber == 0 ? String.Empty : contactNumber.ToString();
            return "Name:  " + firstName +
                " " + lastName + 
                "   Address:  " + address +
                "   DOB:  " + dateOfBirth.ToString("dd/MM/yyyy") + 
                "  Contact:  " + contact + 
                "  Email:  " + email +
                "   Total Balance:  " + SumBalance();
        }

        private double SumBalance()
        {
            var totalBalance = 0.0;
            foreach (var account in accountList)
            {
                totalBalance += account.balance;
            }
            return totalBalance;
        }

        public List<Account> GetAccounts()
        {
            return accountList;
        }
    }
}
