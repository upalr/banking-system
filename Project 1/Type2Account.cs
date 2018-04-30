using System;

namespace Project_1
{
    class Type2Account : Account
    {
        private double _MonthlyDeposit;
        public static double _AnnualInterestRate = 3.0;
        public static double _DepositInterestRate = 4.0;


        public double MonthlyDeposit
        {
            get { return _MonthlyDeposit; }
            set { _MonthlyDeposit = value; }
        }

        public double AnnualInterestRate
        {
            get { return _AnnualInterestRate; }
        }

        public double DepositInterestRate
        {
            get { return _DepositInterestRate; }
        }

        //Constractor of Type2Account
        public Type2Account(Customer owner, DateTime openedDate, double balance) : base(owner, openedDate, balance)
        { }

        //Constractor of Type2Account
        public Type2Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        { }

        //Trannsfer money to another account
        public override void Transfer(Account account, double amount)
        {
            if (Active == true)
            {
                if (amount > 0)
                {
                    if (Balance >= amount)
                    {
                        if (account.GetType() != typeof(Type2Account))
                        {
                            if (account.Owner.FirstName.Equals(Owner.FirstName) && account.Owner.LastName.Equals(Owner.LastName))
                            {
                                Balance -= amount;
                                account.Balance += amount;
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

            double interest = (_AnnualInterestRate / 365 / 100) * nDays * Balance + (_DepositInterestRate / 365 / 100) * nDays * _MonthlyDeposit;

            return interest;
        }

        //Update balance with the interest
        public override void UpdateBalance()
        {
            base.UpdateBalance();
            _MonthlyDeposit = 0;
        }
    }
}