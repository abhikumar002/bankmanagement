using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    abstract class Account
    {
        public double balance;
        public readonly string name;
        public readonly Dob DOB;
        public double amount;
        public readonly string nominee;

        public abstract bool deposit(double amount);
        public abstract bool withdraw(double amount);

        public double getBalance()
        {
            return balance;
        }

        public string getAccType()
        {
            string actype;
            actype = Console.ReadLine();
            return actype;
        }

        public void printAccount()
        {
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Date of Birth : " + DOB);
            Console.WriteLine("Nominee : " + nominee);
            Console.WriteLine("Balance : " + balance);
        }

        public Account() { }
        public Account(double balance, string name, Dob dOB, string nominee)
        {

            this.name = name;
            this.DOB = dOB;
            this.nominee = nominee;
            this.balance = balance;
        }
    }
}
