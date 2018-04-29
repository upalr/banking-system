using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Type1Account : Account
    {
        public static double interestRate { get; } = 2.0;

        public Type1Account(Customer owner, DateTime openedDate, double balance) : base(owner, openedDate, balance)
        {

        }

        public Type1Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        {

        }

        public void Deposit(double amount)
        {
            if (active == true && amount > 0)
                balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (active == true)
                if (amount > 0)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                    }
                    else
                    {
                        Console.WriteLine("Withdraw amount exceed balance!");
                    }
                }
                else
                {
                    Console.WriteLine("Negative amunt can not be withdraw!");
                }
            else
            {
                Console.WriteLine("Account inactive!");
            }
        }

        public override void Transfer(Account account, double amount)
        {
            if (active == true)
            {
                if (amount > 0)
                {
                    if (balance >= amount) 
                    {
                        balance -= amount;
                        account.balance += amount;
                    }
                    else
                    {
                        Console.WriteLine("Tranesfer amount exceed balance!");
                    }
                }
                else
                {
                    Console.WriteLine("Negative ammount can't be transfered!");
                }
            }
            else
            {
                Console.WriteLine("Account is inactive!");
            }
        }

        public override double CalculateInterest()
        {
            DateTime currentDate = DateTime.Now;
            double span;
            if (currentDate.Month == openedDate.Month && currentDate.Year == openedDate.Year)
            {
                span = currentDate.Subtract(openedDate).TotalDays;
            }
            else
            {
                span = currentDate.Day;
            }
            double nDays = span - 1;

            double interest = (interestRate / 365 / 100) * nDays * balance;

            return interest;
        }
    }
}