namespace Business_Sim
{
    class Building
    {

        public BuildingType buildingType { get;}
        public decimal buyPrice { get; }
        public decimal sellPrice { get; }
        public decimal upgradePrice { get; }
        public decimal dailyIncome { get; private set;}
        public decimal dailyOutcome { get; private set;}
        private int _upgradeLevel;

        public int upgradeLevel
        {
            get { return _upgradeLevel; }
            set
            {
                _upgradeLevel = value;
                dailyIncome = dailyIncome * _upgradeLevel;
                dailyOutcome = dailyOutcome * _upgradeLevel;
            }
        }

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
                        returnString = "FlatBlock";
                        break;
                    case BuildingType.House:
                        returnString = "House";
                        break;
                    case BuildingType.Shop:
                        returnString = "Shop";
                        break;
                    case BuildingType.ShoppingCentre:
                        returnString = "ShoppingCentre";
                        break;
                    case BuildingType.Office:
                        returnString = "Office";
                        break;
                    case BuildingType.OfficeBlock:
                        returnString = "OfficeBlock";
                        break;
                    case BuildingType.SkyScraper:
                        returnString = "SkyScraper";
                        break;
                }
                return returnString;
            }
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

    }
}
