using System;

namespace B2_2NET_Mini_Projet1
{
    public static class YesOrNo
    {
        public static void AfficherYesOrNo(int driverId)
        {
            bool bonneReponse;
            do
            {
                // What is your choice ?
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to edit again or ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to back : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string reponse = Console.ReadLine();

                if (reponse == "Y" || reponse == "y")
                {
                    bonneReponse = true;
                    Console.Clear();
                    AfficherDonneesEditerDriverSVP.AfficherDonneesEditerDriver(driverId);
                }
                else if (reponse == "N" || reponse == "n")
                {
                    bonneReponse = true;
                    Console.Clear();
                    Program.AfficherMenuPrincipal();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid answer. Press Y or N.\n");
                }
            } while (bonneReponse == false);
        }
    }
}
