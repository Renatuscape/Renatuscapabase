using Microsoft.Data.SqlClient;
using RenatuscapabaseLibrary.TableComponents;

namespace RenatuscapabaseLibrary
{
    public static class SqlRepository
    {
        public static void CreateTable(SqlCommand command)
        {
            Console.WriteLine("Please enter new table name:");
            string? tableName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                Console.WriteLine("No name found. New table named 'TestTable'.");
                tableName = "TestTable";
            }

            command.CommandText = $"CREATE TABLE {InputValidation.SanitiseName(tableName)} (\n" +
                                   "Id INT IDENTITY(1,1) PRIMARY KEY\n" +
                                   ");";

            command.Parameters.AddWithValue("@tableName", tableName);
            Console.WriteLine($"Debug CreateTable():\n{command.CommandText}");

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }

        public static void DropTable(SqlCommand command)
        {
            Console.WriteLine("Please enter name of table to drop:");

            string? tableName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                Console.WriteLine("Please enter a valid name.");
                command.CommandText = "";
            }
            else
            {
                command.CommandText = $"DROP TABLE {InputValidation.SanitiseName(tableName)}";
            }

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }

        public static string GetTable(string tableName)
        {
            throw new NotImplementedException();
        }

        public static string GetAllTables(string tableName)
        {
            throw new NotImplementedException();
        }

        public static void AddColumn(SqlCommand command, string tableName, TableColumn column)
        {
            command.CommandText =  $"ALTER TABLE {InputValidation.SanitiseName(tableName)} \n";
            command.CommandText += $"ADD {InputValidation.SanitiseName(column.ColumnName)} {column.DataType}({column.DataLength})";

            Console.WriteLine($"Debug SQL:\n{command.CommandText}");
            Console.WriteLine();
            Console.WriteLine("Column successfully added.");
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }

        public static void AddAllColumns(SqlCommand command, string tableName, List<TableColumn> columns)
        {
            foreach (TableColumn column in  columns) {
                AddColumn(command, tableName, column);
            }
        }
    }
}
