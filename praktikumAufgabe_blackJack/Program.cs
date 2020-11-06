using System;
using System.ComponentModel;

namespace praktikumAufgabe_blackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            string spieler;
            int anzspielerchips = 10;
            int spielerKarteSumme = 0;
            int computerKarteSumme = 0;


            Console.WriteLine("Dein Guthaben: " + anzspielerchips);

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

                //noch eine karte

                karte = zufallkarte.Next(2, 12);
                Console.Write("Karte: " + karte + "           ");
                spielerKarteSumme += karte;
                Console.WriteLine("Gesamt: " + spielerKarteSumme);



                //weitere für eine karte bekommen
                bool weiter = true;
                while (spielerKarteSumme < 21 && weiter)
                {
                    Console.WriteLine("noch eine karte (j | n)");
                    string
                        answer = Console.ReadLine();
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
                if (spielerKarteSumme < 21)
                {

                    while (computerKarteSumme < 16)
                    {

                      
                        karte = zufallkarte.Next(2, 12);
                        Console.Write("Karte: " + karte + "           ");
                        computerKarteSumme += karte;
                        Console.WriteLine("Gesamt Computer: " + computerKarteSumme);

                    }



                }
                //wer gewonnen
                if (spielerKarteSumme > 21)
                {
                    Console.WriteLine("ich habe gewonnen");
                    anzspielerchips -= spielerEinsatz;
                    Console.WriteLine("Dein Guthaben: " + anzspielerchips);

                }

                else if (computerKarteSumme > 21)
                {
                    Console.WriteLine("Du hast gewonnen");
                    anzspielerchips += spielerEinsatz;
                    Console.WriteLine("Dein Guthaben: " + anzspielerchips);
                }
                else if (spielerKarteSumme <= 21 && computerKarteSumme <= 21)
                {
                    if (computerKarteSumme >= spielerKarteSumme)
                    {
                        Console.WriteLine("Ich habe gewonnen");
                        anzspielerchips -= spielerEinsatz;
                        Console.WriteLine("Dein Guthaben: " + anzspielerchips);
                    }
                    else
                    {
                        Console.WriteLine("Du hast gewonnen");
                        anzspielerchips += spielerEinsatz;
                        Console.WriteLine("Dein Guthaben: " + anzspielerchips);
                    }
                }


            }

        }
    }
}
