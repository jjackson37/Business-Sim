using System;
using System.Collections.Generic;

namespace Business_Sim
{
    class Asset
    {

        List<Property> ownedProperties = new List<Property>();

        public enum EmployeeRank
        {
            Unknown = 0
        }

        public decimal Add(Property propertyToBuy, decimal currentCash)
        {
            if (currentCash > propertyToBuy.buyCost)
            {
                currentCash -= propertyToBuy.buyCost;
                ownedProperties.Add(propertyToBuy);
                Console.WriteLine(propertyToBuy.propertyTypeString + " Purchased successfully");
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

        public void ViewProperties()
        {
            if (ownedProperties.Count != 0)
            {
                foreach (Property currentProperty in ownedProperties)
                {
                    Console.WriteLine(string.Format("Lvl {0} {1} - Income {2} - Outcome {3}", currentProperty.upgradeLevel, currentProperty.propertyTypeString,
                        currentProperty.income, currentProperty.outcome));
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
