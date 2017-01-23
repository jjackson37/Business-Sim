using System;

namespace Business_Sim
{
    class Menu
    {
        Game currentGame;

        public void MainMenuSelection(){
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("-BUSINESS SIM-\n1-New business\n2-Load business\n" +
                    "3-Business help\n4-Quit\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Write("    What difficulty?\n    1-vEasy\n    2-Easy\n    3-Normal\n    4-Hard\n    5-vHard\n    6-Extreme\n    ");
                        Game.difficulty difficultyInput = Game.difficulty.Unknown;
                        bool invalidInput = false;
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                difficultyInput = Game.difficulty.vEasy;
                                break;
                            case '2':
                                difficultyInput = Game.difficulty.Easy;
                                break;
                            case '3':
                                difficultyInput = Game.difficulty.Normal;
                                break;
                            case '4':
                                difficultyInput = Game.difficulty.Hard;
                                break;
                            case '5':
                                difficultyInput = Game.difficulty.vHard;
                                break;
                            case '6':
                                difficultyInput = Game.difficulty.Extreme;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                invalidInput = true;
                                break;
                        }
                        if (invalidInput)
                        {
                            break;
                        }
                        currentGame = new Game(difficultyInput);
                        currentGame.StartGame();
                        Console.Clear();
                        GameMenu();
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
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
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
                        //TODO: Employees menu
                        break;
                    case '3':
                        //TODO: Calculate costs and profits for day
                        break;
                    case '4':
                        inGame = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        private void PropertiesMenu()
        {
            Console.Write("    -Properties-\n    1-Buy\n    2-Sell\n    3-Upgrade\n    4-View owned properties\n    5-Back\n");
            bool inPropertyMenu = true;
            while (inPropertyMenu)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        //TODO: Buy property
                        break;
                    case '2':
                        //TODO: Sell property
                        break;
                    case '3':
                        //TODO: Upgrade property
                        break;
                    case '4':
                        //TODO: List owned properties
                        break;
                    case '5':
                        inPropertyMenu = false;
                        break;
                    default:
                        Console.WriteLine("    Invalid input");
                        break;
                }
            }
        }

        private void EmployeesMenu()
        {

        }

    }
}