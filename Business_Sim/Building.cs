namespace Business_Sim
{
    internal class Building
    {
        private int _upgradeLevel;

        /// <summary>
        /// Sets all default properties of the building depending on the type being added
        /// </summary>
        /// <param name="buildingType">Building type to add</param>
        public Building(BuildingType buildingType)
        {
            this.buildingType = buildingType;
            switch (buildingType)
            {
                case BuildingType.Flat:
                    dailyIncome = 10.00M;
                    dailyOutcome = 2.00M;
                    buyPrice = 1000.00M;
                    break;

                case BuildingType.FlatBlock:
                    dailyIncome = 100.00M;
                    dailyOutcome = 20.00M;
                    buyPrice = 10000.00M;
                    break;

                case BuildingType.House:
                    dailyIncome = 20.00M;
                    dailyOutcome = 4.00M;
                    buyPrice = 2000.00M;
                    break;

                case BuildingType.Shop:
                    dailyIncome = 50.00M;
                    dailyOutcome = 15.00M;
                    buyPrice = 5000.00M;
                    break;

                case BuildingType.ShoppingCentre:
                    dailyIncome = 500.00M;
                    dailyOutcome = 150.00M;
                    buyPrice = 50000.00M;
                    break;

                case BuildingType.Office:
                    dailyIncome = 150.00M;
                    dailyOutcome = 50.00M;
                    buyPrice = 15000.00M;
                    break;

                case BuildingType.OfficeBlock:
                    dailyIncome = 1500.00M;
                    dailyOutcome = 500.00M;
                    buyPrice = 150000.00M;
                    break;

                case BuildingType.SkyScraper:
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

        /// <summary>
        /// Price to buy/add the building to the owned buildings list
        /// </summary>
        public decimal buyPrice { get; }
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
                dailyIncome = dailyIncome * _upgradeLevel;
                dailyOutcome = dailyOutcome * _upgradeLevel;
                sellPrice = (buyPrice / 2) * ((decimal)_upgradeLevel / 2);
                upgradePrice = buyPrice * (_upgradeLevel / 2);
            }
        }

        /// <summary>
        /// Price to increase the upgrade level of te building
        /// </summary>
        public decimal upgradePrice { get; private set; }
    }
}