using System;

namespace Business_Sim
{
    /// <summary>
    /// Console UI
    /// </summary>
    internal class Menu
    {
        #region Fields

        protected const string _INDENT = "    ";

        /// <summary>
        /// Currently loaded game
        /// </summary>
        protected Game game;

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
                        Console.Write("{0}What difficulty?\n{0}1-vEasy\n{0}2-Easy\n{0}3-Normal\n{0}4-Hard\n{0}5-vHard\n{0}6-Extreme\n{0}", _INDENT);
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
        /// Main menu, calls other menus depending on user input
        /// </summary>
        private void GameMenu()
        {
            bool inGame = true;
            while (inGame)
            {
                Console.Write("-Business Sim-\nDate:" + game.date.currentDateString + "\nCash:" + game.cash + "\n");
                Console.Write("1-Properties\n2-Employees (WIP)\n3-Next day\n4-Exit to main menu\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        BuildingMenu buildingMenuObject = new BuildingMenu(ref game);
                        buildingMenuObject.RunMenu();
                        break;

                    case '2':
                        EmployeeMenu employeeMenuObject = new EmployeeMenu(ref game);
                        employeeMenuObject.RunMenu();
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

        #endregion Methods
    }
}