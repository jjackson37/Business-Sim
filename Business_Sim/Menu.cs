using System;

namespace Business_Sim
{
    class Menu
    {
        Game currentGame;

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
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                        }
                        if (difficultyInput != Game.Difficulty.Unknown)
                        {
                            currentGame = new Game(difficultyInput);
                            currentGame.StartGame();
                            Console.Clear();
                            GameMenu();
                        }
                        break;
                    case '2':
                        //TODO: Load save file function
                        break;
                    case '3':
                        //TODO: Help menu function
                        break;
                    case '4':
                        Console.WriteLine("Goodbye");
                        Console.ReadKey(true);
                        Console.Clear();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
        }

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
                        PropertiesMenu();
                        break;
                    case '2':
                        EmployeesMenu(); //TODO
                        break;
                    case '3':
                        //TODO: Calculate costs and profits for day
                        break;
                    case '4':
                        inGame = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
            }
        }

        private void PropertiesMenu()
        {
            Console.Write("    -Properties-\n    1-Buy\n    2-Sell\n    3-Upgrade\n    4-View owned properties\n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("        -Buy\n        1-Flat\n        2-Flat Block\n        3-House\n        4-Office\n"
                        + "        5-Office block\n        6-Shop\n        7-Shopping centre\n        8-Sky scraper\n");
                    Asset.PropertyType propertyTypeToBuy = Asset.PropertyType.Unknown;
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            propertyTypeToBuy = Asset.PropertyType.Flat;
                            break;
                        case '2':
                            propertyTypeToBuy = Asset.PropertyType.FlatBlock;
                            break;
                        case '3':
                            propertyTypeToBuy = Asset.PropertyType.House;
                            break;
                        case '4':
                            propertyTypeToBuy = Asset.PropertyType.Office;
                            break;
                        case '5':
                            propertyTypeToBuy = Asset.PropertyType.OfficeBlock;
                            break;
                        case '6':
                            propertyTypeToBuy = Asset.PropertyType.Shop;
                            break;
                        case '7':
                            propertyTypeToBuy = Asset.PropertyType.ShoppingCentre;
                            break;
                        case '8':
                            propertyTypeToBuy = Asset.PropertyType.SkyScraper;
                            break;
                        default:
                            Console.WriteLine("        Invalid input");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                    }
                    if (propertyTypeToBuy != Asset.PropertyType.Unknown)
                    {
                        currentGame.gameProperties.Add(propertyTypeToBuy); //TODO
                    }
                    break;
                case '2':
                    currentGame.gameProperties.Remove(); //TODO
                    break;
                case '3':
                    currentGame.gameProperties.Upgrade(); //TODO
                    break;
                case '4':
                    currentGame.gameProperties.ViewProperties(); //TODO
                    break;
                default:
                    Console.WriteLine("    Invalid input");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }
        }

        private void EmployeesMenu()
        {
            //TODO
        }

    }
}