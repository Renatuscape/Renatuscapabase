namespace RenatuscapabaseLibrary
{
    public class UserInterface
    {
        public void Initialise()
        {
            while (true)
            {
                Console.WriteLine("Choose operation");
                Console.WriteLine("\n[0] Create table" +
                                  "\n[1] Drop table" +
                                  "\n[2] Add column" +
                                  "\n[3] Get table" +
                                  "\n[4] Update column" +
                                  "\n[X] Exit");

                string userCommand = Console.ReadKey().KeyChar.ToString() ?? "";
                Console.WriteLine();

                if (userCommand.ToLower() == "x")
                {
                    break;
                }
                CommandManager.Connect(userCommand);
            }
        }
    }
}
