using System;

namespace B2_2NET_Mini_Projet1
{
    public static class AffichageTitre
    {
        public  static void AfficherTitre()
        {
            // My Taxi Driver (titre)
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                        MY ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("TAXI");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" DRIVER\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
}
