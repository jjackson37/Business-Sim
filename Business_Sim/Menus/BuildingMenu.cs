using System;

namespace Business_Sim
{
    internal class BuildingMenu : Menu
    {
        /// <summary>
        /// Prints buildings menu and calls buildings functions depending on user input
        /// </summary>
        public void RunMenu()
        {
            Console.Write("{0}-Properties-\n{0}1-Buy\n{0}2-Sell\n{0}3-Upgrade\n{0}4-View owned properties\n", _INDENT);
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("{0}{0}-Buy-\n{0}{0}1-Flat (10,000)\n{0}{0}2-House (20,000)\n{0}{0}3-Shop (50,000)\n{0}{0}4-Flat Block (100,000)\n"
                        + "{0}{0}5-Office (150,000)\n{0}{0}6-Shopping centre (500,000)\n{0}{0}7-Office block (1,500,000)\n{0}{0}8-Sky scraper (2,500,000)\n", _INDENT);

                    Building.BuildingType buildingTypeToBuy = SelectBuildingType(2);
                    if (buildingTypeToBuy != Building.BuildingType.Unknown)
                    {
                        game.cash = game.assets.Add(buildingTypeToBuy, game.cash);
                        PressKeyAndClear();
                    }
                    break;

                case '2':
                    Console.Write("{0}{0}-Sell-\n{0}{0}1-Flat\n{0}{0}2-House\n{0}{0}3-Shop\n{0}{0}4-Flat Block\n"
                        + "{0}{0}5-Office\n{0}{0}6-Shopping centre\n{0}{0}7-Office block\n{0}{0}8-Sky scraper\n", _INDENT);
                    Building.BuildingType buildingTypeToSell = SelectBuildingType(2);
                    if (!buildingTypeToSell.Equals(Building.BuildingType.Unknown))
                    {
                        Building buildingToSell = game.assets.Find(buildingTypeToSell);
                        if (buildingToSell != null)
                        {
                            game.cash += game.assets.Remove(buildingToSell);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '3':
                    Console.Write("{0}{0}-Upgrade-\n{0}{0}1-Flat\n{0}{0}2-House\n{0}{0}3-Shop\n{0}{0}4-Flat Block\n"
                        + "{0}{0}5-Office\n{0}{0}6-Shopping centre\n{0}{0}7-Office block\n{0}{0}8-Sky scraper\n", _INDENT);
                    Building.BuildingType buildingTypeToUpgrade = SelectBuildingType(2);
                    if (!buildingTypeToUpgrade.Equals(Building.BuildingType.Unknown))
                    {
                        Building buildingToUpgrade = game.assets.Find(buildingTypeToUpgrade);
                        if (buildingToUpgrade != null)
                        {
                            game.cash = game.assets.Upgrade(buildingToUpgrade, game.cash);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '4':
                    game.assets.ViewBuildings();
                    PressKeyAndClear();
                    break;

                default:
                    Console.WriteLine("{0}Invalid input", _INDENT);
                    PressKeyAndClear();
                    break;
            }
        }

        /// <summary>
        /// Gets user to select a building type
        /// </summary>
        /// <param name="indentSize">Number of indents for printed text</param>
        /// <returns>Building type selected by user</returns>
        private Building.BuildingType SelectBuildingType(int indentSize)
        {
            string indent = "";
            for (int i = 0; i != indentSize; i++)
            {
                indent += _INDENT;
            }
            Building.BuildingType returnValue = Building.BuildingType.Unknown;
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    returnValue = Building.BuildingType.Flat;
                    break;

                case '2':
                    returnValue = Building.BuildingType.House;
                    break;

                case '3':
                    returnValue = Building.BuildingType.Shop;
                    break;

                case '4':
                    returnValue = Building.BuildingType.FlatBlock;
                    break;

                case '5':
                    returnValue = Building.BuildingType.Office;
                    break;

                case '6':
                    returnValue = Building.BuildingType.ShoppingCentre;
                    break;

                case '7':
                    returnValue = Building.BuildingType.OfficeBlock;
                    break;

                case '8':
                    returnValue = Building.BuildingType.SkyScraper;
                    break;

                default:
                    Console.WriteLine(indent + "Invalid input");
                    PressKeyAndClear();
                    break;
            }
            return returnValue;
        }
    }
}