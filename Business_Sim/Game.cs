using System;

namespace Business_Sim
{
    class Game
    {
        protected difficulty gameDifficulty;
        public int cash { get; protected set; }
        public DateTime startDate { get; private set; }
        public DateTime currentDate { get; protected set; }

        public enum difficulty
        {
            Unknown = 0,
            vEasy = 1,
            Easy = 2,
            Normal = 3,
            Hard = 4,
            vHard = 5,
            Extreme = 6
        }

        public Game(difficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
        }

        public void StartGame()
        {
            switch (gameDifficulty)
            {
                case difficulty.vEasy:
                    cash = 7500;
                    break;
                case difficulty.Easy:
                    cash = 5000;
                    break;
                case difficulty.Normal:
                    cash = 2500;
                    break;
                case difficulty.Hard:
                    cash = 1000;
                    break;
                case difficulty.vHard:
                    cash = 500;
                    break;
                case difficulty.Extreme:
                    cash = 100;
                    break;
                default:
                    break;
            }
            startDate = DateTime.Today.Date;
            currentDate = startDate;
        }
    }
}
