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
                    TableColumn newColumn = ColumnFactory.CreateColumn();
                    Console.WriteLine("Which table would you like to add a column to?");
                    string tableName = InputValidation.SanitiseName(Console.ReadLine() ?? "");
                    SqlRepository.AddColumn(command, "TestTable", newColumn);
                    Console.WriteLine(newColumn);
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
