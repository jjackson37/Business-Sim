namespace Business_Sim.DataModels.AssetModels
{
    internal class AssetModel : GameModel
    {
        protected override string className
        {
            get
            {
                return "AssetModel";
            }
        }

        public decimal income { get; set; }
        public decimal outcome { get; set; }
    }
}