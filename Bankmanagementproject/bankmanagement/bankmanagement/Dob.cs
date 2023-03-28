using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class Dob
    {
        public int day;
        private int month;
        private int year;
        public void set(int d, int m, int y)
        {
            //set dob with bool
            this.day = d;
            this.month = m;
            this.year = y;
        }

        public bool checkdate()
        {
            //give bool dob is set or not

            if ((day <= 0 || day > 31) || (month <= 0 || month > 12) || (year <= 0 || year > 2006))
            {
                Console.WriteLine("Invalid date or You are not eligible ");
                return false;
            }
            else return true;
        }

        public bool printDate()
        {
            if (checkdate() == true)
            {
                Console.WriteLine("Date is : " + day + "-" + month + "-" + year);
                return true;
            }
            else
                Console.WriteLine(" Please enter valid date again ");
            return false;


        }
    }
}
