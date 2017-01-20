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
                Console.Write("-BUSINESS SIM-\n1.New business\n2.Load business\n" +
                    "3.Business help\n4.Quit\n");
                char userInput = Console.ReadKey(true).KeyChar;
                switch (userInput)
                {
                    case '1':
                        Console.Write("What difficulty?\n1-vEasy\n2-Easy\n3-Normal\n4-Hard\n5-vHard\n6-Extreme\n");
                        Game.difficulty difficultyInput = Game.difficulty.Unknown;
                        switch (Console.ReadKey().KeyChar)
                        {
                            case '1':
                                difficultyInput = Game.difficulty.vEasy;
                                break;
                            case '2':
                                difficultyInput = Game.difficulty.Easy; ;
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
                                break;
                        }
                        currentGame = new Game(difficultyInput);
                        currentGame.StartGame();
                        Console.Clear();
                        GameMenu();
                        break;
                    case '2':
                        //Load save file function
                        break;
                    case '3':
                        //Help menu function
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
            Console.Write("-Business Sim-\nCurrent date:" + DateTime.Today.ToShortDateString() + "\nCurrent cash:" + currentGame.cash + "\n");
            Console.ReadKey();
        }
    }
}
