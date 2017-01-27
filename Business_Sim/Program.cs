namespace Business_Sim
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WindowWidth = 100;
            Menu mainMenu = new Menu();
            mainMenu.MainMenuSelection();
        }
    }
}