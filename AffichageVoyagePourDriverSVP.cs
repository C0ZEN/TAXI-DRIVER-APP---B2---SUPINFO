using System;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class AffichageVoyagePourDriverSVP
    {
        public static void AffichageVoyagePourDriver(int driverId)
        {
            // Affiche les trips pour un driver

            using (var objObtenirInfo = new Database1Entities())
            {
                var query = from x
                            in objObtenirInfo.DriverSet
                            where x.Id.Equals(driverId)
                            select x;
                var reponseQuery = query.First();
                string lastName = reponseQuery.Last_Name;
                string firstName = reponseQuery.First_Name;
                AffichageTitre.AfficherTitre();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" View all trips for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0} {1}", UneMajusculeDevantSVP.UneMajusculeDevant(lastName), UneMajusculeDevantSVP.UneMajusculeDevant(firstName));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" :\n\n");

                // On affiche maintenant tous les résultats
                var query2 = from y
                            in objObtenirInfo.TripsSet
                            where y.DriverId.Equals(driverId)
                            select y;
                var resultatQuery2 = query2.Count();

                if (resultatQuery2 == 0) // Si la requête ne retourne rien
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" There is any trip for this driver.\n");
                }
                else
                {
                    foreach (var y in query2)
                    {
                        // Première ligne
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("        | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Dep.Address : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(UneMajusculeDevantSVP.UneMajusculeDevant(y.Departure));
                        // Deuxième ligne
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("  Trip  | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Dep.Date : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(y.Departure_Time);
                        // Troisième ligne
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" Number | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Arr.Address : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(UneMajusculeDevantSVP.UneMajusculeDevant(y.Arrival));
                        // Quatrième ligne
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (y.Id < 10)
                        {
                            Console.Write("   {0}    | ", y.Id);
                        }
                        else if (y.Id >= 10 && y.Id < 100)
                        {
                            Console.Write("   {0}   | ", y.Id);
                        }
                        else if (y.Id >= 100 && y.Id < 1000)
                        {
                            Console.Write("  {0}   | ", y.Id);
                        }
                        else if (y.Id >= 1000 && y.Id < 10000)
                        {
                            Console.Write("  {0}  | ", y.Id);
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Arr.Date : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(y.Arrival_Time);
                        // Cinquième ligne
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("        | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Client : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0} {1}\n", UneMajusculeDevantSVP.UneMajusculeDevant(y.Client_Last_Name), UneMajusculeDevantSVP.UneMajusculeDevant(y.Client_First_Name));
                    }
                }
                Console.WriteLine();

                // Tout a était afficher

                bool bonneReponse;
                do
                {
                    bonneReponse = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Press Y to confirm : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string maReponse = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                    {
                        Console.WriteLine(" Press Y.\n");
                    }
                    else if (maReponse == "Y" || maReponse == "y") // Si la répon est bonne, on redirige
                    {
                        bonneReponse = true;
                        Console.Clear();
                        VoirVoyagePourDriverSVP.VoirVoyagePourDriver(); // Redirection
                    }
                    else // Si c'est pas bon -> erreur
                    {
                        Console.WriteLine(" Bad answer. Press Y.\n");
                    }
                } while (bonneReponse == false);
            }
        }
    }
}
