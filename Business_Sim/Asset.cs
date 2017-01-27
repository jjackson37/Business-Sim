using System;
using System.Collections.Generic;

namespace Business_Sim
{
    /// <summary>
    /// Buildings and employees
    /// </summary>
    internal class Asset
    {
        #region Fields

        /// <summary>
        /// List of owned buildings for the current game
        /// </summary>
        private List<Building> ownedBuildings = new List<Building>();

        #endregion Fields

        #region Enums

        public enum EmployeeRank
        {
            Unknown = 0
        }

        #endregion Enums

        #region Methods

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
            }
            else
            {
                Console.WriteLine("        Insufficient cash");
            }
            return currentCash;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="rankToHire">Rank of employee to hire</param>
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
            if (ownedBuildings.Count != 0)
            {
                foreach (Building currentBuilding in ownedBuildings)
                {
                    if (currentBuilding.buildingType.Equals(buildingType))
                    {
                        Console.WriteLine(string.Format("        {4} - Lvl {0} {1} - Daily income {2} - Daily outcome {3} - Sell price {5}", currentBuilding.upgradeLevel,
                            currentBuilding.buildingTypeString, currentBuilding.dailyIncome, currentBuilding.dailyOutcome, ownedBuildings.FindIndex(currentBuilding.Equals), currentBuilding.sellPrice));
                        foundAResult = true;
                    }
                }
            }
            if (foundAResult)
            {
                Console.WriteLine("        Select property");
                try
                {
                    int userInput = int.Parse(Console.ReadLine());
                    if (ownedBuildings[userInput].buildingType.Equals(buildingType))
                    {
                        returnBuilding = ownedBuildings[userInput];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("        " + ex.Message);
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
            if (!buildingToSell.Equals(null))
            {
                ownedBuildings.Remove(buildingToSell);
                Console.WriteLine(string.Format("        {0} sold for {1}", buildingToSell.buildingTypeString, buildingToSell.sellPrice));
            }
            return buildingToSell.sellPrice;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="buildingToUpgrade"></param>
        /// <param name="currentCash"></param>
        /// <returns></returns>
        public decimal Upgrade(Building buildingToUpgrade, decimal currentCash)
        {
            decimal newCash = currentCash - buildingToUpgrade.upgradePrice;
            return newCash;
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
            }
            else
            {
                Console.WriteLine("    None owned");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void ViewEmployees()
        {
            //TODO
        }

        #endregion Methods
    }
}