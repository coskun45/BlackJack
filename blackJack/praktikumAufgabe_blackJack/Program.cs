using System;
using System.ComponentModel;

namespace praktikumAufgabe_blackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            string spieler;
            int anzSpielerChips = 10;
            int spielerKarteSumme = 0;
            int computerKarteSumme = 0;
            bool nochmal = true;
            while (anzSpielerChips > 0 && nochmal)
            {
                Console.WriteLine("Dein Guthaben: " + anzSpielerChips+" Chips");
                int spielerEinsatz;
                // Einsatz
                Console.Write("Dein Einsatz: ");
                spielerEinsatz = Convert.ToInt32(Console.ReadLine());
                if (spielerEinsatz < 1 || spielerEinsatz > 10)
                {
                    Console.WriteLine("Du musst nindestens 1 und kannst max. 10 Chips setzen.");
                }
                else
                {
                    //random für erste  karte bekommen
                    Random zufallkarte = new Random();
                    int karte;
                    karte = zufallkarte.Next(2, 12);
                    Console.Write("Karte: " + karte + "           ");
                    spielerKarteSumme += karte;
                    Console.WriteLine("Gesamt: " + spielerKarteSumme);
                    //zweite Karte
                    karte = zufallkarte.Next(2, 12);
                    Console.Write("Karte: " + karte + "           ");
                    spielerKarteSumme += karte;
                    Console.WriteLine("Gesamt: " + spielerKarteSumme);
                    //weitere eine karte bekommen, wenn Spieler möchte
                    bool weiter = true;
                    while (spielerKarteSumme < 21 && weiter)
                    {
                        Console.WriteLine("noch eine karte (j | n)");
                        string answer = Console.ReadLine();
                        if (answer == "j")
                        {
                            karte = zufallkarte.Next(2, 12);
                            Console.Write("Karte: " + karte + "           ");
                            spielerKarteSumme += karte;
                            Console.WriteLine("Gesamt: " + spielerKarteSumme);
                            weiter = true;
                        }
                        else
                        {
                            weiter = false;
                        }
                    }
                    //falls Spilerkartesumme <21 ist, dann spielt der Computer
                    if (spielerKarteSumme < 21)
                    {
                        while (computerKarteSumme < 16)
                        {
                            karte = zufallkarte.Next(2, 12);
                            Console.Write("Karte: " + karte + "           ");
                            computerKarteSumme += karte;
                            Console.WriteLine("Gesamt Computer: " + computerKarteSumme);
                        }
                        Console.WriteLine(); Console.WriteLine();
                    }
                    Console.WriteLine(); Console.WriteLine();
                    //Entscheidung, wer gewonnen hat
                    if (spielerKarteSumme > 21)
                    {
                        Console.WriteLine("ich habe gewonnen");
                        anzSpielerChips -= spielerEinsatz;
                        Console.WriteLine("Dein Guthaben: " + anzSpielerChips);
                    }
                    else if (computerKarteSumme > 21)
                    {
                        Console.WriteLine("Du hast gewonnen");
                        anzSpielerChips += spielerEinsatz;
                        Console.WriteLine("Dein Guthaben: " + anzSpielerChips+ "chips.");
                    }
                    else if (spielerKarteSumme <= 21 && computerKarteSumme <= 21)
                    {
                        if (computerKarteSumme >= spielerKarteSumme)
                        {
                            Console.WriteLine("Ich habe gewonnen");
                            anzSpielerChips -= spielerEinsatz;
                            Console.WriteLine("Dein Guthaben: " + anzSpielerChips);
                        }
                        else
                        {
                            Console.WriteLine("Du hast gewonnen");
                            anzSpielerChips += spielerEinsatz;
                            Console.WriteLine("Dein Guthaben: " + anzSpielerChips);
                        }
                    }
                }
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                //Abfrage,ob Spieler weiter macht oder nicht
                Console.WriteLine("Nochmal (j/n)");
                string answer2 = Console.ReadLine();
                if (answer2 == "j")
                {
                    nochmal = true;
                    spielerKarteSumme = 0;
                    computerKarteSumme = 0;
                }
                else
                    nochmal = false;
            }
        }
    }
}
