using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Sim
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            System.Console.WindowWidth = 94;
            Menu mainMenu = new Menu();
            mainMenu.MainMenuSelection();
        }

        #endregion Methods
    }
}