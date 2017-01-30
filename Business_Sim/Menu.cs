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
        private Game currentGame;

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

                            default:
                                Console.WriteLine("Invalid input");
                                PressKeyAndClear();
                                break;
                        }
                        if (difficultyInput != Game.Difficulty.Unknown)
                        {
                            currentGame = new Game(difficultyInput);
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
                    Console.Write("        -Buy-\n        1-Flat (1000)\n        2-House (2000)\n        3-Shop (5000)\n        4-Flat Block (10000)\n"
                        + "        5-Office (15000)\n        6-Shopping centre (50000)\n        7-Office block (150000)\n        8-Sky scraper (250000)\n");

                    Building.BuildingType buildingTypeToBuy = SelectBuildingType(2);
                    if (buildingTypeToBuy != Building.BuildingType.Unknown)
                    {
                        currentGame.cash = currentGame.gameAssets.Add(buildingTypeToBuy, currentGame.cash);
                        PressKeyAndClear();
                    }
                    break;

                case '2':
                    Console.Write("        -Sell-\n        1-Flat\n        2-House\n        3-Shop\n        4-Flat Block\n"
                        + "        5-Office\n        6-Shopping centre\n        7-Office block\n        8-Sky scraper\n");
                    Building.BuildingType buildingTypeToSell = SelectBuildingType(2);
                    if (!buildingTypeToSell.Equals(Building.BuildingType.Unknown))
                    {
                        Building buildingToSell = currentGame.gameAssets.Find(buildingTypeToSell);
                        if (buildingToSell != null)
                        {
                            currentGame.cash += currentGame.gameAssets.Remove(buildingToSell);
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
                        Building buildingToUpgrade = currentGame.gameAssets.Find(buildingTypeToUpgrade);
                        if (buildingToUpgrade != null)
                        {
                            currentGame.cash = currentGame.gameAssets.Upgrade(buildingToUpgrade,currentGame.cash);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '4':
                    currentGame.gameAssets.ViewBuildings();
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
            Console.WriteLine("Amazing employee menu placeholder!");
            PressKeyAndClear();
        }

        /// <summary>
        /// Main menu, calls other menus depending on user input
        /// </summary>
        private void GameMenu()
        {
            bool inGame = true;
            while (inGame)
            {
                Console.Write("-Business Sim-\nDate:" + currentGame.currentDate.ToShortDateString() + "\nCash:" + currentGame.cash + "\n");
                Console.Write("1-Properties\n2-Employees\n3-Next day\n4-Exit to main menu\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        BuildingsMenu();
                        break;

                    case '2':
                        EmployeesMenu(); //TODO
                        break;

                    case '3':
                        Console.WriteLine("The next day... jk placeholder");
                        PressKeyAndClear();
                        //TODO: Calculate costs and profits for day
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

        #endregion Methods
    }
}