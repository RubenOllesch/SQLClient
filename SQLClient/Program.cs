using System;
using System.Data;
using System.Data.SqlClient;

namespace SQLClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=tappqa;Database=Training-RE-CompanyDB;Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM viEmployee", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Display display = new Display();
                    display.Table(reader);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
