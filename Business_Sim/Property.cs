namespace Business_Sim
{
    class Property
    {
        public Asset.PropertyType propertyType { get;}
        public decimal income { get; private set;}
        public decimal outcome { get; private set;}
        public byte upgradeLevel
        {
            get { return upgradeLevel;}
            set
            {
                upgradeLevel = upgradeLevel;
                income = income * upgradeLevel;
                outcome = outcome * upgradeLevel;
            }
        }

        public Property(Asset.PropertyType propertyType)
        {
            this.propertyType = propertyType;
            upgradeLevel = 1;
            switch (propertyType)
            {
                case Asset.PropertyType.Flat:
                    income = 10.00M;
                    outcome = 2.00M;
                    break;
                case Asset.PropertyType.FlatBlock:
                    income = 100.00M;
                    outcome = 20.00M;
                    break;
                case Asset.PropertyType.House:
                    income = 20.00M;
                    outcome = 4.00M;
                    break;
                case Asset.PropertyType.Shop:
                    income = 50.00M;
                    outcome = 15.00M;
                    break;
                case Asset.PropertyType.ShoppingCentre:
                    income = 500.00M;
                    outcome = 150.00M;
                    break;
                case Asset.PropertyType.Office:
                    income = 150.00M;
                    outcome = 50.00M;
                    break;
                case Asset.PropertyType.OfficeBlock:
                    income = 1500.00M;
                    outcome = 500.00M;
                    break;
                case Asset.PropertyType.SkyScraper:
                    income = 2500.00M;
                    outcome = 750.00M;
                    break;
                default:
                    income = 0;
                    outcome = 0;
                    break;
            }
        }
    }
}
