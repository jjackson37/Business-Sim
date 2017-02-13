using Business_Sim.DataModels.AssetModels.EmployeeModels;

namespace Business_Sim.DataModels.AssetModels.BuildingModels
{
    internal class FlatModel : BuildingModel
    {
        protected override string className
        {
            get
            {
                return "FlatModel";
            }
        }

        public override ManagerModel assignedManager
        {
            get
            {
                return null;
            }
        }
    }
}