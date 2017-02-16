using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Sim.DataModels.AssetModels.BuildingModels.ResidentialModels
{
    class ResidentialBuildingModel : BuildingModel
    {

        protected override string className
        {
            get
            {
                return "ResidentialBuildingModel";
            }
        }

        public decimal repairCosts { get; set; }
        public enum TennentHappiness
        {
            Unknown = 0,
            VeryHappy = 1,
            Happy = 2,
            Neutral = 3,
            Unhappy = 4,
            VeryUnhappy = 5
        }
        public enum MaintenanceLevel
        {
            Unknown = 0,
            Good = 1,
            Average = 2,
            Bad = 3,
            Uninhabitable = 4
        }

    }
}
