using Microsoft.Data.SqlClient;

namespace RenatuscapabaseLibrary
{
    public class DbConnect
    {
        private string DataBaseName {  get; }
        private string ServerAddress { get; }
        private string ConnectionString { get; }

        public DbConnect(string dataBaseName = "Renatuscapabase", string serverAddress = @"(localdb)\MSSQLLocalDB")
        {
            DataBaseName = dataBaseName;
            ServerAddress = serverAddress;

            ConnectionString = $"Server = {ServerAddress};";
            ConnectionString += $"\nDatabase = {DataBaseName}\n;";
            ConnectionString += @"Integrated Security = true;";
        }
        public SqlConnection CreateConnection()
        {
            return new(ConnectionString);
        }

        public void OpenConnection(out SqlCommand command, out SqlConnection connection)
        {
            connection = CreateConnection();
            command = connection.CreateCommand();
            connection.Open();
        }
    }
}
