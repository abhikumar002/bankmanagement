using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class Current : Account
    {
        public Current() : base() { }

        public override bool deposit(double amount)
        {
            this.amount = amount;
            this.balance = balance + amount;
            Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
            return true;
        }

        public override bool withdraw(double amount)
        {
            this.amount = amount;
            double checkamount = balance - amount;
            if (checkamount > 0)
            {
                this.balance = balance - amount;
                Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
                return true;
            }
            else
            {
                Console.WriteLine("Your Account don't have sufficient ammount of money!");
                return false;
            }
        }
    }
}
