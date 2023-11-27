using RenatuscapabaseLibrary;
using System.Data.Common;

namespace RenatuscapabaseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbConnector.Connect();
        }
    }
}
