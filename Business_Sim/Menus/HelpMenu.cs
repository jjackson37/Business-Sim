using System;

namespace Business_Sim
{
    internal class HelpMenu : Menu
    {
        #region Methods

        public void RunMenu()
        {
            bool inHelpMenu = true;
            while (inHelpMenu)
            {
                Console.Clear();
                Console.WriteLine("-HELP-\n1-Buildings\n2-Employees\n3-Back");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        //TODO: Buildings help
                        BuildingsHelp();
                        break;

                    case '2':
                        //TODO: Employees help
                        EmployeesHelp();
                        break;

                    case '3':
                        inHelpMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        PressKeyAndClear();
                        break;
                }
            }
        }

        private void BuildingsHelp()
        {
            bool inBuildingsHelp = true;
            while (inBuildingsHelp)
            {
                Console.Clear();
                Console.WriteLine("-BUILDING HELP-\n1-Buying & selling\n2-Income, outcome & upgrading\n3-Back");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.WriteLine(Properties.Resources.BuildingBuySellHelp);
                        PressKeyAndClear();
                        break;
                    case '2':
                        break;
                    case '3':
                        inBuildingsHelp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        PressKeyAndClear();
                        break;
                }
            }
        }

        private void EmployeesHelp()
        {
            bool inEmployeesHelp = true;
            while (inEmployeesHelp)
            {
                Console.Clear();
                Console.WriteLine("-EMPLOYEE HELP-\n1-WIP\n2-WIP\n3-Back");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '3':
                        inEmployeesHelp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        PressKeyAndClear();
                        break;
                }
            }
        }

        #endregion Methods
    }
}