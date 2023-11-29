using Microsoft.Data.SqlClient;
using RenatuscapabaseLibrary.TableComponents;
using System.Threading.Channels;

namespace RenatuscapabaseLibrary
{
    public static class CommandManager
    {
        public static void Connect(string userCommand)
        {
            DbConnect dbConnect = new();

            try
            {
                dbConnect.OpenConnection(out var command, out var connection);

                if (userCommand == "0")
                {
                    SqlRepository.CreateTable(command);
                }
                else if (userCommand == "1")
                {
                    SqlRepository.DropTable(command);
                }
                else if (userCommand == "2")
                {
                    Console.WriteLine("Which table would you like to add a column to?");
                    string tableName = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    Console.WriteLine();
                    TableColumn newColumn = ColumnFactory.CreateColumn();
                    SqlRepository.AddColumn(command, tableName, newColumn);
                    Console.WriteLine();
                    Console.WriteLine(newColumn);
                }
                else if (userCommand == "3")
                {
                    Console.WriteLine("Which table would you like to get?");
                    string tableName = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    Console.WriteLine();
                    var toPrint = SqlRepository.GetTable(command, tableName);
                    Console.WriteLine(toPrint);
                }
                else if (userCommand == "4")
                {
                    Console.WriteLine("Change column in which table?");
                    string tableName = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    Console.WriteLine("Which column?");
                    string columnName = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    Console.WriteLine("Enter new data");
                    string newData = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    Console.WriteLine("Enter row ID");
                    int rowID = Convert.ToInt32(InputValidation.SanitiseName(Console.ReadLine() ?? ""));
                    SqlRepository.UpdateColumn(command, tableName, columnName, rowID, newData);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
