using System;
using System.Text;

namespace Kalkulationsrechner
{
    class Rechner
    {
        private static decimal ekp, anzahl, lep, rabatt, zkp, skonto, bkp, bk, bp, hk, skp, gewinn, bvp, skonto2, provi, zvk, rabatt2, nvp, ust, bvk, bevk,evk; // Variable:aber ohne Wert, da wir den Wert später in der Anwendung abfragen
        private static decimal berechnungrabatt, skontoberechnung, gewinnberechnung, proviberechnung, rabattberechnung, ustberechnung, skontoberechnung2;
        
        /* to-do:
         * fenster nach jedem Menüasuwahl und jeder Berechnung bereinigen
         * für timer Ladebalken einfügen
         * Menü umgestalten mittig ebenso Ausgabe der Rechnung bearbeiten
         * Ergebnisse grün alle Zwischenergebnisse gelb ! Done
         */

        static void Main(string[] args)
        {
            List<Daten> Data_input = new() // Liste mit einem Index von 0-18
            {
                new Daten() { Name = "Einkaufspreis " }, // 0
                new Daten() { Name = "Anzahl " }, // 1
                new Daten() { Name = "Listeneinkaufspreis "}, // 2
                new Daten() { Name = "Rabatt " }, // 3
                new Daten() { Name = "Zieleinkaufspreis " }, // 4
                new Daten() { Name = "Skonto " }, // 5
                new Daten() { Name = "Bareinkaufspreis " }, // 6
                new Daten() { Name = "Beschaffungskosten " }, // 7
                new Daten() { Name = "Bezugspreis " }, // 8
                new Daten() { Name = "Handlungskosten " }, // 9
                new Daten() { Name = "Selbstkostenpreis " }, // 10
                new Daten() { Name = "Gewinn " }, // 11
                new Daten() { Name = "Barverkaufspreis " }, // 12
                new Daten() { Name = "Provision " }, // 1315
                new Daten() { Name = "Zielverkaufspreis " }, // 14
                new Daten() { Name = "Nettoverkaufspreis " }, // 15
                new Daten() { Name = "Umsatzsteuer " }, // 16
                new Daten() { Name = "Bruttoverkaufspreis " }, // 17
                new Daten() { Name = "Bruttoeinzelverkaufspreis " }, // 18
            };

            Handelskalkulationsberechnung(Data_input);
        }

        static void Handelskalkulationsberechnung(List<Daten> Data_input)
        {
            bool not_sure = false;
            do
            {
                Query_Menue();
                ConsoleKeyInfo UserInput = Console.ReadKey();

                switch (UserInput.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Vorwaertskalkulation(Data_input);
                        do
                        {
                            Console.WriteLine("Möchten Sie noch eine Aufgabe berechnen?");
                            Query_Auswahl();
                            ConsoleKeyInfo UserInput1 = Console.ReadKey();
                            switch (UserInput1.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Vorwaertskalkulation(Data_input);
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.WriteLine("\n");
                                    Handelskalkulationsberechnung(Data_input);
                                    break;
                                default:
                                    not_sure = false;
                                    FehlermeldungColor2();
                                    break;
                            }
                        } while (not_sure == false);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Rueckwaertskalkulation(Data_input);
                        do
                        {
                            Console.WriteLine("Möchten Sie noch eine Aufgabe berechnen?");
                            Query_Auswahl();
                            ConsoleKeyInfo UserInput2 = Console.ReadKey();
                            switch (UserInput2.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Rueckwaertskalkulation(Data_input);
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.WriteLine("\n");
                                    Handelskalkulationsberechnung(Data_input);
                                    break;
                                default:
                                    not_sure = false;
                                    FehlermeldungColor2();
                                    break;
                            }
                        } while (not_sure == false);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Differenzberechnung(Data_input);
                        do
                        {
                            Console.WriteLine("Möchten Sie noch eine Aufgabe berechnen?");
                            Query_Auswahl();
                            ConsoleKeyInfo UserInput3 = Console.ReadKey();
                            switch (UserInput3.Key)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                    Differenzberechnung(Data_input);
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                    Console.WriteLine("\n");
                                    Handelskalkulationsberechnung(Data_input);
                                    break;
                                default:
                                    not_sure = false;
                                    FehlermeldungColor2();
                                    break;
                            }
                        } while (not_sure == false);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("\nTschüss");
                        break;
                    default:
                        not_sure = false;
                        FehlermeldungColor2();
                        break;
                }
            } while (not_sure == false);
        }

        private static void Vorwaertskalkulation(List<Daten> Data_input)
        {
            string titelname = "Handelskalkulation vorwärts";
            
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\n------------------------------------------------------------------------------------");
            Console.WriteLine("\n" + titelname);
            Console.Write("\n" + Data_input[0].Name);

            // wenn der User anstatt einer Zahl Buchstaben eingibt, wird solange wiederholt bis eine Zahl eingegeben wird
            while (!decimal.TryParse(Console.ReadLine(), out ekp))
                FehlermeldungColor();

            Console.Write(Data_input[1].Name);
            while (!decimal.TryParse(Console.ReadLine(), out anzahl))
                FehlermeldungColor();

            lep = ekp * anzahl;
            lep = decimal.Round(lep, 2);
            Trennlinie();
            Console.Write(Data_input[2].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(lep + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt))
                FehlermeldungColor();

            berechnungrabatt = lep * rabatt / 100;
            berechnungrabatt = decimal.Round(berechnungrabatt, 2);
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(berechnungrabatt + " €");
            Console.ResetColor();
            zkp = lep - berechnungrabatt;
            zkp = decimal.Round(zkp, 2);
            Trennlinie();
            Console.Write(Data_input[4].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zkp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto))
                FehlermeldungColor();

            skontoberechnung = zkp * skonto / 100;
            skontoberechnung = decimal.Round(skontoberechnung, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung + " €");
            Console.ResetColor();
            bkp = zkp - skontoberechnung;
            bkp = decimal.Round(bkp, 2);
            Trennlinie();
            Console.Write(Data_input[6].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bkp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[7].Name);
            while (!decimal.TryParse(Console.ReadLine(), out bk))
                FehlermeldungColor();

            bp = bkp + bk;
            bp = decimal.Round(bp, 2);
            Trennlinie();
            Console.Write(Data_input[8].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[9].Name);
            while (!decimal.TryParse(Console.ReadLine(), out hk))
                FehlermeldungColor();

            skp = bp + hk;
            ekp = decimal.Round(skp, 2);
            Trennlinie();
            Console.Write(Data_input[10].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(skp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[11].Name);
            while (!decimal.TryParse(Console.ReadLine(), out gewinn))
                FehlermeldungColor();

            gewinnberechnung = skp * gewinn / 100;
            gewinnberechnung = decimal.Round(gewinnberechnung, 2);
            Console.Write(Data_input[11].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(gewinnberechnung + " €");
            Console.ResetColor();
            bvp = skp + gewinnberechnung;
            bvp = decimal.Round(bvp, 2);
            Trennlinie();
            Console.Write(Data_input[12].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bvp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto2))
                FehlermeldungColor();

            Console.Write(Data_input[13].Name);
            while (!decimal.TryParse(Console.ReadLine(), out provi))
                FehlermeldungColor();

            skontoberechnung = bvp * skonto2 / (100 - (skonto2 + provi));
            skontoberechnung = decimal.Round(skontoberechnung, 2);
            proviberechnung = bvp * provi / (100 - (skonto2 + provi));
            proviberechnung = decimal.Round(proviberechnung, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung + " €");
            Console.ResetColor();
            Console.Write(Data_input[13].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(proviberechnung + " €");
            Console.ResetColor();
            zvk = bvp + skontoberechnung + proviberechnung;
            zvk = decimal.Round(zvk, 2);
            Trennlinie();
            Console.Write(Data_input[14].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zvk + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt2))
                FehlermeldungColor();

            rabattberechnung = zvk * rabatt2 / (100 - rabatt2);
            rabattberechnung = decimal.Round(rabattberechnung, 2);  
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(rabattberechnung + " €");
            Console.ResetColor();
            nvp = zvk + rabattberechnung;
            nvp = decimal.Round(nvp, 2);
            Trennlinie();
            Console.Write(Data_input[15].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nvp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[16].Name);
            while (!decimal.TryParse(Console.ReadLine(), out ust))
                FehlermeldungColor();

            ustberechnung = nvp * ust / 100;
            ustberechnung = decimal.Round(ustberechnung, 2);
            Console.Write(Data_input[16].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ustberechnung + " €");
            Console.ResetColor();
            bvk = nvp + ustberechnung;
            bvk = decimal.Round(bvk, 2);
            Trennlinie();
            Console.Write(Data_input[17].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bvk + " €");
            Console.ResetColor();

            bevk = bvk / anzahl;
            bevk = decimal.Round(bevk, 2);
            Trennlinie();
            Console.Write(Data_input[18].Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(bevk + " €");
            Console.ResetColor();
            Trennlinie();
        }

        private static void Rueckwaertskalkulation(List<Daten> Data_input)
        {
            string titelname2 = "Handelskalkulation rückwärts";
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\n------------------------------------------------------------------------------------");
            Console.WriteLine("\n" + titelname2);
            Console.Write("\n" + Data_input[17].Name);
            while (!decimal.TryParse(Console.ReadLine(), out bvk))
                FehlermeldungColor();

            Console.Write(Data_input[16].Name);
            while (!decimal.TryParse(Console.ReadLine(), out ust))
                FehlermeldungColor();

            ustberechnung = bvk * ust / (100 + ust);
            ustberechnung = decimal.Round(ustberechnung, 2);
            Console.Write(Data_input[16].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ustberechnung + " €");
            Console.ResetColor();
            nvp = bvk - ustberechnung;
            nvp = decimal.Round(nvp, 2);
            Trennlinie();
            Console.Write(Data_input[15].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nvp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt2))
                FehlermeldungColor();

            rabattberechnung = nvp * rabatt2 / 100;
            rabattberechnung = decimal.Round(rabattberechnung, 2);
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(rabattberechnung + " €");
            Console.ResetColor();
            zvk = nvp - rabattberechnung;
            zvk = decimal.Round(zvk, 2);
            Trennlinie();
            Console.Write(Data_input[14].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zvk + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto))
                FehlermeldungColor();

            Console.Write(Data_input[13].Name);
            while (!decimal.TryParse(Console.ReadLine(), out provi))
                FehlermeldungColor();

            skontoberechnung = zvk * skonto / 100;
            skontoberechnung = decimal.Round(skontoberechnung, 2);
            proviberechnung = zvk * provi / 100;
            proviberechnung = decimal.Round(proviberechnung, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung + " €");
            Console.ResetColor();
            Console.Write(Data_input[13].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(proviberechnung + " €");
            Console.ResetColor();

            bvp = zvk - proviberechnung - skontoberechnung;
            bvp = decimal.Round(bvp, 2);
            Trennlinie();
            Console.Write(Data_input[12].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bvp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[11].Name);
            while (!decimal.TryParse(Console.ReadLine(), out gewinn))
                FehlermeldungColor();

            gewinnberechnung = bvp * gewinn / (100 + gewinn);
            gewinnberechnung = decimal.Round(gewinnberechnung, 2);
            Console.Write(Data_input[11].Name);
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.WriteLine(gewinnberechnung + " €");
            Console.ResetColor();

            skp = bvp - gewinnberechnung;
            skp = decimal.Round(skp, 2);
            Trennlinie();
            Console.Write(Data_input[10].Name);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(skp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[9].Name);
            while (!decimal.TryParse(Console.ReadLine(), out hk))
                FehlermeldungColor();

            bp = skp - hk;
            bp = decimal.Round(bp, 2);
            Trennlinie();
            Console.Write(Data_input[8].Name);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(bp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[7].Name);
            while (!decimal.TryParse(Console.ReadLine(), out bk))
                FehlermeldungColor();

            bk = bp - bk;
            bk = decimal.Round(bk, 2);
            Trennlinie();
            Console.Write(Data_input[6].Name);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(bk + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto2))
                FehlermeldungColor();

            skontoberechnung2 = bk * skonto2 / (100 - skonto2);
            skontoberechnung2 = decimal.Round(skontoberechnung2, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung2 + " €");
            Console.ResetColor();

            zkp = bk + skontoberechnung2;
            zkp = decimal.Round(zkp, 2);
            Trennlinie();
            Console.Write(Data_input[4].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zkp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt))
                FehlermeldungColor();

            berechnungrabatt = zkp * rabatt / (100 - rabatt);
            berechnungrabatt = decimal.Round(berechnungrabatt, 2);
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(berechnungrabatt + " €");
            Console.ResetColor();

            lep = zkp + berechnungrabatt;
            lep = decimal.Round(lep, 2);
            Trennlinie();
            Console.Write(Data_input[2].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(lep + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[1].Name);
            while (!decimal.TryParse(Console.ReadLine(), out anzahl))
                FehlermeldungColor();
            evk = lep / anzahl;
            evk = decimal.Round(evk, 2);
            Console.Write(Data_input[0].Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(evk + " €");
            Console.ResetColor();
            Trennlinie();
        }

        private static void Differenzberechnung(List<Daten> Data_input)
        {
            string titelname3 = "Differenzberechnung";

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\n------------------------------------------------------------------------------------");
            Console.WriteLine("\n" + titelname3);
            Trennlinie();
            Console.WriteLine("Vorwärts");

            Console.Write("\n" + Data_input[0].Name);

            // wenn der User anstatt einer Zahl Buchstaben eingibt, wird solange wiederholt bis eine Zahl eingegeben wird
            while (!decimal.TryParse(Console.ReadLine(), out ekp))
                FehlermeldungColor();

            Console.Write(Data_input[1].Name);
            while (!decimal.TryParse(Console.ReadLine(), out anzahl))
                FehlermeldungColor();

            lep = ekp * anzahl;
            lep = decimal.Round(lep, 2);
            Trennlinie();
            Console.Write(Data_input[2].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(lep + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt))
                FehlermeldungColor();

            berechnungrabatt = lep * rabatt / 100;
            berechnungrabatt = decimal.Round(berechnungrabatt, 2);
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(berechnungrabatt + " €");
            Console.ResetColor();
            zkp = lep - berechnungrabatt;
            zkp = decimal.Round(zkp, 2);
            Trennlinie();
            Console.Write(Data_input[4].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zkp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto))
                FehlermeldungColor();

            skontoberechnung = zkp * skonto / 100;
            skontoberechnung = decimal.Round(skontoberechnung, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung + " €");
            Console.ResetColor();
            bkp = zkp - skontoberechnung;
            bkp = decimal.Round(bkp, 2);
            Trennlinie();
            Console.Write(Data_input[6].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bkp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[7].Name);
            while (!decimal.TryParse(Console.ReadLine(), out bk))
                FehlermeldungColor();

            bp = bkp + bk;
            bp = decimal.Round(bp, 2);
            Trennlinie();
            Console.Write(Data_input[8].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(bp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[9].Name);
            while (!decimal.TryParse(Console.ReadLine(), out hk))
                FehlermeldungColor();

            skp = bp + hk;
            ekp = decimal.Round(skp, 2);
            Trennlinie();
            Console.Write(Data_input[10].Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(skp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.WriteLine("Rückwärts");
            Console.Write("\n" + Data_input[17].Name);
            while (!decimal.TryParse(Console.ReadLine(), out bvk))
                FehlermeldungColor();

            Console.Write(Data_input[16].Name);
            while (!decimal.TryParse(Console.ReadLine(), out ust))
                FehlermeldungColor();

            ustberechnung = bvk * ust / (100 + ust);
            ustberechnung = decimal.Round(ustberechnung, 2);
            Console.Write(Data_input[16].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ustberechnung + " €");
            Console.ResetColor();
            nvp = bvk - ustberechnung;
            nvp = decimal.Round(nvp, 2);
            Trennlinie();
            Console.Write(Data_input[15].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(nvp + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[3].Name);
            while (!decimal.TryParse(Console.ReadLine(), out rabatt2))
                FehlermeldungColor();

            rabattberechnung = nvp * rabatt2 / 100;
            rabattberechnung = decimal.Round(rabattberechnung, 2);
            Console.Write(Data_input[3].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(rabattberechnung + " €");
            Console.ResetColor();
            zvk = nvp - rabattberechnung;
            zvk = decimal.Round(zvk, 2);
            Trennlinie();
            Console.Write(Data_input[14].Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(zvk + " €");
            Console.ResetColor();
            Trennlinie();

            Console.Write(Data_input[5].Name);
            while (!decimal.TryParse(Console.ReadLine(), out skonto))
                FehlermeldungColor();

            Console.Write(Data_input[13].Name);
            while (!decimal.TryParse(Console.ReadLine(), out provi))
                FehlermeldungColor();

            skontoberechnung = zvk * skonto / 100;
            skontoberechnung = decimal.Round(skontoberechnung, 2);
            proviberechnung = zvk * provi / 100;
            proviberechnung = decimal.Round(proviberechnung, 2);
            Console.Write(Data_input[5].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(skontoberechnung + " €");
            Console.ResetColor();
            Console.Write(Data_input[13].Name);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(proviberechnung + " €");
            Console.ResetColor();

            bvp = zvk - proviberechnung - skontoberechnung;
            bvp = decimal.Round(bvp, 2);
            Trennlinie();
            Console.Write(Data_input[12].Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(bvp + " €");
            Console.ResetColor();
            Trennlinie();

            gewinnberechnung = bvp - skp;
            decimal gewinnProzent = gewinnberechnung * 100 / skp;
            gewinnProzent = decimal.Round(gewinnProzent, 2);
            Trennlinie();
            Console.Write(Data_input[11].Name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(gewinnberechnung + " €");
            Console.ResetColor();
            Console.Write("Gewinn in % ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(gewinnProzent + " %");
            Console.ResetColor();
            Trennlinie();
        }

        private static void Query_Menue()
        {
            Console.WriteLine("Handelskalkulationsrechner");
            Console.WriteLine("\nBitte wählen Sie aus dem Menü aus.");
            Console.WriteLine("\n1 - Vorwärtskalkulation");
            Console.WriteLine("2 - Rückwärtskalkulation");
            Console.WriteLine("3 - Differenzberechnung");
            Console.WriteLine("4 - Beenden");
        }

        private static void Query_Auswahl()
        {
            Console.WriteLine("1 - Ja");
            Console.WriteLine("2 - Nein");
        }

        private static void FehlermeldungColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte Zahl eingeben!!!");
            Console.ResetColor();
        }
        
        private static void FehlermeldungColor2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte wählen Sie eine gültige Nummer aus!!!");
            Console.ResetColor();
        }

        private static void Trennlinie()
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
        
        private static void Logo_Text_Color()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //Titel noch einfügen
        }
        
        private static void KonsolenEinstellung()
        {
            /*
             * Konsolengröße
             * Hintergrundfarbe
             * Position
             */
        }
        
        private void Ladebalken()
        {
            /**
             * timer 8 Sekunden
             * Thread.Sleep(8000);
             * Ladebalken etc
             */
        }
    }
 
    class Daten
    {
        public string Name { get; set; }
    }
}

/*  Console.WriteLine("Stückpreis");
    double stueckpreis = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Anzahl der Ware");
    double anzahl = Convert.ToInt32(Console.ReadLine());
    double listeneinkaufspreis = anzahl*stueckpreis;
    Console.WriteLine("Listeneinbkaufspreis: "+listeneinkaufspreis);

    Console.WriteLine("Rabatt");
    double num = Convert.ToInt32(Console.ReadLine());
    double rabatt = listeneinkaufspreis * num / 100;
    Console.WriteLine("Rabatt: "+rabatt);
    double zieleinkaufspreis = listeneinkaufspreis - rabatt;
    Console.WriteLine("Zieleinkaufspreis: "+zieleinkaufspreis);

    Console.WriteLine("Skonto");
    double num2 = Convert.ToInt32(Console.ReadLine());
    double skonto = zieleinkaufspreis * num2 / 100;
    Console.WriteLine("Skonto: "+skonto);
    double bareinkaufspreis = zieleinkaufspreis - skonto;
    Console.WriteLine("Bareinkaufspreis: "+bareinkaufspreis);

    Console.WriteLine("Beschaffungskosten");
    double beschaffungskosten = Convert.ToInt32(Console.ReadLine());
    double bezugspreis = bareinkaufspreis + beschaffungskosten;
    Console.WriteLine("Bezugspreis: "+bezugspreis);

    Console.WriteLine("Handlungskosten");
    double handlungskosten = Convert.ToInt32(Console.ReadLine());
    double selbstkostenpreis = bezugspreis + handlungskosten;
    Console.WriteLine("Selbskostenpreis: "+selbstkostenpreis);

    Console.WriteLine("Gewinn");
    double num3 = Convert.ToInt32(Console.ReadLine());
    double gewinn = selbstkostenpreis * num3 / 100;
    Console.WriteLine("Gewinn: "+gewinn);
    double barverkaufspreis = selbstkostenpreis + gewinn;
    Console.WriteLine("Barverkaufspreis: "+barverkaufspreis);

    Console.WriteLine("Skonto (i.H.)");
    double num4 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Provision (i.H)");
    double num5 = Convert.ToInt32(Console.ReadLine());
    double skonto1 = barverkaufspreis * num4 / (100 - (num4 + num5));
    Console.WriteLine("Skonto: " +skonto1);
    double provision = barverkaufspreis * num5 / (100 - (num4 + num5));
    Console.WriteLine("Provision: " +provision);
    double zielverkaufspreis = barverkaufspreis + skonto1 + provision;
    Console.WriteLine("Zielverkaufspreis: " + zielverkaufspreis);

    Console.WriteLine("Rabatt");
    double num6 = Convert.ToInt32(Console.ReadLine());
    double rabatt1 = zielverkaufspreis * num6 / (100 - num6);
    Console.WriteLine("Rabatt: " + rabatt1);
    double nettoverkaufspreis = zielverkaufspreis + rabatt1;
    Console.WriteLine("Nettoverkauspreis: " + nettoverkaufspreis);

    Console.WriteLine("Umsatzsteuer");
    double numust = Convert.ToDouble(Console.ReadLine());
    double ust = nettoverkaufspreis * numust / 100;
    double Bruttoverkaufspreis = nettoverkaufspreis + ust;
    Console.WriteLine("Bruttoverkaufspreis: " + nettoverkaufspreis);
    double stueckverkaufspreis = nettoverkaufspreis / anzahl;
    Console.WriteLine("Stückpreis: " + stueckverkaufspreis);
*/

