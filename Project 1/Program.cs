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
            Customer c1 = new Customer("Arley", "Praise", "12 Hay Rd", new DateTime(02 / 10 / 1990), 0412232116, "arleyp@gmail.com");
            Customer c2 = new Customer("Joseph", "Abot", "4/1 Mandy Pl", new DateTime(11 / 05 / 1970), 0413221624, String.Empty);
            // phone number
            Customer c3 = new Customer("Rose", "Magaret", "30 Buxton St", new DateTime(06 / 07 / 1980), 0, "rmt@yahoo.com");

            Type1Account a1 = new Type1Account(c1, new DateTime(01 / 02 / 2018), 100);
            Type2Account a2 = new Type2Account(c1, new DateTime(15 / 02 / 2018), 5000);
            //balance
            Type1Account a3 = new Type1Account(c2, new DateTime(20 / 03 / 2018), 0);
            Type2Account a4 = new Type2Account(c3, new DateTime(04 / 03 / 2018), 2000);
            Type2Account a5 = new Type2Account(c3,3000);

            a1.Deposit(-200);
            a2.Transfer(a1, 6000);
            a2.Transfer(a1, 2000);
            a1.Transfer(a2, 1000);
            a2.monthlyDeposit = 200;
            a3.Deposit(5000);
            a3.Withdraw(6000);
            a3.Transfer(a1, 1000);
            a3.Transfer(a2, 500);
            a4.monthlyDeposit = 1000;
            a4.Transfer(a1, 100);
            a5.monthlyDeposit = 1500;
            a5.Transfer(a4, 500);

            Console.WriteLine(a1.CalculateInterest());
            Console.WriteLine(a2.CalculateInterest());
            Console.WriteLine(a3.CalculateInterest());
            Console.WriteLine(a4.CalculateInterest());
            Console.WriteLine(a5.CalculateInterest());

            a1.UpdateBalance();
            a2.UpdateBalance();
            a3.UpdateBalance();
            a4.UpdateBalance();
            a5.UpdateBalance();

            a3.Close();
            a5.Close();

            Console.WriteLine(a1.ToString());
            Console.WriteLine(a2.ToString());
            Console.WriteLine(a3.ToString());
            Console.WriteLine(a4.ToString());
            Console.WriteLine(a5.ToString());

            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());

            Console.ReadLine();
        }
    }
}
