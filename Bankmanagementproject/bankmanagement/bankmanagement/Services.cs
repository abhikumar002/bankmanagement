using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class Services
    {
        public void serving()
        {
            string input;
            bool flag = true;
            double amount, rate, time;
            while (flag == true)
            {
                Console.Clear();
                Console.WriteLine("1. Loan Amount Calculation ");
                Console.WriteLine("2. FD Calculation ");

                input = Console.ReadLine();

                if (input == "1")
                {
                    string a, m, r;
                    //loan Calc
                    Console.WriteLine("Please Enter Principle : "); a = Console.ReadLine();
                    Console.WriteLine("Please Enter Rate : "); m = Console.ReadLine();
                    Console.WriteLine("Please Enter Time : "); r = Console.ReadLine();

                    if (checkdatadouble(a, m, r))
                    {
                        amount = Convert.ToDouble(a);
                        rate = Convert.ToDouble(m);
                        time = Convert.ToDouble(r);
                        loan(amount, rate, time);
                        flag = false;
                    }


                }
                else if (input == "2")
                {
                    //FD Calc
                    string a, m, r;
                    Console.WriteLine("Please Enter Principle : "); a = Console.ReadLine();
                    Console.WriteLine("Please Enter Rate : "); m = Console.ReadLine();
                    Console.WriteLine("Please Enter Time : "); r = Console.ReadLine();


                    if (checkdatadouble(a, m, r))
                    {
                        amount = Convert.ToDouble(a);
                        rate = Convert.ToDouble(m);
                        time = Convert.ToDouble(r);
                        FD_Calculator(amount, rate, time);
                        flag = false;
                    }

                }
                else
                {
                    Console.WriteLine("Please enter valid input");
                }

            }
        }

        public bool loan(double amount, double time, double rate)
        {
            double c1 = (rate * time);
            double c2 = amount * c1;
            double interest = c2 / 100;
            double answer = interest + amount;
            Console.WriteLine("\nTotal Amount will be : " + answer);
            Console.WriteLine("Total Interest Give : " + interest);
            return true;
        }

        public bool FD_Calculator(double amount, double time, double rate)
        {
            double c1 = (rate * time);
            double c2 = amount * c1;
            double interest = c2 / 100;
            double answer = interest + amount;
            Console.WriteLine("\nMaturity Amount is : " + answer);
            Console.WriteLine("Total Interest Earned : " + interest);
            return true;

        }

        public bool checkdatadouble(string data1, string data2, string data3)
        {
            try
            {
                double amount = Convert.ToDouble(data1);
                double rate = Convert.ToDouble(data2);
                double time = Convert.ToDouble(data3);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter valid input."); // or other default value as appropriate in context.
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
