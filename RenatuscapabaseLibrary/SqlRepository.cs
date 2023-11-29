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

        public static string GetTable(SqlCommand command, string tableName)
        {
            command.CommandText = "SELECT* \n";
            command.CommandText += $"FROM {InputValidation.SanitiseName(tableName).Trim()} \n";
            Console.WriteLine("Command debug: "+ command.CommandText);
            string returnText = string.Empty;
            var reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                returnText += $"|{reader.GetName(i)}\t";
            }
            returnText += "\n";

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    returnText += $"|{reader[i]}\t";
                }
                returnText += "\n";
            }

            return returnText;
        }

        public static string GetAllTables(string tableName)
        {
            throw new NotImplementedException();
        }

        public static void AddColumn(SqlCommand command, string tableName, TableColumn column)
        {
            command.CommandText =  $"ALTER TABLE {InputValidation.SanitiseName(tableName)} \n";
            command.CommandText += $"ADD {InputValidation.SanitiseName(column.ColumnName)} {column.DataType}({column.DataLength})";
            if (column.DefaultContent != null)
            {
                command.CommandText += column.DefaultContent;
            }
            command.CommandText += ";";

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

        public static void UpdateColumn(SqlCommand command, string tableName, string columnName, int id, string newContent)
        {
            string commandString =
@"UPDATE [tableName]
SET [columnName] = @newContent
WHERE id = @id";

            commandString = commandString.Replace("[columnName]", InputValidation.SanitiseName(columnName));
            commandString = commandString.Replace("[tableName]", InputValidation.SanitiseName(tableName));
            command.CommandText = commandString;

            command.Parameters.AddWithValue("@newContent", newContent);
            command.Parameters.AddWithValue("@id", id);

            Console.WriteLine(command.CommandText);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }
    }
}
