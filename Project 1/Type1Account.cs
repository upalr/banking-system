﻿using System;

namespace Project_1
{
    class Type1Account : Account
    {

        private static double _InterestRate = 2.0;

        public double InterestRate
        {
            get
            {
                return _InterestRate;
            }
        }

        //Constractor of Type1Account
        public Type1Account(Customer owner, DateTime openedDate, double balance) : base(owner, openedDate, balance)
        {

        }

        //Constractor of Type1Account
        public Type1Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        {

        }

        // Deposite money to the account
        public void Deposit(double amount)
        {
            if (Active == true && amount > 0)
                Balance += amount;
        }

        //Withdraw from the account
        public void Withdraw(double amount)
        {
            if (Active == true)
                if (amount > 0)
                {
                    if (Balance >= amount)
                    {
                        Balance -= amount;
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

        //Trannsfer money to another account
        public override void Transfer(Account account, double amount)
        {
            if (Active == true)
            {
                if (amount > 0)
                {
                    if (Balance >= amount)
                    {
                        Balance -= amount;
                        account.Balance += amount;
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

        // Calculate monthly interest
        public override double CalculateInterest()
        {
            DateTime currentDate = DateTime.Now;
            double span;
            if (currentDate.Month == OpenedDate.Month && currentDate.Year == OpenedDate.Year)
            {
                span = currentDate.Subtract(OpenedDate).TotalDays;
            }
            else
            {
                span = currentDate.Day;
            }
            double nDays = span - 1;

            double interest = (_InterestRate / 365 / 100) * nDays * Balance;

            return interest;
        }
    }
}