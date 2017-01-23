using System;

namespace Business_Sim
{
    class Game
    {
        public Asset gameProperties;
        protected Difficulty gameDifficulty;
        public int cash { get; protected set; }
        public DateTime startDate { get; private set; }
        public DateTime currentDate { get; protected set; }

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
                    cash = 7500;
                    break;
                case Difficulty.Easy:
                    cash = 5000;
                    break;
                case Difficulty.Normal:
                    cash = 2500;
                    break;
                case Difficulty.Hard:
                    cash = 1000;
                    break;
                case Difficulty.vHard:
                    cash = 500;
                    break;
                case Difficulty.Extreme:
                    cash = 100;
                    break;
                default:
                    break;
            }
            startDate = DateTime.Today.Date;
            currentDate = startDate;
            gameProperties = new Asset();
        }
    }
}