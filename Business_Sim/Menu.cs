using System;

namespace Business_Sim
{
    class Menu
    {
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
                        Game.difficulty difficultyInput = (Game.difficulty)(Console.ReadKey(true).KeyChar);
                        Game currentGame = new Game(difficultyInput);
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
    }
}
