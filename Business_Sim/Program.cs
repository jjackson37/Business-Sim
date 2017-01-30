namespace Business_Sim
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            System.Console.WindowWidth = 125;
            Menu mainMenu = new Menu();
            mainMenu.MainMenuSelection();
        }

        #endregion Methods
    }
}