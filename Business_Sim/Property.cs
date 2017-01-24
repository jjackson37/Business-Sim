namespace Business_Sim
{
    class Property
    {
        public enum PropertyType
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

        public PropertyType propertyType { get;}
        public string propertyTypeString
        {
            get
            {
                string returnString = "Unknown";
                switch (propertyType)
                {
                    case PropertyType.Flat:
                        returnString = "Flat";
                        break;
                    case PropertyType.FlatBlock:
                        returnString = "FlatBlock";
                        break;
                    case PropertyType.House:
                        returnString = "House";
                        break;
                    case PropertyType.Shop:
                        returnString = "Shop";
                        break;
                    case PropertyType.ShoppingCentre:
                        returnString = "ShoppingCentre";
                        break;
                    case PropertyType.Office:
                        returnString = "Office";
                        break;
                    case PropertyType.OfficeBlock:
                        returnString = "OfficeBlock";
                        break;
                    case PropertyType.SkyScraper:
                        returnString = "SkyScraper";
                        break;
                }
                return returnString;
            }
        }
        public decimal income { get; private set;}
        public decimal outcome { get; private set;}
        public decimal buyCost { get; private set;}
        private int _upgradeLevel;
        public int upgradeLevel
        {
            get { return _upgradeLevel; }
            set
            {
                _upgradeLevel = value;
                income = income * _upgradeLevel;
                outcome = outcome * _upgradeLevel;
            }
        }

        public Property(PropertyType propertyType)
        {
            this.propertyType = propertyType;
            switch (propertyType)
            {
                case PropertyType.Flat:
                    income = 10.00M;
                    outcome = 2.00M;
                    buyCost = 1000.00M;                
                    break;
                case PropertyType.FlatBlock:
                    income = 100.00M;
                    outcome = 20.00M;
                    buyCost = 10000.00M;
                    break;
                case PropertyType.House:
                    income = 20.00M;
                    outcome = 4.00M;
                    buyCost = 2000.00M;
                    break;
                case PropertyType.Shop:
                    income = 50.00M;
                    outcome = 15.00M;
                    buyCost = 5000.00M;
                    break;
                case PropertyType.ShoppingCentre:
                    income = 500.00M;
                    outcome = 150.00M;
                    buyCost = 50000.00M;
                    break;
                case PropertyType.Office:
                    income = 150.00M;
                    outcome = 50.00M;
                    buyCost = 15000.00M;
                    break;
                case PropertyType.OfficeBlock:
                    income = 1500.00M;
                    outcome = 500.00M;
                    buyCost = 150000.00M;
                    break;
                case PropertyType.SkyScraper:
                    income = 2500.00M;
                    outcome = 750.00M;
                    buyCost = 250000.00M;
                    break;
                default:
                    income = 0;
                    outcome = 0;
                    buyCost = 0;
                    break;
            }
            upgradeLevel = 1;
        }

    }
}
