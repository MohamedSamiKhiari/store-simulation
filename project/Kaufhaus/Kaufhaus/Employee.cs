namespace Kaufhaus
{
    public class Employee
    {
        #region fields

        //Objektvariablen
        public string _employeeName { get; set; }

        public int _employeeAge { get; set; }
        public int _employeeSalary { get; set; }
        public string _employeeDepartment { get; set; }

        #endregion fields

        #region properties

        //Objekt Properties
        public string GetName()
        {
            return _employeeName;
        }

        public int GetAge()
        {
            return _employeeAge;
        }

        public int GetSalary()
        {
            return _employeeSalary;
        }

        public string GetDepartment()
        {
            return _employeeDepartment;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor
        public Employee(string employeeName, int employeeAge, int employeeSalary, string employeeDepartment)
        {
            _employeeName = employeeName;
            _employeeAge = employeeAge;
            _employeeSalary = employeeSalary;
            _employeeDepartment = employeeDepartment;
        }

        #endregion ctor
    }
}