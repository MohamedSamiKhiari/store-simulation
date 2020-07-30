using System;

namespace Kaufhaus
{
    public class Test
    {
        #region Main

        //Main
        private static void Main(string[] args)
        {
            //Variablen
            Test test = new Test();
            string userInput;

            //Begrüßungstext
            Console.WriteLine("Willkommen im KaDeWe\n");
            Console.WriteLine("Für Informationen geben sie bitte I ein");
            Console.WriteLine("Für den Ablauf einer Simulation bitte S eingeben");
            userInput = Console.ReadLine();

            //Menü
            switch (userInput)
            {
                case "i":
                    test.PrintOverview();
                    break;

                case "I":
                    test.PrintOverview();
                    break;

                case "s":
                    test.PrintSimulation();
                    break;

                case "S":
                    test.PrintSimulation();
                    break;

                default:
                    Console.WriteLine("Die Eingabe war nicht korrekt, das programm wird beendet!");
                    break;
            }

            Console.ReadKey();
        }

        #endregion Main

        //Methode zum Ausgeben aller Informationen
        public void PrintOverview()
        {
            //Objekte erstellen
            Mall mall = new Mall("KaDeWe , ", "Bleckeder Landstraße 1, 21335 Lüneburg");
            Department department = new Department("", 0, "");
            Stock stock = new Stock();

            Console.WriteLine("Kaufhaus: " + mall.GetName() + " " + mall.GetAdress());

            //Abteilungen ausgeben
            Console.WriteLine("\nAbteilungen: \n");
            mall.GetDepartmentList();

            //Angestellte ausgeben
            Console.WriteLine("\nAbteilungsleiter: \n");
            department.GetOfficerList();

            Console.WriteLine("\nAngestellte: \n");
            department.GetEmployeeList();

            //Artikel initialisieren
            Console.WriteLine("\nArtikel: \n");
            department.GetProductList();

            //Artikel ausgeben
            stock.PopulateStorage();
            stock.PrintStorageList("Elektroartikel");
            stock.PrintStorageList("Lebensmittel");
            stock.PrintStorageList("Kleidung");
            stock.PrintStorageList("Moebel");
            stock.PrintStorageList("Schmuck");
        }

        public void PrintSimulation()
        {
            //Initialisieren der Objekte
            TextLog logger = new TextLog();
            Simulation simulator = new Simulation();
            Stock stock = new Stock();

            Console.WriteLine("\nSimulation wird gestartet: \n");

            logger.InitializeLogger();

            for (int i = 1; i < 6; i++)
            {
                logger.SetLogFilePath("Log-" + simulator.GetSimulationDate().ToString("dd/MM/yyyy"));
                logger.CreateLogFile();

                Console.WriteLine("\nSimuliere Tag: " + i + "\n");

                simulator.SimulateADay();
                simulator.IncrementDate();

                logger.EndLoggersWorkDay();

                stock.CalculateDailyEarnings();
                stock.PrintStock();

                stock.ReOrder();

                Console.WriteLine("\nTag: " + i + " beendet.\n");
            }
        }
    }
}