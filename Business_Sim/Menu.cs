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
                        BuildingsMenu();
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

        private void BuildingsMenu()
        {
            Console.Write("    -Properties-\n    1-Buy\n    2-Sell\n    3-Upgrade\n    4-View owned properties\n");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("        -Buy\n        1-Flat\n        2-Flat Block\n        3-House\n        4-Office\n"
                        + "        5-Office block\n        6-Shop\n        7-Shopping centre\n        8-Sky scraper\n");
                    
                    Building.BuildingType buildingTypeToBuy = Building.BuildingType.Unknown;
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            buildingTypeToBuy = Building.BuildingType.Flat;
                            break;
                        case '2':
                            buildingTypeToBuy = Building.BuildingType.FlatBlock;
                            break;
                        case '3':
                            buildingTypeToBuy = Building.BuildingType.House;
                            break;
                        case '4':
                            buildingTypeToBuy = Building.BuildingType.Office;
                            break;
                        case '5':
                            buildingTypeToBuy = Building.BuildingType.OfficeBlock;
                            break;
                        case '6':
                            buildingTypeToBuy = Building.BuildingType.Shop;
                            break;
                        case '7':
                            buildingTypeToBuy = Building.BuildingType.ShoppingCentre;
                            break;
                        case '8':
                            buildingTypeToBuy = Building.BuildingType.SkyScraper;
                            break;
                        default:
                            Console.WriteLine("        Invalid input");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                    }
                    if (buildingTypeToBuy != Building.BuildingType.Unknown)
                    {
                        Building buyingBuilding = new Building(buildingTypeToBuy);
                        currentGame.cash = currentGame.gameAssets.Add(buyingBuilding, currentGame.cash);
                    }
                    break;
                case '2':
                    currentGame.gameAssets.Remove(); //TODO
                    break;
                case '3':
                    currentGame.gameAssets.Upgrade(); //TODO
                    break;
                case '4':
                    currentGame.gameAssets.ViewBuildings(); //TODO
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