using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class index
    {
        public void start()
        {
            string input;
            login lg = new login();
            signup sn = new signup();
            loanCalc lc = new loanCalc();
            fdCalc fc = new fdCalc();
            admin ad = new admin();
            atm at = new atm();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("*******Welcome to Bank management*******\n");
                Console.WriteLine("Please select one of these");
                Console.WriteLine("1.Admin Login");
                Console.WriteLine("2.User Login");
                Console.WriteLine("3.Signup");
                Console.WriteLine("4.ATM service");
                Console.WriteLine("5.Loan Calculator");
                Console.WriteLine("6.FD Calculator");
                Console.WriteLine("7.Exit");


                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    ad.ad_login();
                    return;
                }

                else if (input == "2")
                {
                    //Login account
                    Console.Clear();
                    lg.Login();
                    return;

                }

                else if (input == "3")
                {
                    //Create account
                    Console.Clear();

                    string branchname;
                    string branchcode;
                    string username;
                    string password;

                    //Account Creation
                    Console.Write("Enter BankName: ");
                    branchname = Console.ReadLine();
                    Console.Write("Enter BranchCode: ");
                    branchcode = Console.ReadLine();
                    Console.Write("Enter Username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    password = Console.ReadLine();

                    sn.dbbranchcreate(branchname, branchcode, username, password);

                }

                else if (input == "4")
                {
                    //ATM service
                    at.startatm();
                    return;
                }
                else if (input == "5")
                {
                    //Loan Calculation
                    lc.loan_cal();
                    return;
                }
                else if (input == "6")
                {
                    //FD Calculation
                    fc.fd_clac();
                    return;
                }
                else if (input == "7")
                {
                    //Exit
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter Valid Input");
                }

                Console.ReadKey();
                Console.Clear();

            }

        }
    }
}
