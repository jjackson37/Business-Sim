using System;

namespace Business_Sim
{
    internal class EmployeeMenu : Menu
    {
        #region Fields

        private Game currentGame;

        #endregion Fields

        #region Constructors

        public EmployeeMenu(ref Game currentGame)
        {
            this.currentGame = currentGame;
        }

        #endregion Constructors

        //TODO: Remove WIP tags from text

        #region Methods

        /// <summary>
        /// Prints Employees menu and calls employees functions depending on user input
        /// </summary>
        public void RunMenu()
        {
            Console.Write("{0}-Employees (WIP)-\n{0}1-Hire\n{0}2-Fire\n{0}3-View current employees\n", _INDENT);
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Write("{0}{0}-Hire-\n{0}{0}1-Worker (50)\n{0}{0}2-Manager (500)\n{0}{0}3-Regional manager (10,000)\n"
                        + "{0}{0}4-Administrator (1,000,000)\n{0}{0}5-Director (25,000,000)\n", _INDENT);

                    Employee.EmployeeType employeeTypeToBuy = SelectEmployeeType(2);
                    if (employeeTypeToBuy != Employee.EmployeeType.Unknown)
                    {
                        currentGame.cash = currentGame.assets.Add(employeeTypeToBuy, currentGame.cash);
                        PressKeyAndClear();
                    }
                    break;

                case '2':
                    Console.Write("{0}{0}-Fire-\n{0}{0}1-Worker\n{0}{0}2-Manager\n{0}{0}3-Regional manager\n{0}{0}4-Administrator\n"
                        + "{0}{0}5-Director\n", _INDENT);
                    Employee.EmployeeType employeeTypeToFire = SelectEmployeeType(2);
                    if (!employeeTypeToFire.Equals(Employee.EmployeeType.Unknown))
                    {
                        Employee employeeToFire = currentGame.assets.Find(employeeTypeToFire);
                        if (employeeToFire != null)
                        {
                            currentGame.assets.Remove(employeeToFire);
                        }
                        PressKeyAndClear();
                    }
                    break;

                case '3':
                    currentGame.assets.ViewEmployees();
                    PressKeyAndClear();
                    break;

                default:
                    Console.WriteLine("{0}Invalid input", _INDENT);
                    PressKeyAndClear();
                    break;
            }
        }

        /// <summary>
        /// Gets user to select a employee type
        /// </summary>
        /// <param name="indentSize">Number of indents for printed text</param>
        /// <returns>Employee type selected by user</returns>
        private Employee.EmployeeType SelectEmployeeType(int indentSize)
        {
            string indent = "";
            for (int i = 0; i != indentSize; i++)
            {
                indent += "    ";
            }
            Employee.EmployeeType returnValue = Employee.EmployeeType.Unknown;
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    returnValue = Employee.EmployeeType.Worker;
                    break;

                case '2':
                    returnValue = Employee.EmployeeType.Manager;
                    break;

                case '3':
                    returnValue = Employee.EmployeeType.RegionalManager;
                    break;

                case '4':
                    returnValue = Employee.EmployeeType.Administrator;
                    break;

                case '5':
                    returnValue = Employee.EmployeeType.Director;
                    break;

                default:
                    returnValue = Employee.EmployeeType.Unknown;
                    break;
            }
            return returnValue;
        }

        #endregion Methods
    }
}