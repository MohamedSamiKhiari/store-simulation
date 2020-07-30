using System;
using System.IO;
using System.Reflection;

namespace Kaufhaus
{
    public class TextLog
    {
        #region fields

        //Obejktvariablen
        //Pfad der Applikation finden
        private static string _logDataLocation;

        private static string _logDirectoryLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Log";

        #endregion fields

        #region properties

        //Obejekt properties

        #endregion properties

        #region ctor

        //Überladener Konstruktor

        #endregion ctor

        #region Methods

        //Methode zum Loggen
        public void CreateLogFile()
        {
            try
            {
                TextWriter textWriter = new StreamWriter(_logDataLocation, true);
                Console.Write("\nLog Data was generated... \n");
                textWriter.WriteLine("KaDeWe Log");
                Console.WriteLine("\nKaDeWe Log");
                textWriter.WriteLine("8:00 Uhr - Opening of the Store");
                Console.WriteLine("8:00 Uhr - Opening of the Store");

                textWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Methode zum überprüfen der Logs
        public void InitializeLogger()
        {
            //Überprüfen ob Ordner für Log Dateien existiert
            if (Directory.Exists(_logDirectoryLocation))
            {
                try
                {
                    Console.WriteLine("Lösche alten Log Ordner...");
                    Directory.Delete(_logDirectoryLocation, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Irgendwo ist da wohl noch der Log Order offen... --> Initialize Logger");
                    throw;
                }

                Console.WriteLine("Lege neuen Log Ordner an...");
                Directory.CreateDirectory(_logDirectoryLocation);
            }
            else
            {
                try
                {
                    Console.WriteLine("Lege neuen Log Ordner an...");
                    Directory.CreateDirectory(_logDirectoryLocation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        //Methode zum schreiben ins Log
        public void WriteToLog(string logline)
        {
            TextWriter textWriter = new StreamWriter(_logDataLocation, true);
            textWriter.WriteLine(logline);
            textWriter.Close();
        }

        //Methode die den tag abschließt
        public void EndLoggersWorkDay()
        {
            TextWriter textWriter = new StreamWriter(_logDataLocation, true);
            Console.Write("\n20:00 Uhr - Schließung des Kaufhauses\n");
            textWriter.WriteLine("\n20:00 Uhr - Schließung des Kaufhauses");
            textWriter.Close();
        }

        //Methode zum setzten der LogFile Paths
        public string SetLogFilePath(string logname)
        {
            _logDataLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Log\\" + logname + ".txt";
            return _logDataLocation;
        }

        #endregion Methods
    }
}