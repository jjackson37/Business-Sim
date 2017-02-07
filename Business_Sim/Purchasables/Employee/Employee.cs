namespace Business_Sim
{
    /// <summary>
    /// Allows buildings to earn income, cost outcome per day
    /// </summary>
    internal class Employee
    {
        #region Constructors

        /// <summary>
        /// Creates a employee object and sets all default properties of the employee depending on the type being created
        /// </summary>
        /// <param name="employeeType">Employee type to add</param>
        public Employee(EmployeeType employeeType)
        {
            this.employeeType = employeeType;
            switch (employeeType)
            {
                case EmployeeType.Worker:
                    buyPrice = 50.00M;
                    dailyOutcome = 10.00M;
                    dailyIncome = 12.00M;
                    break;

                case EmployeeType.Manager:
                    buyPrice = 500.00M;
                    dailyOutcome = 250.00M;
                    dailyIncome = 260.00M;
                    break;

                case EmployeeType.RegionalManager:
                    buyPrice = 10000.00M;
                    dailyOutcome = 5000.00M;
                    dailyIncome = 5050.00M;
                    break;

                case EmployeeType.Administrator:
                    buyPrice = 1000000.00M;
                    dailyOutcome = 100000.00M;
                    dailyIncome = 100100.00M;
                    break;

                case EmployeeType.Director:
                    buyPrice = 25000000.00M;
                    dailyOutcome = 500000.00M;
                    dailyIncome = 501000.00M;
                    break;

                default:
                    buyPrice = 0.00M;
                    dailyOutcome = 0.00M;
                    dailyIncome = 0.00M;
                    break;
            }
        }

        #endregion Constructors

        #region Enums

        /// <summary>
        /// Employee type
        /// </summary>
        public enum EmployeeType
        {
            Unknown = 0,
            Worker = 1,
            Manager = 2,
            RegionalManager = 3,
            Administrator = 4,
            Director = 5
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Price to intially hire the employee
        /// </summary>
        public decimal buyPrice { get; }

        /// <summary>
        /// TEMP: Income earned daily
        /// </summary>
        public decimal dailyIncome { get; }

        /// <summary>
        /// Cost of the employee per day
        /// </summary>
        public decimal dailyOutcome { get; }

        /// <summary>
        /// Type of the employee
        /// </summary>
        public EmployeeType employeeType { get; }

        //TODO: Remove daily income from employees
        /// <summary>
        /// Returns the employee type as a string
        /// </summary>
        public string employeeTypeString
        {
            get
            {
                string returnString = "Unknown";
                switch (employeeType)
                {
                    case EmployeeType.Worker:
                        returnString = "Worker";
                        break;

                    case EmployeeType.Manager:
                        returnString = "Manager";
                        break;

                    case EmployeeType.RegionalManager:
                        returnString = "RegionalManager";
                        break;

                    case EmployeeType.Administrator:
                        returnString = "Administrator";
                        break;

                    case EmployeeType.Director:
                        returnString = "Director";
                        break;

                    default:
                        returnString = "Unknown";
                        break;
                }
                return returnString;
            }
        }

        #endregion Properties
    }
}