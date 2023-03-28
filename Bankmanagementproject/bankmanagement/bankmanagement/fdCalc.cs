using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bankmanagement
{
    class fdCalc
    {
        index ind = new index();
        Services ser = new Services();

        public void fd_clac()
        {
            double amount, rate, time;
            string a, m, r;
            Console.WriteLine("Please Enter Principle : "); a = Console.ReadLine();
            Console.WriteLine("Please Enter Rate : "); m = Console.ReadLine();
            Console.WriteLine("Please Enter Time : "); r = Console.ReadLine();


            if (ser.checkdatadouble(a, m, r))
            {
                amount = Convert.ToDouble(a);
                rate = Convert.ToDouble(m);
                time = Convert.ToDouble(r);
                ser.FD_Calculator(amount, rate, time);
                Console.ReadKey();
                Console.WriteLine("\n\t\tRedirecting.....\n");
                Thread.Sleep(2000);
                ind.start();
                return;
            }
        }
    }
}
