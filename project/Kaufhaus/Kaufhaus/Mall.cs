using System;
using System.Collections.Generic;

namespace Kaufhaus
{
    public class Mall
    {
        #region fields

        //Objektvariablen
        private string _mallName;

        private string _mallAdress;
        private List<Department> _mallDepartmentList = new List<Department>();

        #endregion fields

        #region properties

        //Object properties
        public string GetName()
        {
            return _mallName;
        }

        public string GetAdress()
        {
            return _mallAdress;
        }

        public List<Department> GetMallDepartmentList()
        {
            return _mallDepartmentList;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor
        public Mall(string mallName, string mallAdress)
        {
            _mallName = mallName;
            _mallAdress = mallAdress;
        }

        #endregion ctor

        #region Methods

        //Methode zum erstellen der Department List
        public void GetDepartmentList()
        {
            //Liste der Abteilungen
            _mallDepartmentList.Add(new Department("Elektroartikel", 450, "Erik Range"));
            _mallDepartmentList.Add(new Department("Lebensmittel", 90, "Markus Mensch"));
            _mallDepartmentList.Add(new Department("Kleidung", 180, "Paul Würdig"));
            _mallDepartmentList.Add(new Department("Möbel", 800, "Bylent Ceylan"));
            _mallDepartmentList.Add(new Department("Schmuck", 350, "Jan Ohakys"));

            //PrintOut der Abteilungen
            foreach (Department abt in _mallDepartmentList)
            {
                Console.WriteLine(abt.GetName() + ", " + abt.GetSize() + " qm, Abteilungsleiter: " + abt.GetOfficer());
            }
        }

        #endregion Methods
    }
}