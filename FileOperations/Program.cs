using System;
using System.IO;

namespace FileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte wählen Sie eine Option:");
            Console.WriteLine("1: Datei lesen");
            Console.WriteLine("2: Datei schreiben");
            Console.WriteLine("Drücken Sie eine beliebige Taste, um das Programm zu beenden...");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ReadFile();
                    break;
                case "2":
                    WriteToFile();
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }

            Console.WriteLine("Drücken Sie die Eingabetaste, um das Programm zu beenden...");
            Console.ReadLine(); // Wartet auf eine Benutzereingabe, bevor das Programm geschlossen wird
        }

        static void ReadFile()
        {
            string inputFilePath = @"C:\Users\051505\source\repos\FileOperations\input.txt";

            // Überprüfen, ob die Datei existiert
            if (File.Exists(inputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    string line;
                    Console.WriteLine("Inhalt der Datei input.txt:");
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line); // Zeilen in der Konsole ausgeben
                    }
                }
            }
            else
            {
                Console.WriteLine("Die Datei input.txt existiert nicht.");
            }
        }

        static void WriteToFile()
        {
            string inputFilePath = @"C:\Users\051505\source\repos\FileOperations\input.txt";
            string outputFilePath = @"C:\Users\051505\source\repos\FileOperations\output.txt"; // Neuer Pfad

            if (File.Exists(inputFilePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(inputFilePath))
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                writer.WriteLine(line); // Schreibe jede Zeile in die Ausgabedatei
                            }
                        }
                    }
                    Console.WriteLine("Daten wurden erfolgreich in output.txt geschrieben.");
                }
                catch (Exception ex)
                {
                    // Zeigt einen Fehler an, wenn das Schreiben in die Datei fehlschlägt
                    Console.WriteLine("Fehler beim Schreiben in die Datei: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Die Datei input.txt existiert nicht.");
            }
        }
    }
}
