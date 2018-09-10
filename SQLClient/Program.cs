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
                    while (true)
                    {
                        string input = Console.ReadLine();
                        string[] inputArray = input.Split(' ');
                        switch (inputArray[0])
                        {
                            case "exit":
                            case "q":
                                Environment.Exit(0);
                                break;
                            case "view":
                                SqlCommand cmd = new SqlCommand($"SELECT * FROM vi{inputArray[1]}", connection);

                                DataTable table = new DataTable();

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                da.Fill(table);
                                Display.Print(table);
                                break;
                        }
                    } 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
