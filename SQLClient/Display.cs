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

        public void Print(DataTable table)
        {
            List<string> columnNames = new List<string>();
            foreach (DataColumn column in table.Columns)
            {
                columnNames.Add(column.ColumnName);
            }
            PrintRow(columnNames);

            PrintHorizontalLine();

            foreach (DataRow row in table.Rows)
            {
                List<string> rowValues = new List<string>();
                foreach (object item in row.ItemArray)
                {
                    rowValues.Add(item.ToString());
                }
                PrintRow(rowValues);
            }
        }

        private void PrintRow(List<string> items)
        {
            int columnWidth = consoleWidth / items.Count;
            string row = "";
            foreach (string column in items)
            {
                row += PaddStringLeft(column, columnWidth);
            }
            Console.WriteLine(row);
        }

        private string PaddStringCenter(string text, int width)
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

        private string PaddStringLeft(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width);
            }
        }

        private void PrintHorizontalLine()
        {
            string line = "";
            for (int i = 0; i < consoleWidth; i++)
            {
                line += "─";
            }
            Console.WriteLine(line);
        }
    }
}
