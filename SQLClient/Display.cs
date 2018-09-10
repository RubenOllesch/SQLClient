using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLClient
{
    class Display
    {
        int consoleHeight;
        int consoleWidth;
        public Display()
        {
            consoleHeight = Console.WindowHeight;
            consoleWidth = Console.WindowWidth;
        }

        public void Table(SqlDataReader reader)
        {
            DataTable table = reader.GetSchemaTable();
            int tableWidth = table.MinimumCapacity;
            for (int i = 0; i < 5; i++)
            {
                List<string> columnNames = new List<string>();
                for (int j = 0; j < tableWidth; j++)
                {
                    columnNames.Add(table.Select()[j].ItemArray[i].ToString());
                }
                Console.WriteLine(BuildRow(columnNames));
                //Console.WriteLine(HorizontalLine());
            }
        }

        private string BuildRow(List<string> items)
        {
            int width = (consoleWidth - 1 - items.Count) / items.Count;
            string row = "|";
            foreach (string column in items)
            {
                row += PaddString(column, width) + "|";
            }
            return row; 
        }

        private string PaddString(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        private string HorizontalLine()
        {
            string line = "";
            for (int i = 0; i < consoleWidth; i++)
            {
                line += "─";
            }
            return line;
        }
    }
}
