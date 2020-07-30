using System.Collections.Generic;

namespace Kaufhaus
{
    public class Officer : Employee
    {
        #region fields

        //Objektvariablen
        private int _officersDesk;

        private List<Employee> _officerEmployees = new List<Employee>();

        #endregion fields

        #region properties

        public List<Employee> GetOfficersEmployees()
        {
            return _officerEmployees;
        }

        #endregion properties

        #region ctor

        public Officer(string officerName, int officerAge, int officerSalary, string officerDepartment, string officerOfficer, List<Employee> officerEmployees, int officersDesk) : base(officerName, officerAge, officerSalary, officerDepartment)
        {
            _employeeName = officerName;
            _employeeAge = officerAge;
            _employeeSalary = officerSalary;
            _employeeDepartment = officerDepartment;
            _officersDesk = officersDesk;
            _officerEmployees = officerEmployees;
        }

        #endregion ctor
    }
}