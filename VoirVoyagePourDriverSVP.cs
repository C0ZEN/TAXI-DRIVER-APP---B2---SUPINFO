using System;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class VoirVoyagePourDriverSVP
    {
        public static void VoirVoyagePourDriver()
        {
            // Affiche tous les voyages porur un driver
            // On test le readline :
            // Si que des chiffres alors c'est tout bon
            // Si que des lettres, on affiche tous les driver par last name
            // et on récupère l'id du driver une fois que l'uti a saisi le bon driver
            // Puis on affiche simplement la liste des voyages

            bool bonneReponse;
            string maReponse;

            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Show all trips for a driver :\n\n");

            do
            {
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press Y to continue or N to go back : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                maReponse = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                {
                    Console.WriteLine(" Press Y or N.\n");
                }
                else if (QueDesLettresSVP.QueDesLettres(maReponse) == false) // Si ma réponse n'est pas une lettre -> erreur
                {
                    Console.WriteLine(" The answer can't be a number.\n");
                }
                else if (maReponse == "Y" || maReponse == "y" || maReponse == "N" || maReponse == "n") // Si ma réponse est la bonne, Ok on continue
                {
                    bonneReponse = true;
                }
                else
                {
                    Console.WriteLine(" The answer is not good.\n");
                }
            } while (bonneReponse == false);

            // Ma réponse est bonne, on continue

            if (maReponse == "N" || maReponse == "n") // On retourne au menu principal
            {
                Console.Clear();
                Program.AfficherMenuPrincipal();
            }
            else // La réponse est Y, on continue
            {
                int uneReponse = 0;
                string unBonLastName = null;
                int unBonDriverId = 0;
                Console.Clear();
                AffichageTitre.AfficherTitre();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Show all trips for a driver :\n\n");

                do
                {
                    int choixInt;
                    bonneReponse = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter driver's Last Name or ID : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    maReponse = Console.ReadLine();
                    bool analyseur = int.TryParse(maReponse, out choixInt);

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(maReponse)) // Si  c'est null -> erreur
                    {
                        Console.WriteLine(" Please enter something !\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(maReponse) == true) // Si c'est que des lettres, OK on continue
                    {
                        bonneReponse = true;
                        uneReponse = 2;
                        unBonLastName = maReponse;
                    }
                    else if (analyseur == true) // Si c'est que des chiffres, OK on continue
                    {
                        bonneReponse = true;
                        uneReponse = 1;
                        unBonDriverId = choixInt;
                    }
                    else // Les données ne sont pas bonnes -> erreur
                    {
                        Console.WriteLine(" The answer must contain only numbers or only letters.\n");
                    }
                } while (bonneReponse == false);

                // Un bon LastName ou un bon Driver ID à cette étape

                Console.Clear();
                AffichageTitre.AfficherTitre();

                if (uneReponse == 1) // L'utilisateur a entré un bon Driver ID
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Show all trips for Driver ID ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(unBonDriverId);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" :\n\n");

                    // Il faut vérifier que le Driver ID existe bien dans la base de données
                    using (var objVerifDriverId = new Database1Entities())
                    {
                        var query = from x
                                    in objVerifDriverId.DriverSet
                                    where x.Id.Equals(unBonDriverId)
                                    select x;
                        var reponseQuery = query.Count();

                        if (reponseQuery == 0) // Le Driver ID n'existe pas dans la base de données
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" The Driver ID ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(unBonDriverId);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" does not exists in the database.\n");

                            do
                            {
                                bonneReponse = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" Press Y to continue : ");
                                maReponse = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Red;
                                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                                {
                                    Console.WriteLine(" Press Y.\n");
                                }
                                else if (maReponse == "Y" || maReponse == "y") // Si la réponse pas bonne, Ok on continue
                                {
                                    bonneReponse = true;
                                }
                                else
                                {
                                    Console.WriteLine(" Bad answer. Press Y.\n");
                                }
                            } while (bonneReponse == false);

                            // L'utilisateur sait maintenant qu'il a un mauvais Driver ID

                            Console.Clear();
                            VoirVoyagePourDriver(); // Redirection
                        }

                        // Le Driver ID existe bien dans la base, on continue

                        Console.Clear();
                        AffichageVoyagePourDriverSVP.AffichageVoyagePourDriver(unBonDriverId);
                    }
                }
                else // L'utilisateur a entré un bon Last Name
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Show all trips for Driver Last Name ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(unBonLastName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" :\n\n");

                    // Il faut vérifier que le Last Name existe bien dans la base de données
                    using (var objVerifLastName = new Database1Entities())
                    {
                        int compteur = 0;
                        int[] driverIdArray = new int[1000];
                        var query = from x
                                    in objVerifLastName.DriverSet
                                    where x.Last_Name.Equals(unBonLastName)
                                    select x;
                        var reponseQuery = query.Count();

                        if (reponseQuery == 0) // Le Last Name n'existe pas dans la base de données
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" The Last Name ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(unBonLastName);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" does not exists in the database.\n");

                            do
                            {
                                bonneReponse = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" Press Y to continue : ");
                                maReponse = Console.ReadLine();

                                Console.ForegroundColor = ConsoleColor.Red;
                                if (string.IsNullOrEmpty(maReponse)) // Si c'est null -> erreur
                                {
                                    Console.WriteLine(" Press Y.\n");
                                }
                                else if (maReponse == "Y" || maReponse == "y") // Si la réponse pas bonne, Ok on continue
                                {
                                    bonneReponse = true;
                                }
                                else
                                {
                                    Console.WriteLine(" Bad answer. Press Y.\n");
                                }
                            } while (bonneReponse == false);

                            // L'utilisateur sait maintenant qu'il a un mauvais Last Name

                            Console.Clear();
                            VoirVoyagePourDriver(); // Redirection
                        }

                        // Le Last Name existe bien dans la base, on continue

                        driverIdArray[0] = 0;
                        foreach (var x in query)
                        {
                            compteur = compteur + 1; // Incrémentation compteur pour chaque personne
                            driverIdArray[compteur] = x.Id; // On ajoute le driver id dans un tableau à l'index du compteur donc index compteur = id
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" [ ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(compteur);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" ]   ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(x.Id);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" - ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(x.Last_Name + " " + x.First_Name);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(", ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(x.Age);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" years old, ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(x.City);
                            Console.WriteLine();
                        }

                        // Il faut maintenant choisir

                        Console.WriteLine();
                        int choixInt;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" Which one do you want to edit : ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string choixString = Console.ReadLine();
                            bool analyseur = int.TryParse(choixString, out choixInt);

                            Console.ForegroundColor = ConsoleColor.Red;
                            if (string.IsNullOrEmpty(choixString)) // Si c'est null -> erreur
                            {
                                Console.WriteLine(" Number can not be null.\n");
                            }
                            else if (analyseur == false) // Si ce n'est pas un nombre -> erreur
                            {
                                Console.WriteLine(" This is not a number.\n");
                            }
                            else if (choixInt >= 0)
                            {
                                Console.WriteLine(" This ID does not exist.\n");
                            }
                        } while (choixInt > compteur || choixInt <= 0);

                        // Le choix est bon, on peut envoyé le driverID correspondant

                        Console.Clear();
                        AffichageVoyagePourDriverSVP.AffichageVoyagePourDriver(choixInt);
                    }
                }
            }
        }
    }
}
