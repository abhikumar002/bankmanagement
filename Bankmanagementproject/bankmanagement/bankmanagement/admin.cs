using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bankmanagement
{
    class admin
    {
        Bank bk = new Bank();
        index ind = new index();
        trans tr = new trans();
        public void ad_login()
        {
            bool flag = true;
            string pwd;
            char choice;
            while (flag == true)
            {
                
                Console.WriteLine("\t\n *******************Welcome To Bank System**********************\n ");
                Console.WriteLine("\n\t\t\tADMIN LOGIN\n");
                Console.Write("\t\tEnter Password: ");
                pwd = Console.ReadLine();
                if (pwd == "adminPWD")
                {
                    flag = false;
                    while (true)
                    {
                        Console.Clear();
                        string datacheck;
                        Console.WriteLine("\n1.Show all account info with id");
                        Console.WriteLine("2.Show specific account details");
                        Console.WriteLine("3.Highest withdrawal");
                        Console.WriteLine("4.Highest deposit");
                        Console.WriteLine("5.Log Out");
                        Console.WriteLine("6.Exit");
                        datacheck= Console.ReadLine();

                        if (checkchar(datacheck))
                        {
                            choice=Convert.ToChar(datacheck);
                            if (choice == '1')
                            {
                                bk.showall();
                            }
                            else if (choice == '2')
                            {
                                bk.showinfo();
                            }
                            else if (choice == '3')
                            {
                                tr.highestWd();
                            }
                            else if (choice == '4')
                            {
                                tr.highestDep();
                            }
                            else if (choice == '5')
                            {
                                ind.start();
                                return;
                            }
                            else if (choice == '6')
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Valid Input ");
                            }
                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\t\tInvalid Password");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }

        public bool checkchar(string data)
        {
            try
            {
                char date = Convert.ToChar(data);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please Choose Valid choice."); // or other default value as appropriate in context.
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
