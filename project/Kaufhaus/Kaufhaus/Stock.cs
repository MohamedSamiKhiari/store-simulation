using System;
using System.Collections.Generic;

namespace Kaufhaus
{
    public class Stock
    {
        #region fields

        //Objektvariablen
        private Dictionary<string, List<Product>> dict = new Dictionary<string, List<Product>>();

        //Simulator
        private Simulation simulator = new Simulation();

        //Textlog
        private TextLog txtlog = new TextLog();

        #endregion fields

        #region properties

        //Objekt properties

        #endregion properties

        #region ctor

        //Überladener Konstruktor

        #endregion ctor

        #region Methods

        //Methode für das Storage Dictionary
        public void PopulateStorage()
        {
            Department abt = new Department("", 0, "");
            abt.GetProductList();

            dict.Add("Elektroartikel", abt.GetProductListElektroartikel());
            dict.Add("Lebensmittel", abt.GetProductListLebensmittel());
            dict.Add("Kleidung", abt.GetProductListKleidung());
            dict.Add("Moebel", abt.GetProductListMoebel());
            dict.Add("Schmuck", abt.GetProductListSchmuck());
        }

        //Methode zum Ausgeben der Storage List
        public void PrintStorageList(string abteilung)
        {
            if (dict.ContainsKey(abteilung))
            {
                List<Product> value = dict[abteilung];
                foreach (Product art in value)
                {
                    Console.WriteLine(art.GetName() + ", " + art.GetArticleNumber());
                }
            }
        }

        //Reorder Methode
        public void ReOrder()
        {
            Console.WriteLine("\nCheck if reorder is necessary...");
            txtlog.WriteToLog("\nCheck if reorder is necessary...");

            //Den Bestand jedes Artikels überprüfen
            foreach (KeyValuePair<Product, int> kvp in simulator.GetSoldProducts())
            {
                //Wenn der neue Stock unter Min Stock --> nachbestellen
                if ((kvp.Key.GetProductStock() - kvp.Value) < kvp.Key.GetMinStock())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An Product got sold out!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The existence of: " + kvp.Key.GetName() + " is after the current day of sale on: " + (kvp.Key.GetProductStock() - kvp.Value) + " decreased and must be reordered");
                    txtlog.WriteToLog("The existence of: " + kvp.Key.GetName() + " is after the current day of sale on: " + (kvp.Key.GetProductStock() - kvp.Value) + " decreased and must be reordered");

                    //Bestand nachbestellen --> hier sollte der Logik Code stehen

                    Console.WriteLine(kvp.Key.GetName() + " got reordered: " + (kvp.Key.GetMinStock() * 2) + " times");
                    txtlog.WriteToLog(kvp.Key.GetName() + " got reordered: " + (kvp.Key.GetMinStock() * 2) + " times");
                    Console.ForegroundColor = ConsoleColor.White;

                    //Alten eintrag entfernen
                }
            }
            Console.WriteLine("finished reordering!");
            txtlog.WriteToLog("finished reordering!");
        }

        //Methode für die Ausgabe der Warenbestände
        public void PrintStock()
        {
            Console.WriteLine("\nStock: ");

            //Den Bestand jedes Artikels ausgeben
            foreach (KeyValuePair<Product, int> kvp in simulator.GetSoldProducts())
            {
                Console.WriteLine("Item: " + kvp.Key.GetName() + "\n Sold items: " + kvp.Value + "\n Start Stock: " + kvp.Key.GetProductStock() + "\n End Stock: " + (kvp.Key.GetProductStock() - kvp.Value));
                txtlog.WriteToLog("Item: " + kvp.Key.GetName() + "\n Sold items: " + kvp.Value + "\n Start Stock: " + kvp.Key.GetProductStock() + "\n End Stock: " + (kvp.Key.GetProductStock() - kvp.Value));
            }
        }

        //Methoden für die Gewinnberechnung
        public void CalculateDailyEarnings()
        {
            //Methodenvariablen
            float totalwin = 0;

            //Gewinn für jeden Artikel berechnen
            foreach (KeyValuePair<Product, int> kvp in simulator.GetSoldProducts())
            {
                totalwin = totalwin + (kvp.Key.CalculateProductEarnings(kvp.Key.GetSellPrice(), kvp.Key.GetBuyPrice()) * kvp.Value);
            }

            //Ausgabe
            Console.WriteLine("\nThe Daily profit was: " + totalwin + " Euro\n");
            txtlog.WriteToLog("\nThe Daily profit was: " + totalwin + " Euro\n");
        }

        #endregion Methods
    }
}