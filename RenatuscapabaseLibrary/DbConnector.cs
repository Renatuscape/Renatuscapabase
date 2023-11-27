using Microsoft.Data.SqlClient;

namespace RenatuscapabaseLibrary
{
    public static class DbConnector
    {
        private const string _connectionString = @"Server = (localdb)\MSSQLLocalDB;" +
                                                  "Database = Renatuscapabase;" +
                                                  "Integrated Security = true;";
        public static void Connect()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = connection.CreateCommand();

            try
            {
                connection.Open();
                CreateNewTable(command);

                DropTable(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void CreateNewTable(SqlCommand command)
        {
            command = TableFactory.CreateTable(command);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }

        static void DropTable(SqlCommand command) {
            command = TableFactory.DropTable(command);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }
    }
}
