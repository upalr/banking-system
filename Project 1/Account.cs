using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Account
    {
        private static uint Id;
        [Required]
        public DateTime openedDate { get; }
        [ReadOnly(true)]
        public DateTime closedDate { get; private set; }
        [ReadOnly(true)]
        public bool active { get; private set; }
        public double balance { get; set; }
        public Customer owner { get; }

        public Account(Customer owner, DateTime openedDate, double balance)
        {
            this.owner = owner;
            this.openedDate = openedDate;
            this.balance = balance;
            active = true;
        }

        public Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        {

        }

        public void Close()
        {
            if (active == true)
            {
                active = false;
                closedDate = DateTime.Now;
            }
        }

        public virtual void Transfer(Account account, double amount)
        {
            if (active == true)
            {
                balance -= amount;
                account.balance += amount;
            }
        }

        public virtual double CalculateInterest() {
            return 0.0;
        }

        public virtual void UpdateBalance() {
            balance = balance + CalculateInterest();
        }


        public override string ToString() {
            string closeDateInfo = closedDate == DateTime.MinValue ? " - Closed on " + closedDate : String.Empty;
            return "ID: " + Id + " Open Date: " + openedDate + " Balance: " + balance.ToString("0.0") + " Owner: " + owner + closeDateInfo;
        }
    }
}
