using System;
using System.Collections.Generic;

namespace Business_Sim
{
    class Asset
    {

        List<Building> ownedBuildings = new List<Building>();

        public enum EmployeeRank
        {
            Unknown = 0
        }

        public decimal Add(Building buildingToBuy, decimal currentCash)
        {
            if (currentCash > buildingToBuy.buyPrice)
            {
                currentCash -= buildingToBuy.buyPrice;
                ownedBuildings.Add(buildingToBuy);
                Console.WriteLine(buildingToBuy.buildingTypeString + " Purchased successfully");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Insufficient cash");
                Console.ReadKey(true);
                Console.Clear();
            }
            return currentCash;
        }

        //public void Add(Employee rankToHire)
        //{
        //  TODO
        //}

        public void Remove()
        {
            //TODO
        }

        public void Upgrade()
        {
            //TODO
        }

        public void ViewBuildings()
        {
            if (ownedBuildings.Count != 0)
            {
                foreach (Building currentBuilding in ownedBuildings)
                {
                    Console.WriteLine(string.Format("Lvl {0} {1} - Income {2} - Outcome {3}", currentBuilding.upgradeLevel, currentBuilding.buildingTypeString,
                        currentBuilding.dailyIncome, currentBuilding.dailyOutcome));
                }
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("None owned");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public void ViewEmployees()
        {
            //TODO
        }

    }
}
