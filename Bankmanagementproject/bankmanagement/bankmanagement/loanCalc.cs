using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bankmanagement
{
    class loanCalc
    {
        index ind = new index();
        Services ser = new Services();

        public void loan_cal()
        {
            string a, m, r;
            double amount, rate, time;

            Console.WriteLine("Please Enter Principle : "); a = Console.ReadLine();
            Console.WriteLine("Please Enter Rate : "); m = Console.ReadLine();
            Console.WriteLine("Please Enter Time : "); r = Console.ReadLine();

            if (ser.checkdatadouble(a, m, r))
            {
                amount = Convert.ToDouble(a);
                rate = Convert.ToDouble(m);
                time = Convert.ToDouble(r);
                ser.loan(amount, rate, time);
                Console.ReadKey();
                Console.WriteLine("\n\t\tRedirecting...");
                Thread.Sleep(2000);
                //Console.ReadKey();
                ind.start();
                return;
            }
        }
    }
}
