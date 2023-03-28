using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bankmanagement
{
    class atm
    {
        Bank bk = new Bank();
        index indx = new index();
        Program pg = new Program();
        public void startatm()
        {

            string id;
            string atmpin;

            while (true)
            {
                Console.WriteLine("Please Enter your Account no.");
                id = Console.ReadLine();
                if (bk.checkdb(id))
                {
                    if (checkatm(id))
                    {

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter below options: ");
                            Console.WriteLine("1.Deposit Money");
                            Console.WriteLine("2.Withdraw Money");

                            string option = Console.ReadLine();

                            Console.WriteLine("Please enter Your 4 digit ATM Pin : ");
                            atmpin = Console.ReadLine();

                            if (option == "1")
                            {
                                //deposit money                            
                                if (checkatmpin(id, atmpin))
                                {
                                    Console.Write("Please enter Account id : ");
                                    bk.deposit();
                                    Console.WriteLine("\n\tPlease wait 4 seconds for next transactions.");
                                    Thread.Sleep(4000);
                                    indx.start();
                                    return;
                                }
                            }
                            else if (option == "2")
                            {
                                //withdraw money
                                if (checkatmpin(id, atmpin))
                                {
                                    Console.Write("Please Enter Account id : ");
                                    bk.withdraw();
                                    Console.WriteLine("\n\tPlease wait 4 seconds for next transactions...");
                                    Thread.Sleep(4000);
                                    indx.start();
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter correct option");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Set your atm pin first.");
                        create(id);
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Correct account number.");
                    Console.ReadKey();
                    indx.start();
                }
            }
        }
        public void create(string id)
        {
            string pin;
            Console.WriteLine("\nPlease Enter 4 digit pin to create : ");
            pin = Console.ReadLine();
            createatm(id, pin);
            Console.ReadKey();
            indx.start();
        }

        //DB--------------------------------------------------

        private void createatm(string id, string pin)
        {
            //create when data is not there in database.
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //Create table if not exist
            CreateTableIfNotExists();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "Insert into atmdetail(id,atmpin) values ('" + id + "','" + pin + "')";

                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                Console.WriteLine("Your Pin is Created successfully");

            }
            cnn.Close();
        }

        private bool checkatm(string id)
        {
            //checking data is also here or not
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string check_User_pass = "Select * from atmdetail where id = '" + id + "'";
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
                    Console.WriteLine("Your ATM pin is not created");
                    Console.ReadKey();
                    return false;
                }


            }
            cnn.Close();
            return false;
        }

        private bool checkatmpin(string id, string atmpin)
        {

            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string check_User_pass = "Select * from atmdetail where id = '" + id + "' and atmpin = '" + atmpin + "'";
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
                    Console.WriteLine("Please Enter correct atmpin");
                    Console.ReadKey();
                    return false;
                }


            }
            cnn.Close();
            return false;
        }

        private void CreateTableIfNotExists()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'atmdetail') " +
                        "CREATE TABLE atmdetail ( id nvarchar, atmpin nvarchar)";

                    command.ExecuteNonQuery();

                }
            }
            cnn.Close();
        }
    }
}
