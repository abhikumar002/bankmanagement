using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class login
    {
        public bool Login()
        {
            bool flag = true;

            while (flag == true)
            {
                Console.WriteLine("\t\n *******************Welcome To Bank System**********************\n ");
                Console.WriteLine("Please Login first\n");


                Console.WriteLine("Username : ");
                string username = Console.ReadLine();
                Console.WriteLine("Password : ");
                string password = Console.ReadLine();

                //check here username is present or not
                if (dblogincheck(username, password))
                {
                    flag = false;
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Username or password \nPlease Enter correct credentials\n");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            return true;
        }



        // DB----------------------------------------------------
        public bool dblogincheck(string username, string password)
        {
            //db open then check
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string check_User_pass = "Select * from branches where username = '" + username + "' and password = '" + password + "'";
                SqlDataAdapter sdp = new SqlDataAdapter(check_User_pass, cnn);
                DataTable dt = new DataTable();
                sdp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    // Console.WriteLine("Areyy hogya yaarr");
                    return true;
                }
                else
                {
                    Console.WriteLine("Please check first");
                    Console.ReadKey();
                    return false;
                }



            }
            cnn.Close();
            return false;
        }


    }
}
