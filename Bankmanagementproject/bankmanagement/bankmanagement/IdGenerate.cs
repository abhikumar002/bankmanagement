using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class IdGenerate
    {
        static int id = 0;
        string storeId;
        DateTime date = DateTime.Now;

        public string Generate()
        {
            //generate id 
            string gid = DateTime.Now.ToString("yyyyddMHHmmss");

            storeId = gid + ++id;
            return storeId;
        }
    }
}
