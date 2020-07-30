using System;
using System.Collections.Generic;

namespace Kaufhaus
{
    public class Product
    {
        #region fields

        //Objektvariablen
        private string _productName;

        private string _productNumber;
        private float _productBuyPrice;
        private float _productSellPrice;
        private float _productEarnings;
        private int _productMinStock;
        private int _productStock;
        private int _productStockLocation;

        private List<String> givenIds = new List<string>();

        #endregion fields

        #region properties

        //Objekt Properties
        public string GetName()
        {
            return _productName;
        }

        public string GetArticleNumber()
        {
            return _productNumber;
        }

        public float GetBuyPrice()
        {
            return _productBuyPrice;
        }

        public float GetSellPrice()
        {
            return _productSellPrice;
        }

        public int GetMinStock()
        {
            return _productMinStock;
        }

        public int GetProductStock()
        {
            return _productStock;
        }

        public int GetProductStockLocation()
        {
            return _productStockLocation;
        }

        #endregion properties

        #region ctor

        //Überladener Konstruktor
        public Product(string productName, float productBuyPrice, float productSellPrice, int productMinStock, int productStockLocation)
        {
            _productName = productName;
            _productNumber = SetProductNumber();
            _productBuyPrice = productBuyPrice;
            _productSellPrice = productSellPrice;
            _productMinStock = productMinStock;
            _productStock = SetProductStock();
            _productStockLocation = productStockLocation;
        }

        #endregion ctor

        #region Methods

        //Methode zum berechnen des Gewinns
        public float CalculateProductEarnings(float productSellPrice, float productBuyPrice)
        {
            //Berechnen des Gewinns
            _productEarnings = productSellPrice - productBuyPrice;
            return _productEarnings;
        }

        //Methode zum setzten zufälliger Produktnummern
        private string SetProductNumber()
        {
            string rndNr = GenerateRandomNumber();

            if (givenIds.Contains(rndNr))
            {
                return GenerateRandomNumber();
            }
            else
            {
                return rndNr;
            }
        }

        //Methode zum generieren zufälliger Nummern
        private string GenerateRandomNumber()
        {
            Random rndValue = new Random();
            string rndNr = rndValue.Next(0, 99999).ToString("D5");
            givenIds.Add(rndNr);
            return rndNr;
        }

        //Methode zum setzten des Lagerbestandes
        private int SetProductStock()
        {
            Random rndValue = new Random();
            int rndStock = rndValue.Next(500, 5000);

            return rndStock;
        }

        #endregion Methods
    }
}