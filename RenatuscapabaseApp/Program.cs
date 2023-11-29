using RenatuscapabaseLibrary;
using System.Data.Common;

namespace RenatuscapabaseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new();
            userInterface.Initialise();
        }
    }
}
