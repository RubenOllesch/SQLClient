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

                    Display display = new Display();
                    DataTable table = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    display.Print(table);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
