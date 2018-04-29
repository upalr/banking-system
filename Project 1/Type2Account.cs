using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Type2Account : Account
    {
        public double monthlyDeposit { get; set; }
        public static double interestRate { get; } = 3.0;
        public static double depositInterestRate { get; } = 4.0;

        public Type2Account(Customer owner, DateTime openedDate, double balance) : base(owner, openedDate, balance)
        { }

        public Type2Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        { }

        public override void Transfer(Account account, double amount)
        {
            if (active == true)
            {
                if (amount > 0)
                {
                    if (balance >= amount)
                    {
                        if (account.GetType() != typeof(Type2Account))
                        {
                            if (account.owner.firstName.Equals(owner.firstName) && account.owner.lastName.Equals(owner.lastName))
                            {
                                balance -= amount;
                                account.balance += amount;
                            }
                            else
                            {
                                Console.WriteLine("Cannot transfer to another account of different coustomer!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cannot transfer to a Type 2 Account!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Transfer amount exceed balance!");
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

            double interest = (interestRate / 365 / 100) * nDays * balance + (depositInterestRate / 365 / 100) * nDays * monthlyDeposit;

            return interest;
        }

        public override void UpdateBalance()
        {
            base.UpdateBalance();
            monthlyDeposit = 0;
        }
    }
}