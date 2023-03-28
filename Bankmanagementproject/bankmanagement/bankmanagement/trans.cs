using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankmanagement
{
    class trans
    {
        public void highestWd()
        {
            Console.WriteLine("\nEnter from date:");
            DateTime fromDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter to date:");
            DateTime toDate = DateTime.Parse(Console.ReadLine());

            string connetionString;
            SqlConnection cnn;
            string accNum = "";
            double total_withdrawal;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT TOP 1 accNum, SUM(transAmt) as total_withdrawal FROM trans WHERE transType = 'wd' AND Date BETWEEN @fromDate AND @toDate GROUP BY accNum ORDER BY total_withdrawal DESC";
                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    accNum = reader["accNum"].ToString();
                    total_withdrawal = Convert.ToDouble(reader["total_withdrawal"].ToString());
                    Console.WriteLine("\nAccount ID: {0} \nTotal Withdrawal: {1}", reader["accNum"], reader["total_withdrawal"]);
                }
                else
                {
                    Console.WriteLine("No results found.");
                }

                reader.Close();
                cnn.Close();
            }
        }

        public void highestDep()
        {
            Console.WriteLine("\nEnter from date:");
            DateTime fromDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter to date:");
            DateTime toDate = DateTime.Parse(Console.ReadLine());

            string connetionString;
            SqlConnection cnn;
            string accNum = "";
            double total_deposit;
            connetionString = Constants.localconnectionstring;
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT TOP 1 accNum, SUM(transAmt) as total_deposit FROM trans WHERE transType = 'dep' AND Date BETWEEN @fromDate AND @toDate GROUP BY accNum ORDER BY total_deposit DESC";
                SqlCommand cmd = new SqlCommand(q, cnn);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    accNum = reader["accNum"].ToString();
                    total_deposit = Convert.ToDouble(reader["total_deposit"].ToString());
                    Console.WriteLine("\nAccount ID: {0} \nTotal Deposit: {1}", reader["accNum"], reader["total_deposit"]);
                }
                else
                {
                    Console.WriteLine("No results found.");
                }

                reader.Close();
                cnn.Close();
            }
        }
    }
}
