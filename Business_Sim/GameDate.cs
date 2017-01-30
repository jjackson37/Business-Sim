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
            get { return _currentDate.Date; }
            set
            {
                _currentDate = value.Date;
            }
        }

        /// <summary>
        /// Date the game begun on
        /// </summary>
        public DateTime startDate { get; private set; }

        #endregion Properties
    }
}