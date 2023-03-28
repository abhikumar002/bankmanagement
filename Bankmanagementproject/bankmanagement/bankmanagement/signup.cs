using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class signup
    {
        public void dbbranchcreate(string bankname, string branchcode, string username, string password)
        {
            //create branch
            string connetionString;
            SqlConnection cnn;
            connetionString = "Data Source=42GBHOLAP0210\\SQLEXPRESS;Initial Catalog=BANK;Persist Security Info=True;User ID=sa;Password=42Gears@123";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //check if table created or not if not exist then created
            CreateTableIfNotExists();

            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "Insert into branches(bankname,branchcode,username,password) values ('" + bankname + "','" + branchcode + "','" + username + "','" + password + "')";
                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Values inserted");
            }
            cnn.Close();


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
                    command.CommandText = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Branches') " +
                        "CREATE TABLE Branches ( branchname varchar, branchcode varchar, username varchar, password varchar)";
                    command.ExecuteNonQuery();
                }
            }
            cnn.Close();
        }
    }
}
