using System;
using System.Collections.Generic;

namespace Business_Sim
{
    internal class Asset
    {
        /// <summary>
        /// List of owned buildings for the current game
        /// </summary>
        private List<Building> ownedBuildings = new List<Building>();

        public enum EmployeeRank
        {
            Unknown = 0
        }

        /// <summary>
        /// Adds a building to the owned buildings list and updates the current cash
        /// </summary>
        /// <param name="buildingToBuy">Type of building to buy</param>
        /// <param name="currentCash">Current cash of the game</param>
        /// <returns>New cash of the game</returns>
        public decimal Add(Building buildingToBuy, decimal currentCash)
        {
            if (currentCash >= buildingToBuy.buyPrice)
            {
                currentCash -= buildingToBuy.buyPrice;
                ownedBuildings.Add(buildingToBuy);
                Console.WriteLine("        " + buildingToBuy.buildingTypeString + " Purchased successfully");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("        Insufficient cash");
                Console.ReadKey(true);
                Console.Clear();
            }
            return currentCash;
        }

        //public void Add(Employee rankToHire)
        //{
        //  TODO
        //}

        /// <summary>
        /// Lists all owned buildings of a certain type and returns ones depending on user selection
        /// </summary>
        /// <param name="buildingType">Building type to list</param>
        /// <returns>Found Building</returns>
        public Building Find(Building.BuildingType buildingType)
        {
            Building returnBuilding = null;
            bool foundAResult = false;
            foreach (Building currentBuilding in ownedBuildings)
            {
                if (currentBuilding.buildingType.Equals(buildingType))
                {
                    Console.WriteLine(string.Format("        {4} - Lvl {0} {1} - Daily income {2} - Daily outcome {3} - Sell price {5}", currentBuilding.upgradeLevel,
                        currentBuilding.buildingTypeString, currentBuilding.dailyIncome, currentBuilding.dailyOutcome, ownedBuildings.FindIndex(currentBuilding.Equals), currentBuilding.sellPrice));
                    foundAResult = true;
                }
            }
            if (foundAResult)
            {
                Console.WriteLine("        Select property");
                int userInput = int.Parse(Console.ReadLine());
                if (ownedBuildings[userInput].buildingType.Equals(buildingType))
                {
                    returnBuilding = ownedBuildings[userInput];
                }
            }
            else
            {
                Console.WriteLine("        No results");
            }
            return returnBuilding;
        }

        /// <summary>
        /// Removes a building from the owned buildings list and returns the sell price
        /// </summary>
        /// <param name="buildingToSell">Building that is being sold</param>
        /// <returns>Amount of cash gained for sale</returns>
        public decimal Remove(Building buildingToSell)
        {
            ownedBuildings.Remove(buildingToSell);
            Console.WriteLine(string.Format("        {0} sold for {1}" , buildingToSell.buildingTypeString, buildingToSell.sellPrice));
            return buildingToSell.sellPrice;
        }

        public void Upgrade()
        {
            //TODO
        }

        /// <summary>
        /// Lists all owned buildings in the console
        /// </summary>
        public void ViewBuildings()
        {
            if (ownedBuildings.Count != 0)
            {
                foreach (Building currentBuilding in ownedBuildings)
                {
                    Console.WriteLine(string.Format("    Lvl {0} {1} - Daily income {2} - Daily outcome {3}", currentBuilding.upgradeLevel,
                        currentBuilding.buildingTypeString, currentBuilding.dailyIncome, currentBuilding.dailyOutcome));
                }
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("    None owned");
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