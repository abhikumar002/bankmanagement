using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String input;
            Bank bk = new Bank();
            index indx = new index();
            Services ser = new Services();

            indx.start();
            Console.Clear();


            while (true)
            {
                Console.WriteLine("\n\t*******************Welcome to Bank Management********************\n");
                Console.WriteLine("\n Please Choose one of them : ");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Show account information");
                Console.WriteLine("3. Deposit money to account");
                Console.WriteLine("4. Withdraw from account");
                Console.WriteLine("5. Show all account with id");
                Console.WriteLine("6. Services ");
                Console.WriteLine("7  Clear screen");
                Console.WriteLine("8  Logout");
                Console.WriteLine("9. Exit");

                input = Console.ReadLine();

                if (input == "1")
                {
                    //Create account
                    bk.createaccount();

                }
                else if (input == "2")
                {
                    //Show account
                    bk.showinfo();
                }
                else if (input == "3")
                {
                    //Deposit money
                    Console.WriteLine("Enter Account id : ");
                    bk.deposit();
                }
                else if (input == "4")
                {
                    //Withdraw Money
                    Console.WriteLine("Enter Account id : ");
                    bk.withdraw();
                }
                else if (input == "5")
                {
                    // show All account with id
                    bk.showall();
                }
                else if (input == "6")
                {
                    //Services
                    ser.serving();
                }
                else if (input == "7")
                {
                    //Clear
                    Console.Clear();
                }
                else if (input == "8")
                {
                    //logout
                    indx.start();
                }
                else if (input == "9")
                {
                    //Exit
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Input ");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
