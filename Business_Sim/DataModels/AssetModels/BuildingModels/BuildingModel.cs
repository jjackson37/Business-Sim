using Business_Sim.DataModels.AssetModels.EmployeeModels;

namespace Business_Sim.DataModels.AssetModels.BuildingModels
{
    internal class BuildingModel : AssetModel
    {
        protected override string className
        {
            get
            {
                return "BuildingModel";
            }
        }

        public int buildingLevel { get; set; }
        public int workersRequired { get; set; }
        public int currentWorkers { get; set; }
        public virtual ManagerModel assignedManager { get; set; }

    }
}