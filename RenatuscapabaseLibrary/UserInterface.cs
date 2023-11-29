namespace RenatuscapabaseLibrary
{
    public class UserInterface
    {
        public void Initialise()
        {
            while (true)
            {
                Console.WriteLine("Choose operation");
                Console.WriteLine("\n0 Create table" +
                                  "\n1 Drop table" +
                                  "\n2 Add column");

                string userCommand = Console.ReadLine() ?? "";
                CommandManager.Connect(userCommand);
            }
        }
    }
}
