using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace B2_2NET_Mini_Projet1
{
    public static class ImporterUnVoyageSVP
    {
        public static void ImporterUnVoyage()
        {
            // Cette méthode permet d'importer un fichier .csv
            // De découper ce fichier
            // Puis de stocker les données dans la base de données

            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Import Trips from a .CSV file : \n\n");

            bool bonneReponse;
            string maReponse;
            do
            {
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to import a file or ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to go back : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                maReponse = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                {
                    Console.WriteLine(" Press Y or N.\n");
                }
                else if (maReponse == "Y" || maReponse == "y") // Si la réponse est bonne, on continue
                {
                    bonneReponse = true;
                }
                else if (maReponse == "N" || maReponse == "n")
                {
                    Console.Clear();
                    Program.AfficherMenuPrincipal(); // Redirection
                }
                else // Sinon c'est une mauvaise réponse -> erreur
                {
                    Console.WriteLine(" Bad answer.\n");
                }
            } while (bonneReponse == false);

            // La réponse est Yes, on continue

            Console.Clear();
            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Import Trips from a .CSV file : \n\n");
            string donnees;

            do
            {
                bonneReponse = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Write the full path to the file :\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" Path = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                maReponse = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                {
                    bonneReponse = false;
                    Console.WriteLine(" It can not be null.\n");
                }
                else if (File.Exists(maReponse) == false) // Si impossible de lire le fichier
                {
                    bonneReponse = false;
                    Console.WriteLine(" The path is wrong or not exists.\n");
                }
            } while (bonneReponse == false);

            // Le fichier est bon, on continue

            string fichier = Path.GetFileName(maReponse);
            Console.Clear();
            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Import Trips from ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(fichier);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" :\n\n");

            donnees = File.ReadAllText(maReponse); // Lecture du fichier en une longue string
            string donneesSub = donnees.Substring(0, donnees.Length - 1); // Supprime le dernier retour chariot
            string[] tripStrings = donneesSub.Split(',', '\n'); // Enregistre chaque mot dans un tableau avec pour délimiteur une virgule ou un retour chariot si plusieurs lignes
            int compteur = 0;
            int compteurTrip = 1;

            foreach (string tripString in tripStrings)
            {
                compteur = compteur + 1; // On incrémente le compteur a chaque itération.
                // Puis en fonction du compteur, on affiche ce qu'on souhaite
                
                switch (compteur)
                {
                    // Première ligne
                    case 1: // Première itération = Adresse
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("        | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Dep.Address : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(UneMajusculeDevantSVP.UneMajusculeDevant(tripString));
                        break;
                    // Deuxième ligne
                    case 2: // Deuxième itération = Date
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("  Trip  | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Dep.Date : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(tripString);
                        break;
                    // Troisième ligne
                    case 3: // Troisième itération = Adresse
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" Number | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Arr.Address : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(UneMajusculeDevantSVP.UneMajusculeDevant(tripString));
                        break;
                    // Quatrième ligne
                    case 4: // Quatrième itération = Date
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (compteurTrip < 10)
                        {
                            Console.Write("   {0}    | ", compteurTrip);
                        }
                        else if (compteurTrip >= 10 && compteurTrip < 100)
                        {
                            Console.Write("   {0}   | ", compteurTrip);
                        }
                        else if (compteurTrip >= 100 && compteurTrip < 1000)
                        {
                            Console.Write("  {0}   | ", compteurTrip);
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Arr.Date : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(tripString);
                        break;
                    // Cinquième ligne
                    case 5: // Cinquième itération = Nom
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("        | ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Client : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(UneMajusculeDevantSVP.UneMajusculeDevant(tripString));
                        break;
                    case 6: // Sixième itération = Prénom
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" {0}\n", UneMajusculeDevantSVP.UneMajusculeDevant(tripString));
                        compteurTrip = compteurTrip + 1; //   Incrémentation de l'id du compteur de voyage
                        compteur = 0; // On recommence
                        break;
                }
            }
            Console.WriteLine();

            // Les voyages sont maintenant afficher
            // Il faut vérifier qu'un doublon n'existe pas déjà dans la base
            // Et demander ensuite à quel driver sera attribué chaque voyage

            int monNombreDeTrip = 1;
            int compteurTripLimit = compteurTrip;
            compteur = 0; // On remet le compteur a 0 pour la recherche de l'index 0
            compteurTrip = 1;

            do
            {
                using (var objDejaPresent = new Database1Entities()) // On vérifie que le trip n'existe pas déjà
                {
                    // On entre toutes les données dans des string
                    // Les requêtes ne comprennent par tripStrings[compteur];
                    string departure = tripStrings[compteur];
                    string departureTime = tripStrings[compteur + 1];
                    string arrival = tripStrings[compteur + 2];
                    string arrivalTime = tripStrings[compteur + 3];
                    string lastName = tripStrings[compteur + 4];
                    string firstName = tripStrings[compteur + 5];

                    do
                    {
                        bonneReponse = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" Enter a Driver ID for Trip ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(compteurTrip);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string driverIdString = Console.ReadLine();
                        int driverId;
                        bool analyseur = int.TryParse(driverIdString, out driverId);

                        Console.ForegroundColor = ConsoleColor.Red;
                        if (string.IsNullOrEmpty(driverIdString)) // Si  c'est null -> erreur
                        {
                            bonneReponse = false;
                            Console.WriteLine(" Enter a Driver ID !\n");
                        }
                        else if (analyseur == false) // Si ce n'est pas un nombre -> erreur
                        {
                            bonneReponse = false;
                            Console.WriteLine(" You must enter a number.\n");
                        }
                        else if (analyseur == true) // Si le nombre est bon, on vérifie qu'il existe dans la base
                        {
                            var query1 = from y
                                        in objDejaPresent.DriverSet
                                        where y.Id.Equals(driverId)
                                        select y;
                            var reponseQuery1 = query1.Count();

                            if (reponseQuery1 == 0) // Le driver ID n'existe pas
                            {
                                bonneReponse = false;
                                Console.WriteLine(" The driver ID does not exists in the Database.\n");
                            }
                            else // Le Driver ID existe
                            {
                                // Insert un nouveau trip
                                Trips objTrips = new Trips();
                                objTrips.Departure = departure;
                                objTrips.Departure_Time = departureTime;
                                objTrips.Arrival = arrival;
                                objTrips.Arrival_Time = arrivalTime;
                                objTrips.Client_Last_Name = lastName;
                                objTrips.Client_First_Name = firstName;
                                objTrips.DriverId = driverId;
                                objDejaPresent.TripsSet.Add(objTrips);
                                objDejaPresent.SaveChanges();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" The trip ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(compteurTrip);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" was successfully added in the Database.\n");
                            }
                        }
                    } while (bonneReponse == false);
                    compteur = 6; // Augmentation du compteur pour refaire un cycle
                    compteurTrip = compteurTrip + 1; // On incrémente pour sélectionner le voyage suivant
                    monNombreDeTrip = monNombreDeTrip + 1; // On incrémente dès que le voyge est ajouter
                }
            } while (monNombreDeTrip != compteurTripLimit);

            // Tous les voyages ont étaient ajoutés

            do
            {
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to continue : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                maReponse = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                {
                    Console.WriteLine(" Press Y.\n");
                }
                else if (maReponse == "Y" || maReponse == "y") // Si c'est  bon, on continue
                {
                    Console.Clear();
                    ImporterUnVoyage(); // Redirection
                }
                else // C'est pas bon -> erreur
                {
                    Console.WriteLine(" Bad answer. Press Y.\n");
                }
            } while (bonneReponse == false);
        }
    }
}
