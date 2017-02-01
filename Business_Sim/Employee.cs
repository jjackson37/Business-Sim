namespace Business_Sim
{
    /// <summary>
    /// Earns income and outcome per day for the player
    /// </summary>
    internal class Employee
    {
        #region Fields

        private int _upgradeLevel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a employee object and sets all default properties of the employee depending on the type being created
        /// </summary>
        /// <param name="employeeType">employee type to add</param>
        public Employee(EmployeeType employeeType)
        {
            this.employeeType = employeeType;
            switch (employeeType)
            {
                case EmployeeType.Flat:
                    dailyIncome = 10.00M;
                    dailyOutcome = 2.00M;
                    buyPrice = 1000.00M;
                    break;

                case EmployeeType.FlatBlock:
                    dailyIncome = 100.00M;
                    dailyOutcome = 20.00M;
                    buyPrice = 10000.00M;
                    break;

                case EmployeeType.House:
                    dailyIncome = 20.00M;
                    dailyOutcome = 4.00M;
                    buyPrice = 2000.00M;
                    break;

                case EmployeeType.Shop:
                    dailyIncome = 50.00M;
                    dailyOutcome = 15.00M;
                    buyPrice = 5000.00M;
                    break;

                case EmployeeType.ShoppingCentre:
                    dailyIncome = 500.00M;
                    dailyOutcome = 150.00M;
                    buyPrice = 50000.00M;
                    break;

                case EmployeeType.Office:
                    dailyIncome = 150.00M;
                    dailyOutcome = 50.00M;
                    buyPrice = 15000.00M;
                    break;

                case EmployeeType.OfficeBlock:
                    dailyIncome = 1500.00M;
                    dailyOutcome = 500.00M;
                    buyPrice = 150000.00M;
                    break;

                case EmployeeType.SkyScraper:
                    dailyIncome = 2500.00M;
                    dailyOutcome = 750.00M;
                    buyPrice = 250000.00M;
                    break;

                default:
                    dailyIncome = 0;
                    dailyOutcome = 0;
                    buyPrice = 0;
                    break;
            }
            upgradeLevel = 1;
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// employee types
        /// </summary>
        public enum EmployeeType
        {
            Unknown = 0,
            Flat = 1,
            FlatBlock = 2,
            House = 3,
            Shop = 4,
            ShoppingCentre = 5,
            Office = 6,
            OfficeBlock = 7,
            SkyScraper = 8
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// employee type of the employee. Affects the base value for income, outcome, and buy/sell/upgrade price
        /// </summary>
        public EmployeeType employeeType { get; }

        /// <summary>
        /// Returns the employee type as a string
        /// </summary>
        public string employeeTypeString
        {
            get
            {
                string returnString = "Unknown";
                switch (employeeType)
                {
                    case EmployeeType.Flat:
                        returnString = "Flat";
                        break;

                    case EmployeeType.FlatBlock:
                        returnString = "Flat Block";
                        break;

                    case EmployeeType.House:
                        returnString = "House";
                        break;

                    case EmployeeType.Shop:
                        returnString = "Shop";
                        break;

                    case EmployeeType.ShoppingCentre:
                        returnString = "Shopping Centre";
                        break;

                    case EmployeeType.Office:
                        returnString = "Office";
                        break;

                    case EmployeeType.OfficeBlock:
                        returnString = "Office Block";
                        break;

                    case EmployeeType.SkyScraper:
                        returnString = "Sky Scraper";
                        break;
                }
                return returnString;
            }
        }

        /// <summary>
        /// Price to buy/add the employee to the owned employees list
        /// </summary>
        public decimal buyPrice { get; }

        /// <summary>
        /// Income employee gives per game day
        /// </summary>
        public decimal dailyIncome { get; private set; }

        /// <summary>
        /// Outcome employee takes per game day
        /// </summary>
        public decimal dailyOutcome { get; private set; }

        /// <summary>
        /// Amount of money gained if the employee is sold/removed from the owned employees list
        /// </summary>
        public decimal sellPrice { get; private set; }

        /// <summary>
        /// Current upgrade level. Affects income, outcome, sell price and upgrade price.
        /// </summary>
        public int upgradeLevel
        {
            get { return _upgradeLevel; }
            set
            {
                _upgradeLevel = value;
                dailyIncome = dailyIncome * _upgradeLevel;
                dailyOutcome = dailyOutcome * _upgradeLevel;
                sellPrice = (buyPrice / 2) * ((decimal)_upgradeLevel / 2);
                upgradePrice = buyPrice * ((decimal)_upgradeLevel / 2);
            }
        }

        /// <summary>
        /// Price to increase the upgrade level of te employee
        /// </summary>
        public decimal upgradePrice { get; private set; }

        #endregion Properties
    }
}