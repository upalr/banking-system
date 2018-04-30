using System;

namespace Project_1
{
    class Account
    {
        private static uint ID = 1;

        private uint _Id = ID++;
        private DateTime _OpenedDate;
        private DateTime _ClosedDate;
        private bool _Active;
        private double _Balance = 0;
        private Customer _Owner;

        public uint Id
        {
            get { return _Id; }
        }

        public DateTime OpenedDate
        {
            get
            {
                return _OpenedDate;

            }
        }

        public DateTime ClosedDate
        {
            get { return _ClosedDate; }
        }

        public bool Active
        {
            get { return _Active; }
        }

        public double Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
            }
        }
        public Customer Owner
        {
            get { return _Owner; }
        }

        public Account(Customer owner, DateTime openedDate, double balance)
        {
            _Owner = owner;
            if (openedDate.CompareTo(DateTime.Now) <= 0)
                _OpenedDate = OpenedDate;
            else
                Console.WriteLine("The opened date of an account must be on or before the current date");

            if (balance >= 0)
            {
                _Balance = balance;
            }
            else
            {
                Console.WriteLine("Balance must be equal or greater than 0.");
            }
            _Active = true;
        }

        public Account(Customer owner, double balance) : this(owner, DateTime.Now, balance)
        {

        }

        public void Close()
        {
            if (_Active == true)
            {
                _Active = false;
                _ClosedDate = DateTime.Now;
            }
        }

        public virtual void Transfer(Account account, double amount)
        {
            if (_Active == true)
            {
                _Balance -= amount;
                account.Balance += amount;
            }
        }

        public virtual double CalculateInterest()
        {
            return 0.0;
        }

        public virtual void UpdateBalance()
        {
            _Balance = _Balance + CalculateInterest();
        }

        public override string ToString()
        {
            string closeDateInfo = _ClosedDate != DateTime.MinValue ? "   - Closed on " + _ClosedDate.ToString("dd/MM/yyyy") : String.Empty;
            return "ID:   " + Id +
                   "   Opened Date:    " + _OpenedDate.ToString("dd/MM/yyyy") +
                   "   Balance:   " +  _Balance.ToString("0,0.0") +
                   "   Owner:   " + _Owner.FirstName + "  " + _Owner.LastName +
                   closeDateInfo;
        }
    }
}
