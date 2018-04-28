using System;
using System.Collections.Generic;
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
        public DateTime closedDate { get; }
        public bool active { get; }
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
            if(active == true)
            {
                //active = false;
                //closedDate = DateTime.Now;
            }
        }
    }
}
