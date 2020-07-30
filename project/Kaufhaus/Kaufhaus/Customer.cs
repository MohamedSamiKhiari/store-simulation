using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Kaufhaus
{
    public class Customer
    {
        #region fields

        //Objektvariablen
        private string _firstName;

        private string _lastName;
        private string _street;
        private string _city;
        private string _birthDate;
        private string _customerID;

        //ID für Kunden (optional?)
        private List<String> _givenIds = new List<string>();

        #endregion fields

        #region properties

        //Objekt properties
        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetStreet()
        {
            return _street;
        }

        public string GetCity()
        {
            return _city;
        }

        public string GetBirthDate()
        {
            return _birthDate;
        }

        public string GetCustomerID()
        {
            return _customerID;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor
        public Customer(string customerID, string firstName, string lastName, string street, string city, string birthDate)
        {
            _customerID = customerID;
            _firstName = firstName;
            _lastName = lastName;
            _street = street;
            _city = city;
            _birthDate = birthDate;
        }

        #endregion ctor

        #region Methods

        //Methide zum generieren der Kundenliste
        public List<Customer> GetCustomerList()
        {
            //Create a new WebClient
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            //Liste für die Customer
            List<Customer> _customerList = new List<Customer>();

            try
            {
                for (int i = 0; i < 12; i++)
                {
                    //Download data as string
                    string xml =
                        wc.DownloadString("https://randomuser.me/api/?inc=name,location,dob&nat=de&format=xml&noinfo");

                    //Parse XML
                    XDocument xdoc = XDocument.Parse(xml);

                    //Get values to String
                    string firstName = xdoc.Root.Element("results").Element("name").Element("first").Value;
                    string lastName = xdoc.Root.Element("results").Element("name").Element("last").Value;
                    string street = xdoc.Root.Element("results").Element("location").Element("street").Value;
                    string city = xdoc.Root.Element("results").Element("location").Element("city").Value;
                    string birthDate = xdoc.Root.Element("results").Element("dob").Element("date").Value.Split('T')[0];

                    //Kunden zur Liste hinzufügen
                    Customer kunden = new Customer("", "", "", "", "", "");
                    _customerList.Add(new Customer(kunden.SetCustomerID(), firstName, lastName, street, city, birthDate));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Der Webserver hat versagt --> GetCustomerList");
            }

            return _customerList;
        }

        //Methode zum setzten der Kunden ID
        private string SetCustomerID()
        {
            string rndNr = GenerateRandomNumber();

            if (_givenIds.Contains(rndNr))
            {
                return GenerateRandomNumber();
            }
            else
            {
                return rndNr;
            }
        }

        //Methode zum Generieren von Zufallszahlen
        private string GenerateRandomNumber()
        {
            Random rndValue = new Random();
            string rndNr = rndValue.Next(0, 99999).ToString("D5");
            _givenIds.Add(rndNr);
            return rndNr;
        }

        #endregion Methods
    }
}