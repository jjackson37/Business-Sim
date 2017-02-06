using System;

namespace Business_Sim
{
    /// <summary>
    /// Console UI
    /// </summary>
    internal class Menu
    {
        #region Fields

        /// <summary>
        /// Currently loaded game
        /// </summary>
        private Game game;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Prints main menu selection into console for the user and calls game functions depending on user input
        /// </summary>
        public void MainMenuSelection()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("-BUSINESS SIM-\n1-New business\n2-Load business\n" +
                    "3-Business help\n4-Quit\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Write("    What difficulty?\n    1-vEasy\n    2-Easy\n    3-Normal\n    4-Hard\n    5-vHard\n    6-Extreme\n    ");
                        Game.Difficulty difficultyInput = Game.Difficulty.Unknown;
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                difficultyInput = Game.Difficulty.vEasy;
                                break;

                            case '2':
                                difficultyInput = Game.Difficulty.Easy;
                                break;

                            case '3':
                                difficultyInput = Game.Difficulty.Normal;
                                break;

                            case '4':
                                difficultyInput = Game.Difficulty.Hard;
                                break;

                            case '5':
                                difficultyInput = Game.Difficulty.vHard;
                                break;

                            case '6':
                                difficultyInput = Game.Difficulty.Extreme;
                                break;

                            case '7':
                                difficultyInput = Game.Difficulty.Dev;
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                PressKeyAndClear();
                                break;
                        }
                        if (difficultyInput != Game.Difficulty.Unknown)
                        {
                            game = new Game(difficultyInput);
                            Console.Clear();
                            GameMenu();
                        }
                        break;

                    case '2':
                        Console.WriteLine("Amazing load placeholder!");
                        PressKeyAndClear();
                        //TODO: Load save file function
                        break;

                    case '3':
                        Console.WriteLine("Amazing help placeholder!");
                        PressKeyAndClear();
                        //TODO: Help menu function
                        break;

                    case '4':
                        Console.WriteLine("Goodbye");
                        PressKeyAndClear();
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        PressKeyAndClear();
                        break;
                }
            }
        }

        /// <summary>
        /// Clears console after the user presses a key
        /// </summary>
        public void PressKeyAndClear()
        {
            Console.ReadKey(true);
            Console.Clear();
        }

        /// <summary>
        /// Prints buildings menu and calls buildings functions depending on user input
        /// </summary>
        private void BuildingsMenu()
        {
            Console.Write("    -Properties-\n    1-Buy\n    2-Sell\n    3-Upgrade\n    4-View owned properties\n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("        -Buy-\n        1-Flat (10000)\n        2-House (20000)\n        3-Shop (50000)\n        4-Flat Block (100000)\n"
                        + "        5-Office (150000)\n        6-Shopping centre (500000)\n        7-Office block (1500000)\n        8-Sky scraper (2500000)\n");

                    Building.BuildingType buildingTypeToBuy = SelectBuildingType(2);
                    if (buildingTypeToBuy != Building.BuildingType.Unknown)
                    {
                        game.cash = game.assets.Add(buildingTypeToBuy, game.cash);
                        PressKeyAndClear();
                    }
                    break;

                case '2':
                    Console.Write("        -Sell-\n        1-Flat\n        2-House\n        3-Shop\n        4-Flat Block\n"
                        + "        5-Office\n        6-Shopping centre\n        7-Office block\n        8-Sky scraper\n");
                    Building.BuildingType buildingTypeToSell = SelectBuildingType(2);
                    if (!buildingTypeToSell.Equals(Building.BuildingType.Unknown))
                    {
                        Building buildingToSell = game.assets.Find(buildingTypeToSell);
                        if (buildingToSell != null)
                        {
                            game.cash += game.assets.Remove(buildingToSell);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '3':
                    Console.Write("        -Upgrade-\n        1-Flat\n        2-House\n        3-Shop\n        4-Flat Block\n"
                        + "        5-Office\n        6-Shopping centre\n        7-Office block\n        8-Sky scraper\n");
                    Building.BuildingType buildingTypeToUpgrade = SelectBuildingType(2);
                    if (!buildingTypeToUpgrade.Equals(Building.BuildingType.Unknown))
                    {
                        Building buildingToUpgrade = game.assets.Find(buildingTypeToUpgrade);
                        if (buildingToUpgrade != null)
                        {
                            game.cash = game.assets.Upgrade(buildingToUpgrade, game.cash);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '4':
                    game.assets.ViewBuildings();
                    PressKeyAndClear();
                    break;

                default:
                    Console.WriteLine("    Invalid input");
                    PressKeyAndClear();
                    break;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void EmployeesMenu()
        {
            Console.Write("    -Employees-\n    1-Hire\n    2-Fire\n    3-View current employees\n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("        -Hire-\n        1-Worker (50)\n        2-Manager (500)\n        3-Regional manager (10000)\n"
                        + "        4-Administrator (1000000)\n        5-Director (25000000)\n");

                    Employee.EmployeeType employeeTypeToBuy = SelectEmployeeType(2);
                    if (employeeTypeToBuy != Employee.EmployeeType.Unknown)
                    {
                        game.cash = game.assets.Add(employeeTypeToBuy, game.cash);
                        PressKeyAndClear();
                    }
                    break;

                case '2':
                    Console.Write("        -Sell-\n        1-Worker\n        2-Manager\n        3-Regional manager\n        4-Administrator\n"
                        + "        5-Director\n");
                    Employee.EmployeeType employeeTypeToFire = SelectEmployeeType(2);
                    if (!employeeTypeToFire.Equals(Employee.EmployeeType.Unknown))
                    {
                        Employee employeeToFire = game.assets.Find(employeeTypeToFire);
                        if (employeeToFire != null)
                        {
                            game.assets.Remove(employeeToFire);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '3':
                    game.assets.ViewEmployees();
                    PressKeyAndClear();
                    break;

                default:
                    Console.WriteLine("    Invalid input");
                    PressKeyAndClear();
                    break;
            }
        }

        /// <summary>
        /// Main menu, calls other menus depending on user input
        /// </summary>
        private void GameMenu()
        {
            bool inGame = true;
            while (inGame)
            {
                Console.Write("-Business Sim-\nDate:" + game.date.currentDateString + "\nCash:" + game.cash + "\n");
                Console.Write("1-Properties\n2-Employees\n3-Next day\n4-Exit to main menu\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        BuildingsMenu();
                        break;

                    case '2':
                        EmployeesMenu();
                        break;

                    case '3':
                        game.cash += game.date.Progress(1, game.assets.income, game.assets.outcome);
                        Console.WriteLine("Next day...");
                        PressKeyAndClear();
                        break;

                    case '4':
                        inGame = false;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        PressKeyAndClear();
                        break;
                }
            }
        }

        /// <summary>
        /// Gets user to select a building type
        /// </summary>
        /// <param name="indentSize">Number of indents for printed text</param>
        /// <returns>Building type selected by user</returns>
        private Building.BuildingType SelectBuildingType(int indentSize)
        {
            string indent = "";
            for (int i = 0; i != indentSize; i++)
            {
                indent += "    ";
            }
            Building.BuildingType returnValue = Building.BuildingType.Unknown;
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    returnValue = Building.BuildingType.Flat;
                    break;

                case '2':
                    returnValue = Building.BuildingType.House;
                    break;

                case '3':
                    returnValue = Building.BuildingType.Shop;
                    break;

                case '4':
                    returnValue = Building.BuildingType.FlatBlock;
                    break;

                case '5':
                    returnValue = Building.BuildingType.Office;
                    break;

                case '6':
                    returnValue = Building.BuildingType.ShoppingCentre;
                    break;

                case '7':
                    returnValue = Building.BuildingType.OfficeBlock;
                    break;

                case '8':
                    returnValue = Building.BuildingType.SkyScraper;
                    break;

                default:
                    Console.WriteLine(indent + "Invalid input");
                    PressKeyAndClear();
                    break;
            }
            return returnValue;
        }

        /// <summary>
        /// Gets user to select a employee type
        /// </summary>
        /// <param name="indentSize">Number of indents for printed text</param>
        /// <returns>Employee type selected by user</returns>
        private Employee.EmployeeType SelectEmployeeType(int indentSize)
        {
            string indent = "";
            for (int i = 0; i != indentSize; i++)
            {
                indent += "    ";
            }
            Employee.EmployeeType returnValue = Employee.EmployeeType.Unknown;
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    returnValue = Employee.EmployeeType.Worker;
                    break;
                case '2':
                    returnValue = Employee.EmployeeType.Manager;
                    break;
                case '3':
                    returnValue = Employee.EmployeeType.RegionalManager;
                    break;
                case '4':
                    returnValue = Employee.EmployeeType.Administrator;
                    break;
                case '5':
                    returnValue = Employee.EmployeeType.Director;
                    break;
                default:
                    returnValue = Employee.EmployeeType.Unknown;
                    break;
            }
            return returnValue;
        }

        #endregion Methods
    }
}