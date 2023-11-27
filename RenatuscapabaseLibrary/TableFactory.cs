using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RenatuscapabaseLibrary
{
    public static class TableFactory
    {
        public static SqlCommand CreateTable(SqlCommand sqlCommand)
        {
            Console.WriteLine("Please enter new table name:");
            string? tableName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                Console.WriteLine("No name found. New table named 'TestTable'.");
                tableName = "TestTable";
            }

            sqlCommand.CommandText = $"CREATE TABLE {SanitiseName(tableName)} (\n" +
                                      "Id INT IDENTITY(1,1) PRIMARY KEY\n" +
                                      ");";

            sqlCommand.Parameters.AddWithValue("@tableName", tableName);
            Console.WriteLine($"Debug CreateTable():\n{sqlCommand.CommandText}");
            return sqlCommand;
        }

        public static SqlCommand DropTable(SqlCommand sqlCommand)
        {
            Console.WriteLine("Please enter name of table to drop:");
            string? tableName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                Console.WriteLine("Please enter a valid name.");
                sqlCommand.CommandText = "";
            }
            else
            {
                sqlCommand.CommandText = $"DROP TABLE {SanitiseName(tableName)}";
            }



            return sqlCommand;
        }

        public static string GetTable(string tableName)
        {
            throw new NotImplementedException();
        }

        static string SanitiseName(string text)
        {
            return Regex.Replace(text, @"[^\w]", "");
        }
    }
}
