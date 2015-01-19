using System;
using System.Globalization;

namespace B2_2NET_Mini_Projet1
{
    public static class AjouterUnVoyageAffichageSVP
    {
        public static void AjouterUnVoyageAffichage(string departureTown, string departureAddress, DateTime departureTime, string arrivalTown,
                                                  string arrivalAddress, DateTime arrivalTime, string clientFirstName, string clientLastName)
        {
            // Cette méthode est basée sur le même principe que AjouterUnDriverAffichage()
            // On affiche uniquements les données une fois qu'elles sont saisies par l'utilisateur

            AffichageTitre.AfficherTitre();
            DateTime dateParDefaut = new DateTime(1994, 04, 16, 8, 12, 30);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Fill the blank to create a trip\n\n");

            // Departure town
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Departure Town :    ");

            if (departureTown != null) // Si pas null, on affiche le departureTown saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(departureTown);
            }
            Console.WriteLine("\n");

            // Departure address
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Departure Address : ");

            if (departureAddress != null) // Si pas null, on affiche le departureAddress saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(departureAddress);
            }
            Console.WriteLine("\n");

            // Departure Time
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Departure Time :    ");

            if (departureTime == dateParDefaut) // Si departureTime vaut la même chose que la date par défaut on affiche rien
            {
            }
            else // On affiche
            {
                // Monday, 12 Jan 2015 11:51 #Alamericaine
                // Transforme notre date en une string typé et surtout en anglais
                string departureTimeString = departureTime.ToString("dddd, dd MMM yyyy hh:mm tt", new CultureInfo("en-US", true));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(departureTimeString);
            }
            Console.WriteLine("\n");

            // Arrival Town
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Arrival Town :      ");

            if (arrivalTown != null) // Si pas null, on affiche le arrivalTown saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(arrivalTown);
            }
            Console.WriteLine("\n");

            // Arrival Address
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Arrival Address :   ");

            if (arrivalAddress != null) // Si pas null, on affiche le arrivalAddress saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(arrivalAddress);
            }
            Console.WriteLine("\n");

            // Arrival Time
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Arrival Time :      ");

            if (arrivalTime == dateParDefaut) // Pas d'affichage si heure par défaut
            {
            }
            else // Affichage
            {
                // Transforme l'heure FR en US en fonction d'une string typé
                string arrivalTimeString = arrivalTime.ToString("dddd, dd MMM yyyy hh:mm tt", new CultureInfo("en-US", true));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(arrivalTimeString);
            }
            Console.WriteLine("\n");

            // Client First Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Client First Name : ");

            if (clientFirstName != null) // Si pas null, on affiche clientFirstName saisi  au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(clientFirstName);
            }
            Console.WriteLine("\n");

            // Client Last Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Client Last Name :  ");

            if (clientLastName != null) // Si pas null, on affiche clientLastName saisi  au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(clientLastName);
            }
            Console.WriteLine("\n\n");
        }
    }
}
