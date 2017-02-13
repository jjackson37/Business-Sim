using Business_Sim.DataModels.AssetModels.EmployeeModels;

namespace Business_Sim.DataModels.AssetModels.BuildingModels
{
    internal class FlatBlockModel : FlatModel
    {
        protected override string className
        {
            get
            {
                return "FlatBlockModel";
            }
        }

        public override ManagerModel assignedManager { get; set; }
    }
}