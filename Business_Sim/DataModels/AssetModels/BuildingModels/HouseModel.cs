using Business_Sim.DataModels.AssetModels.EmployeeModels;

namespace Business_Sim.DataModels.AssetModels.BuildingModels
{
    internal class HouseModel : BuildingModel
    {
        protected override string className
        {
            get
            {
                return "HouseModel";
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