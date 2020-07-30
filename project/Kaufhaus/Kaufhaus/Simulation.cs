using System;
using System.Collections.Generic;
using System.Linq;

namespace Kaufhaus
{
    public class Simulation
    {
        #region fields

        //Objektvariablen

        private bool _customerArrival;
        private bool _sameCustomerAgain = false;
        private DateTime _simulationDate = new DateTime(2020, 01, 10, 8, 0, 0);

        //Listen
        private List<Customer> _customerList = new List<Customer>();

        private List<Customer> _comebackCustomer = new List<Customer>();
        private List<Product> _productsToChoose = new List<Product>();
        private static Dictionary<Product, int> _soldProducts = new Dictionary<Product, int>();
        private List<int> _amountOfSoldProducts = new List<int>();

        //Logger
        private TextLog txtlog = new TextLog();

        //Customer
        private Customer customer = new Customer("", "", "", "", "", "");

        #endregion fields

        #region properties

        //Objekt properties

        public Dictionary<Product, int> GetSoldProducts()
        {
            return _soldProducts;
        }

        public DateTime GetSimulationDate()
        {
            return _simulationDate;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor

        #endregion ctor

        #region Methods

        //Methode für die Simulation eines Tages
        public void SimulateADay()
        {
            //Kundenliste generieren
            _customerList = customer.GetCustomerList();

            //Date ausgeben
            Console.WriteLine("\nToday is the: ");
            Console.WriteLine(_simulationDate.ToString("dd/MM/yyyy") + "\n");
            txtlog.WriteToLog("\nToday is the: " + _simulationDate.ToString("dd/MM/yyyy"));

            //8-20 Uhr = 12 Stunden
            for (int i = 0; i < 13; i++)
            {
                //Ausgeben der Zeit
                Console.WriteLine("\nTime: " + _simulationDate.Hour);
                txtlog.WriteToLog("\nTime: " + _simulationDate.Hour);

                //Zeit läuft weiter
                DateTime tmpDate = _simulationDate.AddHours(1);
                _simulationDate = tmpDate;

                //products to Choose
                PopulateProductsToChoose();

                //Kommt ein Kunde in den Laden 75%
                CustomerArrivalProbability();

                //Kunden wahrschinelichkeiten
                if (_customerArrival == true)
                {
                    Console.WriteLine("A Customer Arrived");
                    txtlog.WriteToLog("A Customer Arrived");
                    if (_sameCustomerAgain == true)
                    {
                        Console.WriteLine("The Customer, " + ChooseACustomer().GetFirstName() + " came back");
                        txtlog.WriteToLog("The Customer, " + ChooseACustomer().GetFirstName() + " came back");
                        PrintCustomerProductChoice();
                    }
                    else
                    {
                        Console.WriteLine("His/Her name is: " + ChooseACustomer().GetFirstName());
                        txtlog.WriteToLog("His/Her name is: " + ChooseACustomer().GetFirstName());
                        PrintCustomerProductChoice();
                    }
                }
                else
                {
                    Console.WriteLine("No Customer comes in...");
                    txtlog.WriteToLog("No Customer comes in...");
                }

                //Kommt ein Kunde der bereits da war 20% / das ist hier unten damit der erste durchlauf immer mit false beginnt
                SameCustomerProbability();
            }
        }

        //Methode zum vergehen lassen von Tagen
        public DateTime IncrementDate()
        {
            string currentday = _simulationDate.ToString("dd");
            int nextday = Int16.Parse(currentday) + 1;

            DateTime tmpDate = new DateTime(2020, 01, nextday, 8, 0, 0);

            _simulationDate = tmpDate;
            return _simulationDate;
        }

        //Methoden die mit Wahrscheinlichkeit der Kunden zutun haben
        private bool CustomerArrivalProbability()
        {
            //75% wahscheinlichkeit auf Kunde jede Stunde (nicht wirklich "fancy" aber bei  probability <= 25 und 10000000 iterationen bekomme ich 0.2497 also ungerundet 24,97%)
            int probability = GetRndValue(1, 101);

            if (probability <= 75)
            {
                _customerArrival = true;
            }
            else
            {
                _customerArrival = false;
            }
            return _customerArrival;
        }

        private bool SameCustomerProbability()
        {
            //20% wahscheinlichkeit auf den gleichen Kunden nochmal (nicht wirklich "fancy" aber bei  probability <= 25 und 10000000 iterationen bekomme ich 0.2497 also ungerundet 24,97%)
            int probability = GetRndValue(1, 101);

            if (probability <= 20)
            {
                _sameCustomerAgain = true;
            }
            else
            {
                _sameCustomerAgain = false;
            }
            return _customerArrival;
        }

        private Customer ChooseACustomer()
        {
            try
            {
                //Wenn der Kunde bereits da war
                if (_sameCustomerAgain == true)
                {
                    int rndValueSame = GetRndValue(0, _comebackCustomer.Count);
                    return _comebackCustomer[rndValueSame];
                }
                //Wenn der Kunde noch nicht da war
                else
                {
                    int rndValueDifferent = GetRndValue(0, _customerList.Count);

                    Customer tmpCust = _customerList[rndValueDifferent];

                    _comebackCustomer.Add(_customerList[rndValueDifferent]);
                    //_customerList.RemoveAt(rndValueDifferent);

                    return tmpCust;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Die Mäuse sind in den Computer geklettert und haben ein Paar Kabel zerbissen, probier es noch einmal --> ChooseACustomer");
                throw;
            }
        }

        //Methoden die mit der Produktauswahl der Kunden zutun haben
        public List<Product> CustomerProductDecision(List<Product> productsToChoose)
        {
            //Liste der jeweiligen Produkte zu kunden
            List<Product> productsToCustomer = new List<Product>();

            for (int i = 0; i < 3; i++)
            {
                //Rnd für Artikelanzahl
                int rndProduct = GetRndValue(0, productsToChoose.Count);

                if (productsToChoose[rndProduct].GetProductStock() == 0)
                {
                    Console.WriteLine("The Product the Customer wants is out of Stock");
                }
                else
                {
                    productsToCustomer.Add(productsToChoose[rndProduct]);
                }
            }

            return productsToCustomer;
        }

        private void PrintCustomerProductChoice()
        {
            //dictionary für die Anzahl der verkäufe
            foreach (Product ar in CustomerProductDecision(_productsToChoose))
            {
                int buytimes = GetRndValue(1, 3);

                if (_soldProducts.ContainsKey(ar))
                {
                    foreach (Product art in _soldProducts.Keys.ToList())
                    {
                        if (art == ar)
                        {
                            _soldProducts[art] = _soldProducts[art] + buytimes;
                        }
                    }
                }
                else
                {
                    _soldProducts.Add(ar, buytimes);
                }

                //Ausgabe
                _amountOfSoldProducts.Add(buytimes);
                Console.WriteLine("He/She bought: " + ar.GetName() + " " + buytimes + " times" + " and the price was: " + ar.GetSellPrice() * buytimes + " Euro");
                txtlog.WriteToLog("He/She bought: " + ar.GetName() + " " + buytimes + " times" + " and the price was: " + ar.GetSellPrice() * buytimes + " Euro");
            }
        }

        private int GetRndValue(int from, int to)
        {
            Random rnd = new Random();
            int rndProduct = rnd.Next(from, to);
            return rndProduct;
        }

        public void PopulateProductsToChoose()
        {
            //Einmaliges ausführen von GetProductList() zum füllen der _productsToChoose Liste
            Department productList = new Department("", 0, "");

            productList.GetProductList();

            _productsToChoose = productList.GetCompleteProductList();
        }

        #endregion Methods
    }
}