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

        /// <summary>
        /// List of employees for the current game
        /// </summary>
        private List<Employee> ownedEmployees = new List<Employee>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Total daily income of all assets
        /// </summary>
        public decimal income
        {
            get
            {
                decimal incomeReturn = 0;
                foreach (Building currentBuilding in ownedBuildings)
                {
                    incomeReturn += currentBuilding.dailyIncome;
                }
                return incomeReturn;
            }
        }

        /// <summary>
        /// Total daily outcome of all assets
        /// </summary>
        public decimal outcome
        {
            get
            {
                decimal outcomeReturn = 0;
                foreach (Building currentBuilding in ownedBuildings)
                {
                    outcomeReturn += currentBuilding.dailyOutcome;
                }
                foreach (Employee currentEmployee in ownedEmployees)
                {
                    outcomeReturn += currentEmployee.dailyOutcome;
                }
                return outcomeReturn;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds a building to the owned buildings list and updates the current cash
        /// </summary>
        /// <param name="buildingTypeToBuy">Type of building to buy</param>
        /// <param name="currentCash">Current cash of the game</param>
        /// <returns>New cash of the game</returns>
        public decimal Add(Building.BuildingType buildingTypeToBuy, decimal currentCash)
        {
            Building buildingToBuy = new Building(buildingTypeToBuy);
            if (currentCash >= buildingToBuy.buyPrice)
            {
                currentCash -= buildingToBuy.buyPrice;
                ownedBuildings.Add(buildingToBuy);
                Console.WriteLine("        " + buildingToBuy.buildingTypeString + " Purchased successfully");
            }
            else
            {
                Console.WriteLine("        Insufficient funds");
            }
            return currentCash;
        }

        /// <summary>
        /// Adds a employee to the owned employees list and updates the current cash
        /// </summary>
        /// <param name="employeeTypeToBuy">Type of employee to buy</param>
        /// <param name="currentCash">Current cash of the game</param>
        /// <returns>New cash of the game</returns>
        public decimal Add(Employee.EmployeeType employeeTypeToBuy, decimal currentCash)
        {
            Employee employeeToBuy = new Employee(employeeTypeToBuy);
            if (currentCash >= employeeToBuy.buyPrice)
            {
                currentCash -= employeeToBuy.buyPrice;
                ownedEmployees.Add(employeeToBuy);
                Console.WriteLine("        " + employeeToBuy.employeeTypeString + " Hired successfully");
            }
            else
            {
                Console.WriteLine("        Insufficient funds");
            }
            return currentCash;
        }

        /// <summary>
        /// Lists all owned buildings of a certain type and returns one depending on user selection
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
                        Console.WriteLine(string.Format("        {4} - Lvl {0} {1} - Daily income {2} - Daily outcome {3} - Sell price {5} - Upgrade price {6}",
                            currentBuilding.upgradeLevel, currentBuilding.buildingTypeString, currentBuilding.dailyIncome, currentBuilding.dailyOutcome,
                            ownedBuildings.FindIndex(currentBuilding.Equals), currentBuilding.sellPrice, currentBuilding.upgradePrice));
                        foundAResult = true;
                    }
                }
            }
            if (foundAResult)
            {
                Console.WriteLine("        Select property");
                try
                {
                    Console.Write("        ");
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
        /// Lists all owned employees of a certain type and returns one depending on user selection
        /// </summary>
        /// <param name="employeeType">Employee type to list</param>
        /// <returns>Found employee</returns>
        public Employee Find(Employee.EmployeeType employeeType)
        {
            Employee returnEmployee = null;
            bool foundAResult = false;
            if (ownedEmployees.Count != 0)
            {
                foreach (Employee currentEmployee in ownedEmployees)
                {
                    if (currentEmployee.employeeType.Equals(employeeType))
                    {
                        Console.WriteLine(string.Format("        {2} - {0} - Daily outcome {1}",
                            currentEmployee.employeeTypeString, currentEmployee.dailyOutcome,
                            ownedEmployees.FindIndex(currentEmployee.Equals)));
                        foundAResult = true;
                    }
                }
            }
            if (foundAResult)
            {
                Console.WriteLine("        Select employee");
                try
                {
                    Console.Write("        ");
                    int userInput = int.Parse(Console.ReadLine());
                    if (ownedEmployees[userInput].employeeType.Equals(employeeType))
                    {
                        returnEmployee = ownedEmployees[userInput];
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
            return returnEmployee;
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
                Console.WriteLine(string.Format("        {0} sold for {1}"
                    , buildingToSell.buildingTypeString, buildingToSell.sellPrice));
            }
            return buildingToSell.sellPrice;
        }

        /// <summary>
        /// Removes an employee from the owned employees list
        /// </summary>
        /// <param name="employeeToFire">Employee that is being fired</param>
        public void Remove(Employee employeeToFire)
        {
            if (!employeeToFire.Equals(null))
            {
                ownedEmployees.Remove(employeeToFire);
                Console.WriteLine(string.Format("        {0} fired"
                    , employeeToFire.employeeTypeString));
            }
        }

        /// <summary>
        /// Increases a buildings upgrade level by one
        /// </summary>
        /// <param name="buildingToUpgrade">Building to increase the upgrade level of</param>
        /// <param name="currentCash">Current cash of the game</param>
        /// <returns>New cash amount</returns>
        public decimal Upgrade(Building buildingToUpgrade, decimal currentCash)
        {
            decimal newCash = currentCash;
            if (currentCash >= buildingToUpgrade.upgradePrice)
            {
                if (buildingToUpgrade.upgradeLevel < 10)
                {
                    newCash -= buildingToUpgrade.upgradePrice;
                    decimal oldUpgradePrice = buildingToUpgrade.upgradePrice;
                    buildingToUpgrade.upgradeLevel++;
                    Console.WriteLine(string.Format("        lvl {0} {1} upgraded to lvl {2} for {3}",
                        buildingToUpgrade.upgradeLevel - 1, buildingToUpgrade.buildingTypeString
                        , buildingToUpgrade.upgradeLevel, oldUpgradePrice));
                }
                else
                {
                    Console.WriteLine("        Upgrade level has already reached maximum");
                }
            }
            else
            {
                Console.WriteLine("        Insufficient funds");
            }
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
                    Console.WriteLine(string.Format("    Lvl {0} {1} - Daily income {2} - Daily outcome {3}"
                        , currentBuilding.upgradeLevel, currentBuilding.buildingTypeString
                        , currentBuilding.dailyIncome, currentBuilding.dailyOutcome));
                }
            }
            else
            {
                Console.WriteLine("    None owned");
            }
        }

        /// <summary>
        /// Lists all owned employees in the console
        /// </summary>
        public void ViewEmployees()
        {
            if (ownedEmployees.Count != 0)
            {
                foreach (Employee currentEmployee in ownedEmployees)
                {
                    Console.WriteLine(string.Format("    {0} - daily outcome {1}"
                        , currentEmployee.employeeTypeString, currentEmployee.dailyOutcome));
                }
            }
            else
            {
                Console.WriteLine("    None hired");
            }
        }

        #endregion Methods
    }
}