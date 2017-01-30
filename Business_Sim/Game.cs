namespace Business_Sim
{
    /// <summary>
    /// Stores information about a game
    /// </summary>
    internal class Game
    {
        #region Fields

        /// <summary>
        /// Buildings and employees
        /// </summary>
        public Asset assets;

        /// <summary>
        /// Time operations of game
        /// </summary>
        public GameDate date;

        /// <summary>
        /// Difficulty of the game
        /// </summary>
        protected Difficulty gameDifficulty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Sets starting values of the game based on difficulty
        /// </summary>
        /// <param name="gameDifficulty">Difficulty of the game</param>
        public Game(Difficulty gameDifficulty)
        {
            this.gameDifficulty = gameDifficulty;
            switch (this.gameDifficulty)
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
            date = new GameDate();
            assets = new Asset();
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// Game difficulties
        /// </summary>
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

        #endregion Enums

        #region Properties

        /// <summary>
        /// Current cash
        /// </summary>
        public decimal cash { get; set; }

        #endregion Properties
    }
}