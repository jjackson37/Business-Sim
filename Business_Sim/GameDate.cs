using System;

namespace Business_Sim
{
    /// <summary>
    /// Handles date and progression of time in game
    /// </summary>
    internal class GameDate
    {
        #region Fields

        private DateTime _currentDate;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates GameDate object and sets starting date
        /// </summary>
        public GameDate()
        {
            startDate = DateTime.Today.Date;
            currentDate = startDate;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Current date of the game
        /// </summary>
        public DateTime currentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value.Date;
            }
        }

        /// <summary>
        /// Current game date as string
        /// </summary>
        public string currentDateString
        {
            get
            {
                return _currentDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Date the game begun on
        /// </summary>
        public DateTime startDate { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Progresses the game forward in time
        /// </summary>
        /// <param name="numberOfDays">Number of days to progress</param>
        public void Progress(int numberOfDays)
        {
            currentDate = currentDate.AddDays(numberOfDays);
        }

        /// <summary>
        /// Progresses the game forward in time and returns cash gained for that time
        /// </summary>
        /// <param name="numberOfDays">Number of days to progress</param>
        /// <param name="dailyIncome">Daily income of assets</param>
        /// <param name="dailyOutcome">Daily outcome of assets</param>
        /// <returns>Amount earned</returns>
        public decimal Progress(int numberOfDays, decimal dailyIncome, decimal dailyOutcome)
        {
            currentDate = currentDate.AddDays(numberOfDays);
            decimal cashGained = 0;
            for (int i = 1; i <= numberOfDays; i++)
            {
                cashGained += (dailyIncome - dailyOutcome);
            }
            return cashGained;
        }

        #endregion Methods
    }
}