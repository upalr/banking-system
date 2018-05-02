using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("Arley", "Praise", "12 Hay Rd", new DateTime(1990, 10, 02), "0412232116", "arleyp@gmail.com");
            Customer c2 = new Customer("Joseph", "Abot", "4/1 Mandy Pl", new DateTime(1970, 05, 11), "0413221624");
            Customer c3 = new Customer("Rose", "Magaret", "30 Buxton St", new DateTime(1980, 07, 06), "0", "rmt@yahoo.com");

            //Customer zahod2 = new Customer("Arley", "Praise", "12 Hay Rd", new DateTime(1990, 10, 02), "0412232116", "arleyp@gmail.com");
            //Customeer zahid = new Customeer(c1);

            //Console.WriteLine(c1.FirstName);
            //c1.FirstName = "zahid";
            //List<Account> = c1.AccountList();
            //int i = 10;
            //int k = i;
            //k = 15;

            //c2 = c1;
            //c2.Address = "Melbourne";


            Type1Account a1 = new Type1Account(c1, new DateTime(2018, 02, 01), 100);
            Type2Account a2 = new Type2Account(c1, new DateTime(2018, 02, 15), 5000);
            Type1Account a3 = new Type1Account(c2, new DateTime(2018, 03, 20), 0);
            Type2Account a4 = new Type2Account(c3, new DateTime(2018, 03, 04), 2000);
            Type2Account a5 = new Type2Account(c3, 3000);

            c1.AddAccount(a1);
            c1.AddAccount(a2);
            c2.AddAccount(a3);
            c3.AddAccount(a4);
            c3.AddAccount(a5);


            Console.WriteLine("Deposite -$200 to a1 -- ");
            a1.Deposit(-200);

            Console.Write("Transfer $6000 from a2 to a1 -- ");
            a2.Transfer(a1, 6000);
            Console.Write("Transfer $2000 from a2 to a1 -- ");
            a2.Transfer(a1, 2000);
            Console.Write("Transfer $1000 from a1 to a2 -- ");
            a1.Transfer(a2, 1000);

            Console.WriteLine("Set the monthly deposit of  a2 to $200 -- ");
            a2.MonthlyDeposit = 200;
            Console.WriteLine("Deposit $5000 to a3 -- ");
            a3.Deposit(5000);
            Console.Write("Withdraw $6000 from a3 -- ");
            a3.Withdraw(6000);
            Console.WriteLine("Transfer $1000 from a3 to a1 -- ");
            a3.Transfer(a1, 1000);
            Console.WriteLine("Transfer $500 from a3 to a2 -- ");
            a3.Transfer(a2, 500);
            Console.WriteLine("Set the monthly deposit of a4 to $1000 -- ");
            a4.MonthlyDeposit = 1000;
            Console.Write("Transfer $100 from a4 to a1 -- ");
            a4.Transfer(a1, 100);
            Console.WriteLine("Set the monthly deposit of a5 to $1500 -- ");
            a5.MonthlyDeposit = 1500;
            Console.Write("Transfer $500 from a5 to a4 -- ");
            a5.Transfer(a4, 500);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Calculate interest");
            Console.WriteLine("Interest of a1 : " + a1.CalculateInterest().ToString("0.0"));
            Console.WriteLine("Interest of a2 : " + a2.CalculateInterest().ToString("0.0"));
            Console.WriteLine("Interest of a3 : " + a3.CalculateInterest().ToString("0.0"));
            Console.WriteLine("Interest of a4 : " + a4.CalculateInterest().ToString("0.0"));
            Console.WriteLine("Interest of a5 : " + a5.CalculateInterest().ToString("0.0"));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Updating balance");
            Console.WriteLine();
            Console.WriteLine();

            a1.UpdateBalance();
            a2.UpdateBalance();
            a3.UpdateBalance();
            a4.UpdateBalance();
            a5.UpdateBalance();

            a3.Close();
            a5.Close();

            Console.WriteLine("Account's information");
            Console.WriteLine(a1.ToString());
            Console.WriteLine(a2.ToString());
            Console.WriteLine(a3.ToString());
            Console.WriteLine(a4.ToString());
            Console.WriteLine(a5.ToString());

            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Customers' information");
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());

            Console.ReadLine();
        }
    }
}
