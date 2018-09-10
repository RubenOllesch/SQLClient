﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLClient
{
    class Display
    {
        static int consoleHeight = Console.WindowHeight;
        static int consoleWidth = Console.WindowWidth;


        public static void Print(DataTable table)
        {
            PrintHorizontalLine(true);

            List<string> columnNames = new List<string>();
            foreach (DataColumn column in table.Columns)
            {
                columnNames.Add(column.ColumnName);
            }
            PrintRow(columnNames);

            PrintHorizontalLine(false);

            foreach (DataRow row in table.Rows)
            {
                List<string> rowValues = new List<string>();
                foreach (object item in row.ItemArray)
                {
                    rowValues.Add(item.ToString());
                }
                PrintRow(rowValues);
            }
            PrintHorizontalLine(true);
        }

        private static void PrintRow(List<string> items)
        {
            int columnWidth = consoleWidth / items.Count;
            string row = "";
            foreach (string column in items)
            {
                row += PaddStringLeft(column, columnWidth);
            }
            Console.WriteLine(row);
        }

        private static string PaddStringCenter(string text, int width)
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

        private static string PaddStringLeft(string text, int width)
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

        private static void PrintHorizontalLine(bool full)
        {
            char line = full ? '─' : '-';
            Console.WriteLine(new String(line, consoleWidth));
        }
    }
}
