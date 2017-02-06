namespace Business_Sim
{
    internal class Employee
    {
        #region Constructors

        public Employee(EmployeeType employeeType)
        {
            this.employeeType = employeeType;
            switch (employeeType)
            {
                case EmployeeType.Worker:
                    buyPrice = 50.00M;
                    dailyOutcome = 10.00M;
                    break;

                case EmployeeType.Manager:
                    buyPrice = 500.00M;
                    dailyOutcome = 250.00M;
                    break;

                case EmployeeType.RegionalManager:
                    buyPrice = 10000.00M;
                    dailyOutcome = 5000.00M;
                    break;

                case EmployeeType.Administrator:
                    buyPrice = 1000000.00M;
                    dailyOutcome = 100000.00M;
                    break;

                case EmployeeType.Director:
                    buyPrice = 25000000.00M;
                    dailyOutcome = 500000.00M;
                    break;

                default:
                    buyPrice = 0.00M;
                    dailyOutcome = 0.00M;
                    break;
            }
        }

        #endregion Constructors

        #region Enums

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

        public decimal buyPrice { get; }
        public decimal dailyOutcome { get; private set; }
        public EmployeeType employeeType { get; }

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