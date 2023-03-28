using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bankmanagement
{
    static class Constants
    {
        //******************** Here Your local Microsoft SQL server connection string *********************************
        public const string localconnectionstring = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
    }
    class Bank
    {

        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myAccType = new string[100];
        public string[] myName = new string[100];
        public string[] myDob = new string[100];
        public string[] myNominee = new string[100];
        public double[] myBalance = new double[100];

        IdGenerate Id = new IdGenerate();
        Dob dob = new Dob();
        Current cr = new Current();
        Saving sv = new Saving();

        public bool val = true;
        public bool debval = true;

        private void GetAcc(string ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;

        }

        public void createaccount()
        {
            Console.Clear();

            string acctype;
            string input;
            string name;
            int d, m, y;
            string nominee;
            double balance;

            //Account Creation
            Console.WriteLine("1. Saving Account");
            Console.WriteLine("2. Current Account");
            input = Console.ReadLine();

            if (input == "1")
            {
                // Savings Account
                acctype = "Saving";
                myAccType[idnum] = acctype;
                Console.WriteLine("Name : ");
                name = Console.ReadLine();
                myName[idnum] = name;

                while (val == true)
                {
                    string dd, mm, yy;
                    Console.Write("\nEnter Dob Date : \nEnter date (dd) format : ");
                    dd = Console.ReadLine();
                    Console.Write("\nEnter month(mm) format : ");
                    mm = Console.ReadLine();
                    Console.Write("\nEnter month(yyyy) format : ");
                    yy = Console.ReadLine();

                    if (checkdatainteger(dd, mm, yy))
                    {
                        d = Convert.ToInt32(dd);
                        m = Convert.ToInt32(mm);
                        y = Convert.ToInt32(yy);
                        dob.set(d, m, y);
                        if (dob.printDate() == true)
                        {
                            myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                            val = false;
                        }
                    }
                    else val = true;
                }

                val = true;
                Console.WriteLine("Enter Nominee Name : ");
                nominee = Console.ReadLine();
                myNominee[idnum] = nominee;

                while (debval == true)
                {
                    string bal;
                    Console.WriteLine("Enter Account Balance : ");
                    bal = Console.ReadLine();

                    if (checkdatadouble(bal))
                    {
                        balance = Convert.ToDouble(bal);
                        if (balance < 2000)
                        {
                            Console.WriteLine("Please add minimum account balance 2000!");
                            debval = true;
                        }
                        else
                        {
                            myBalance[idnum] = balance;
                            debval = false;
                        }
                    }

                }

                debval = true;
                id = Id.Generate();
                id = id + "sav";

                dbcreate(id, myAccType[idnum], myName[idnum], myDob[idnum], myNominee[idnum], myBalance[idnum]);
                Console.WriteLine("\n \t Loading...");
                Thread.Sleep(2000);

                Console.WriteLine("Created Saving account Successfully...!");
                Console.WriteLine("Your account number is : " + id);
                //getaccount details
                GetAcc(id);
            }

            else if (input == "2")
            {
                // current account
                acctype = "Current";
                myAccType[idnum] = acctype;
                Console.WriteLine("Name : ");
                name = Console.ReadLine();
                myName[idnum] = name;

                while (val == true)
                {
                    string dd, mm, yy;
                    Console.Write("Enter Dob Date : \nEnter date (dd) format : ");
                    dd = Console.ReadLine();
                    Console.Write("\nEnter month(mm) format : ");
                    mm = Console.ReadLine();
                    Console.Write("\nEnter month(yyyy) format : ");
                    yy = Console.ReadLine();

                    if (checkdatainteger(dd, mm, yy))
                    {
                        d = Convert.ToInt32(dd);
                        m = Convert.ToInt32(mm);
                        y = Convert.ToInt32(yy);
                        dob.set(d, m, y);
                        if (dob.printDate() == true)
                        {
                            myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                            val = false;
                        }
                    }
                    else val = true;
                }

                val = true;
                Console.WriteLine("Enter Nominee Name : ");
                nominee = Console.ReadLine();
                myNominee[idnum] = nominee;

                while (debval == true)
                {
                    Console.WriteLine("Enter Account Balance : ");
                    string bal = Console.ReadLine();

                    if (checkdatadouble(bal))
                    {
                        balance = Convert.ToDouble(bal);
                        if (balance < 25000)
                        {
                            Console.WriteLine("Please add minimum account balance 25000!");
                            debval = true;
                        }
                        else
                        {
                            myBalance[idnum] = balance;
                            debval = false;
                        }
                    }
                    debval = true;
                }


                id = Id.Generate();
                id = id + "cur";

                dbcreate(id, myAccType[idnum], myName[idnum], myDob[idnum], myNominee[idnum], myBalance[idnum]);
                Console.WriteLine("\n \t Loading...");
                Thread.Sleep(2000);

                Console.WriteLine("Created Current account Successfully...!");
                Console.WriteLine("Your account number is : " + id);
                //getaccount 
                GetAcc(id);
            }

            else
            {
                Console.WriteLine("Please Enter valid input ");
            }
            Console.ReadKey();
        }

        public void showinfo()
        {
            //Required account info

            Console.WriteLine("Please Enter id : ");
            string inId = Console.ReadLine();

            if (checkdb(inId))
            {
                getidrecord(inId);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }
        }

        public void deposit()
        {
            //Deposit money

            string inId = Console.ReadLine();

            if (checkdb(inId))
            {

                Console.WriteLine("How much you want to deposit : ");
                string checkdata = Console.ReadLine();
                double depositval;

                if (checkdatadouble(checkdata))
                {
                    depositval = Convert.ToDouble(checkdata);
                    string accounttype = getacctype(inId);
                    string Name = getname(inId);
                    double accountbalance = getbalance(inId);

                    double updatedbalance = 0;
                    if (accounttype == "Saving")
                    {
                        transTable(inId, accounttype, Name, depositval, "dep");
                        sv.balance = accountbalance;
                        sv.deposit(depositval);
                        updatedbalance = sv.balance;

                    }
                    else if (accounttype == "Current")
                    {
                        transTable(inId, accounttype, Name, depositval, "dep");
                        cr.balance = accountbalance;
                        cr.deposit(depositval);
                        updatedbalance = cr.balance;

                    }

                    dbupdate(inId, updatedbalance);
                }

            }
            else
            {
                Console.WriteLine("Account id is wrong!");
            }
        }

        public void withdraw()
        {
            //WithDraw Money

            string inId = Console.ReadLine();

            if (checkdb(inId))
            {
                double withdrawval = 0;
                Console.WriteLine("How much you want to withdraw : ");

                string checkdata = Console.ReadLine();
                if (checkdatadouble(checkdata))
                {
                    withdrawval = Convert.ToDouble(checkdata);
                    string Name = getname(inId);
                    string accounttype = getacctype(inId);
                    double accountbalance = getbalance(inId);

                    double updatedbalance = 0;
                    if (accounttype == "Saving")
                    {
                        transTable(inId, accounttype, Name, withdrawval, "wd");
                        sv.balance = accountbalance;
                        sv.withdraw(withdrawval);
                        updatedbalance = sv.balance;

                    }
                    else if (accounttype == "Current")
                    {
                        transTable(inId, accounttype, Name, withdrawval, "wd");
                        cr.balance = accountbalance;
                        cr.withdraw(withdrawval);
                        updatedbalance = cr.balance;

                    }

                    dbupdate(inId, updatedbalance);
                }

            }
            else
            {
                Console.WriteLine("Account id is wrong!");
            }
        }

        public void showall()
        {
            //show all accounts
            getrecord();
        }

        // db creation------------------------------------------------------------------
        public void dbcreate(string id, string acctype, string name, string dob, string nominee, double balance)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //Create table if not exist
            CreateTableIfNotExists();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "Insert into accountdetail(id,acctype,name,dob,Nominee,Balance) values ('" + id + "','" + acctype + "','" + name + "','" + dob + "','" + nominee + "','" + balance + "')";

                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Values inserted");
            }
            cnn.Close();
        }

        public void dbupdate(string id, double balance)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "update accountdetail set balance = '" + balance + "' where id = '" + id + "'";

                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Updated Values");
            }
            cnn.Close();
        }

        public bool checkdb(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM accountdetail WHERE ([id] = '" + id + "')", cnn);
                //check_User_Name.Parameters.AddWithValue("@user", txtBox_UserName.Text);
                int UserExist = (int)check_User_Name.ExecuteScalar();

                if (UserExist > 0)
                {
                    //Username exist
                    return true;
                }
                else
                {
                    //Username doesn't exist.
                    return false;
                }
                //Console.WriteLine("Updated Values");
            }
            cnn.Close();
            return false;

        }

        public void getrecord()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "select * from accountdetail";

                SqlCommand cmd = new SqlCommand(q, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();

                Console.WriteLine("All account details are: \n");
                while (sdr.Read())
                {
                    Console.Write(sdr["id"].ToString() + "          ");
                    Console.Write(sdr["acctype"].ToString() + "          ");
                    Console.WriteLine(sdr["name"].ToString());
                }

            }
            cnn.Close();
        }

        public void getidrecord(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "select * from accountdetail where id = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(q, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    Console.WriteLine("Account details are: \n");

                    Console.WriteLine(sdr["id"].ToString());
                    Console.WriteLine(sdr["acctype"].ToString());
                    Console.WriteLine(sdr["name"].ToString());
                    Console.WriteLine(sdr["dob"].ToString());
                    Console.WriteLine(sdr["nominee"].ToString());
                    Console.WriteLine(sdr["balance"].ToString());
                }

            }
            cnn.Close();
        }

        private string getacctype(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string accounttype = "";
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "select * from accountdetail where id = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(q, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    accounttype = sdr["acctype"].ToString();
                }

            }
            cnn.Close();
            return accounttype;
        }

        private double getbalance(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            double accountbalance = 0;
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "select * from accountdetail where id = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(q, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    accountbalance = Convert.ToDouble(sdr["balance"].ToString());
                }

            }
            cnn.Close();


            return accountbalance;
        }

        private string getname(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string name = "";
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "select * from accountdetail where id = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(q, cnn);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    name = sdr["name"].ToString();
                }

            }
            cnn.Close();
            return name;
        }

        public void transTable(string id, string acctype, string name, double balance, string transtype)
        {
            string accType = acctype;
            string accNum = id;
            string transType = transtype;
            double transAmt = balance;
            DateTime Date = DateTime.Now;

            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("Insert into trans(accType, accNum, name, transType, transAmt, Date) values(@accType, @accNum, @name, @transType, @transAmt, @Date)", cnn);
                cmd.Parameters.AddWithValue("@accType", accType);
                cmd.Parameters.AddWithValue("@accNum", accNum);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@transType", transType);
                cmd.Parameters.AddWithValue("@transAmt", transAmt);
                cmd.Parameters.AddWithValue("@Date", Date);

                cmd.ExecuteNonQuery();
            }
            cnn.Close();
        }

        //Check data or table is right or wrong --------------------------------------------------
        private void CreateTableIfNotExists()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'accountdetail') " +
                        "CREATE TABLE accountdetail ( id nvarchar, acctype nvarchar, name nvarchar, dob varchar,nominee varchar, balance decimal)";

                    command.ExecuteNonQuery();

                }
            }
            cnn.Close();
        }

        public bool checkdatadouble(string data)
        {
            try
            {
                double withdrawval = Convert.ToDouble(data);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter valid input."); // or other default value as appropriate in context.
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool checkdatainteger(string data1, string data2, string data3)
        {
            try
            {
                int date = Convert.ToInt32(data1);
                int month = Convert.ToInt32(data2);
                int year = Convert.ToInt32(data3);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter valid date input."); // or other default value as appropriate in context.
                Console.ReadKey();
                return false;
            }
            return true;
        }

    }
}
