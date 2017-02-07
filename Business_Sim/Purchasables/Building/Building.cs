namespace Business_Sim
{
    /// <summary>
    /// Earns income and outcome per day for the player
    /// </summary>
    internal class Building
    {
        #region Fields

        private Manager _assignedManager;
        private int _upgradeLevel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a building object and sets all default properties of the building depending on the type being created
        /// </summary>
        /// <param name="buildingType">Building type to add</param>
        public Building(BuildingType buildingType)
        {
            this.buildingType = buildingType;
            switch (buildingType)
            {
                case BuildingType.Flat:
                    dailyIncome = 100.00M;
                    dailyOutcome = 20.00M;
                    buyPrice = 10000.00M;
                    workersNeeded = 1;
                    canHaveManager = false;
                    break;

                case BuildingType.FlatBlock:
                    dailyIncome = 1000.00M;
                    dailyOutcome = 200.00M;
                    buyPrice = 100000.00M;
                    workersNeeded = 10;
                    canHaveManager = true;
                    break;

                case BuildingType.House:
                    dailyIncome = 200.00M;
                    dailyOutcome = 40.00M;
                    buyPrice = 20000.00M;
                    workersNeeded = 1;
                    canHaveManager = false;
                    break;

                case BuildingType.Shop:
                    dailyIncome = 500.00M;
                    dailyOutcome = 150.00M;
                    buyPrice = 50000.00M;
                    workersNeeded = 7;
                    canHaveManager = true;
                    break;

                case BuildingType.ShoppingCentre:
                    dailyIncome = 5000.00M;
                    dailyOutcome = 1500.00M;
                    buyPrice = 500000.00M;
                    workersNeeded = 70;
                    canHaveManager = true;
                    break;

                case BuildingType.Office:
                    dailyIncome = 1500.00M;
                    dailyOutcome = 500.00M;
                    buyPrice = 150000.00M;
                    workersNeeded = 30;
                    canHaveManager = true;
                    break;

                case BuildingType.OfficeBlock:
                    dailyIncome = 15000.00M;
                    dailyOutcome = 5000.00M;
                    buyPrice = 1500000.00M;
                    workersNeeded = 300;
                    canHaveManager = true;
                    break;

                case BuildingType.SkyScraper:
                    dailyIncome = 25000.00M;
                    dailyOutcome = 7500.00M;
                    buyPrice = 2500000.00M;
                    workersNeeded = 500;
                    canHaveManager = true;
                    break;

                default:
                    dailyIncome = 0;
                    dailyOutcome = 0;
                    buyPrice = 0;
                    workersNeeded = 0;
                    canHaveManager = false;
                    break;
            }
            assignedManager = null;
            currentWorkers = 0;
            upgradeLevel = 1;
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// Building type
        /// </summary>
        public enum BuildingType
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
        /// Manager assigned to the building
        /// </summary>
        public Manager assignedManager
        {
            get { return _assignedManager; }
            set
            {
                if (canHaveManager)
                {
                    _assignedManager = value;
                }
                else
                {
                    _assignedManager = null;
                }
            }
        }

        /// <summary>
        /// Building type of the building. Affects the base value for income, outcome, and buy/sell/upgrade price
        /// </summary>
        public BuildingType buildingType { get; }

        /// <summary>
        /// Returns the building type as a string
        /// </summary>
        public string buildingTypeString
        {
            get
            {
                string returnString = "Unknown";
                switch (buildingType)
                {
                    case BuildingType.Flat:
                        returnString = "Flat";
                        break;

                    case BuildingType.FlatBlock:
                        returnString = "Flat Block";
                        break;

                    case BuildingType.House:
                        returnString = "House";
                        break;

                    case BuildingType.Shop:
                        returnString = "Shop";
                        break;

                    case BuildingType.ShoppingCentre:
                        returnString = "Shopping Centre";
                        break;

                    case BuildingType.Office:
                        returnString = "Office";
                        break;

                    case BuildingType.OfficeBlock:
                        returnString = "Office Block";
                        break;

                    case BuildingType.SkyScraper:
                        returnString = "Sky Scraper";
                        break;
                }
                return returnString;
            }
        }

        //TODO: Worker <---> building implementation

        /// <summary>
        /// Price to buy/add the building to the owned buildings list
        /// </summary>
        public decimal buyPrice { get; }

        /// <summary>
        /// Gets if the building can hold a manager
        /// </summary>
        public bool canHaveManager { get; }

        /// <summary>
        /// Amount of workers currently assigned to the building
        /// </summary>
        public int currentWorkers { get; set; }

        //TODO: Manager <---> building implementation
        /// <summary>
        /// Income building gives per game day
        /// </summary>
        public decimal dailyIncome { get; private set; }

        /// <summary>
        /// Outcome building takes per game day
        /// </summary>
        public decimal dailyOutcome { get; private set; }

        /// <summary>
        /// Amount of money gained if the building is sold/removed from the owned buildings list
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
                dailyIncome = (buyPrice / 100) * _upgradeLevel;
                dailyOutcome = (dailyIncome / 5);
                sellPrice = (buyPrice / 2) * ((decimal)_upgradeLevel / 2);
                upgradePrice = buyPrice * ((decimal)_upgradeLevel / 2);
            }
        }

        /// <summary>
        /// Price to increase the upgrade level of te building
        /// </summary>
        public decimal upgradePrice { get; private set; }

        /// <summary>
        /// Amount of workers needed for the building to function at full potential
        /// </summary>
        public int workersNeeded { get; }

        #endregion Properties
    }
}