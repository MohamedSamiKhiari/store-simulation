using System;
using System.Collections.Generic;

namespace Kaufhaus
{
    public class Department
    {
        #region fields

        //Objektvariablen
        private string _departmentName;

        private int _departmentSize;
        private string _departmentOfficer;

        //Listen Produkte
        private static List<Product> _completeProductList = new List<Product>();

        //Listen Produkte per Abteilung
        private List<Product> _productListElektroartikel = new List<Product>();

        private List<Product> _productListLebensmittel = new List<Product>();
        private List<Product> _productListKleidung = new List<Product>();
        private List<Product> _productListMoebel = new List<Product>();
        private List<Product> _productListSchmuck = new List<Product>();

        //Liste Abteilungsleiter
        private List<Officer> _completeOfficerList = new List<Officer>();

        //Listen Angestellte per Abteilung
        private List<Employee> employeeListElektroartikel = new List<Employee>();

        private List<Employee> employeeListKleidung = new List<Employee>();
        private List<Employee> employeeListLebensmittel = new List<Employee>();
        private List<Employee> employeeListMoebel = new List<Employee>();
        private List<Employee> employeeListSchmuck = new List<Employee>();

        #endregion fields

        #region properties

        //Objekt Properties
        public string GetName()
        {
            return _departmentName;
        }

        public int GetSize()
        {
            return _departmentSize;
        }

        public string GetOfficer()
        {
            return _departmentOfficer;
        }

        //Listen für das Lager
        public List<Product> GetProductListElektroartikel()
        {
            return _productListElektroartikel;
        }

        public List<Product> GetProductListLebensmittel()
        {
            return _productListLebensmittel;
        }

        public List<Product> GetProductListKleidung()
        {
            return _productListKleidung;
        }

        public List<Product> GetProductListMoebel()
        {
            return _productListMoebel;
        }

        public List<Product> GetProductListSchmuck()
        {
            return _productListSchmuck;
        }

        public List<Product> GetCompleteProductList()
        {
            return _completeProductList;
        }

        public List<Officer> GetCompleteOfficerList()
        {
            return _completeOfficerList;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor
        public Department(string departmentName, int departmentSize, string departmentOfficer)
        {
            _departmentName = departmentName;
            _departmentSize = departmentSize;
            _departmentOfficer = departmentOfficer;
        }

        #endregion ctor

        #region Methods

        //Produktlisten erstellen
        public void GetProductList()
        {
            //Liste der Elektroartikel
            _productListElektroartikel.Add(new Product("Toaster", 30, 60, 500, 22));
            _productListElektroartikel.Add(new Product("Spülmaschine", 100, 150, 500, 23));

            //Liste der Lebensmittel
            _productListLebensmittel.Add(new Product("Dinkelbrot", 1, 3, 1350, 24));
            _productListLebensmittel.Add(new Product("Haferkleie", 1, 2, 1200, 25));

            //Liste der Kleidung
            _productListKleidung.Add(new Product("T-Shirt", 10, 15, 2000, 31));
            _productListKleidung.Add(new Product("Jeans", 20, 25, 500, 32));

            //Liste der Moebel
            _productListMoebel.Add(new Product("Sofa", 100, 350, 1500, 43));
            _productListMoebel.Add(new Product("Esstisch", 50, 450, 650, 44));

            //Liste des Schmucks
            _productListSchmuck.Add(new Product("Halskette", 200, 250, 100, 55));
            _productListSchmuck.Add(new Product("Ring", 15, 50, 450, 56));

            //Beheben eines unschönen Fehlers (Neu Instanzierte Produkte haben andere Signaturen und können mehrfach in Dictionaries auftreten)
            if (_completeProductList.Count == 0)
            {
                _completeProductList = new List<Product>(_productListElektroartikel.Count + _productListLebensmittel.Count + _productListKleidung.Count + _productListMoebel.Count + _productListSchmuck.Count);
                _completeProductList.AddRange(_productListElektroartikel);
                _completeProductList.AddRange(_productListLebensmittel);
                _completeProductList.AddRange(_productListKleidung);
                _completeProductList.AddRange(_productListMoebel);
                _completeProductList.AddRange(_productListSchmuck);
            }
        }

        //Angestelltenlisten erstellen
        public void GetEmployeeList()
        {
            //Liste der Angestellten
            //Liste Elektroartikel
            employeeListElektroartikel.Add(new Employee("Laura Müller", 18, 1700, "Elektroartikel"));
            employeeListElektroartikel.Add(new Employee("Horst Schlemmer", 61, 1850, "Elektroartikel"));

            //Liste Kleidung
            employeeListKleidung.Add(new Employee("Peter Smits", 20, 2400, "Kleidung"));
            employeeListKleidung.Add(new Employee("Sebastian Lentzen", 31, 2950, "Kleidung"));

            //Liste Lebensmittel
            employeeListLebensmittel.Add(new Employee("Kai Pflaume", 34, 2360, "Lebensmittel"));
            employeeListLebensmittel.Add(new Employee("Jonathan Apelt", 28, 2100, "Lebensmittel"));

            //Liste Moebel
            employeeListMoebel.Add(new Employee("Dennis Brammen", 42, 2600, "Möbel"));
            employeeListMoebel.Add(new Employee("Christian Stachelhaus", 44, 4200, "Möbel"));

            //Liste Schmuck
            employeeListSchmuck.Add(new Employee("Joerg Sprave", 46, 6280, "Schmuck"));
            employeeListSchmuck.Add(new Employee("Edga Wallace", 19, 1111, "Schmuck"));

            //Liste aller Angestellten
            var mallEmployeeList = new List<Employee>(employeeListElektroartikel.Count + employeeListKleidung.Count + employeeListLebensmittel.Count + employeeListMoebel.Count + employeeListSchmuck.Count);
            mallEmployeeList.AddRange(employeeListElektroartikel);
            mallEmployeeList.AddRange(employeeListKleidung);
            mallEmployeeList.AddRange(employeeListLebensmittel);
            mallEmployeeList.AddRange(employeeListMoebel);
            mallEmployeeList.AddRange(employeeListSchmuck);

            //PrintOut der Angestellten
            foreach (Employee ang in mallEmployeeList)
            {
                Console.WriteLine(ang.GetName() + ", " + ang.GetAge() + ", " + ang.GetDepartment());
            }
        }

        //Abteilungsleiterliste erstellen
        public void GetOfficerList()
        {
            //Liste der Abteilungsleiter
            _completeOfficerList.Add(new Officer("Erik Range", 28, 1700, "Elektroartikel", "", employeeListElektroartikel, 1));
            _completeOfficerList.Add(new Officer("Paul Würdig", 31, 1850, "Kleidung", "", employeeListKleidung, 2));
            _completeOfficerList.Add(new Officer("Markus Mensch", 74, 2360, "Lebensmittel", "", employeeListLebensmittel, 3));
            _completeOfficerList.Add(new Officer("Bylent Ceylan", 41, 2950, "Möbel", "", employeeListMoebel, 4));
            _completeOfficerList.Add(new Officer("Jan Ohakys", 68, 2100, "Schmuck", "", employeeListSchmuck, 5));

            //Liste der Abteilungsleiter ausgeben
            foreach (Officer off in _completeOfficerList)
            {
                Console.WriteLine(off.GetName() + ", " + off.GetAge() + ", " + off.GetDepartment());
            }
        }

        #endregion Methods
    }
}