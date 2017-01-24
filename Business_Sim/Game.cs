using System;

namespace Business_Sim
{
    class Game
    {
        public Asset gameAssets;
        protected Difficulty gameDifficulty;
        public decimal cash { get; set; }
        public DateTime startDate { get; private set; }
        public DateTime currentDate { get; set; }

        public enum Difficulty
        {
            Unknown = 0,
            vEasy = 1,
            Easy = 2,
            Normal = 3,
            Hard = 4,
            vHard = 5,
            Extreme = 6
        }

        public Game(Difficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
        }

        public void StartGame()
        {
            switch (gameDifficulty)
            {
                case Difficulty.vEasy:
                    cash = 7500.00M;
                    break;
                case Difficulty.Easy:
                    cash = 5000.00M;
                    break;
                case Difficulty.Normal:
                    cash = 2500.00M;
                    break;
                case Difficulty.Hard:
                    cash = 1000.00M;
                    break;
                case Difficulty.vHard:
                    cash = 500.00M;
                    break;
                case Difficulty.Extreme:
                    cash = 100.00M;
                    break;
                default:
                    break;
            }
            startDate = DateTime.Today.Date;
            currentDate = startDate;
            gameAssets = new Asset();
        }
    }
}