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
                            case "help":
                                Help();
                                break;
                            case "view":
                                View(inputArray[1], connection);
                                break;
                            case "cor":
                                CreateOrReplace(inputArray[1], inputArray, connection);
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

        static void Help()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine(" help");
            Console.WriteLine(" view <table>");
            Console.WriteLine(" cor <table> [param=value]");

        }

        static void View(string table, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM vi{table}", connection);
            DataTable resultTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(resultTable);
            Display.Print(resultTable);
        }

        static void CreateOrReplace(string table, string[] parameters, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand($"spCrRe{table}", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 2; i < parameters.Length; i++)
            {
                string[] param = parameters[i].Split('=');
                if (param[1] == "NULL")
                {
                    cmd.Parameters.AddWithValue(param[0], DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(param[0], param[1]);
                }
            }
            cmd.ExecuteNonQuery();
        }
    }
}
