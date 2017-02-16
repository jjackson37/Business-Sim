using Business_Sim.DataModels.AssetModels.EmployeeModels;

namespace Business_Sim.DataModels.AssetModels.BuildingModels.ResidentialModels
{
    internal class FlatModel : ResidentialBuildingModel
    {
        protected override string className
        {
            get
            {
                return "FlatModel";
            }
        }
    }
}