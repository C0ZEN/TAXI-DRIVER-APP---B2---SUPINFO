using System;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class EditerUnDriverSVP
    {
        public static void EditerUnDriver()
        {
            // Méthode qui permet l'édition d'un driver
            // On a deux façons de faire : par ID ou par nom
            // La seule différence est que le nom retourne une liste
            // Il faudra faire le choix parmi les prétendants
            // Bien sur, il faudra vérifier que les données saisies correspondent bien à quelqu'un
            // Ensuite il suffit de saisir un choix (quelle ligne à editer)
            // On vérifie la donnée saisie, une fois celle-ci correcte
            // L'update fait son job et on retourne sur le menu pour éditer

            bool bonneReponse;
            bool analyseur;
            int choixInt;
            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Edit an existing driver\n\n");

            do
            {
                // Petit prompt pour faire le retour menu ou continuer
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to edit a driver or ");
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

            // Si Yes alors on continu

            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Edit an existing driver\n\n");

            // Edit a driver by ID
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 1 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Edit a driver by ID\n");

            // Edit a driver by Name
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 2 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Edit a driver by Name\n\n");

            do
            {
                // What is your choice ?
                bonneReponse = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" What is your choice ? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string choixString = Console.ReadLine();
                analyseur = int.TryParse(choixString, out choixInt);

                Console.ForegroundColor = ConsoleColor.Red;
                if (analyseur == false) // Si ce n'est pas un nombre -> erreur
                {
                    bonneReponse = false;
                    Console.WriteLine(" This is not a number.\n");
                }
                else if (choixInt <= 0 || choixInt >= 3) // Si le nombre n'est pas bon -> erreur
                {
                    bonneReponse = false;
                    Console.WriteLine(" Wrong number.\n");
                }
            } while (bonneReponse == false);
            Console.WriteLine();

            if (choixInt == 1) // Choix de l'édition par driverId
            {
                int driverId;
                do
                {
                    bonneReponse = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Choose a driver ID : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string driverIdString = Console.ReadLine();
                    analyseur = int.TryParse(driverIdString, out driverId);

                    if (analyseur == true) // Si la saisie ne contient pas que des chiffres -> on continue
                    {
                        // Le driverID saisi est correct

                        using (var objDriverId = new Database1Entities())
                        {
                            // Verifie que le driver existe déjà
                            var query = from x
                                        in objDriverId.DriverSet
                                        where x.Id.Equals(driverId)
                                        select x;
                            var result = query.Count();

                            if (result == 0) // Si la requête retourne 0, l'ID n'existe pas dans la base de données
                            {
                                // On affiche un message d'erreur
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" The driver ID ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(driverId);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" does not exist.\n");
                                bonneReponse = false;
                            }
                        }
                    }
                    else // Debug un double prompt
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" This is not a number.\n");
                        bonneReponse = false;
                    }
                } while (bonneReponse == false);

                // L'ID existe dans la table DriverID
                AfficherDonneesEditerDriverSVP.AfficherDonneesEditerDriver(driverId);
            }
            else if (choixInt == 2) // Choix de l'édition par driverName
            {
                string driverLastNameString;
                do
                {
                    // On vérifie que la saisie est bonne
                    bonneReponse = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Choose a driver Last Name : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    driverLastNameString = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(driverLastNameString)) // Si c'est null -> erreur
                    {
                        bonneReponse = false;
                        Console.WriteLine(" The driver Last Name can't be null.\n");
                    }
                    else if (driverLastNameString.Length > 50) // Si plus de 50 char -> erreur
                    {
                        bonneReponse = false;
                        Console.WriteLine(" The driver Last Name is maximum 50 char.\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(driverLastNameString) == false)
                    {
                        bonneReponse = false;
                        Console.WriteLine(" The driver Last Name must contain only letters.\n");
                    }
                } while (bonneReponse == false);

                // La saisie est bonne, on affiche maintenant les résultats

                Console.Clear();
                AffichageTitre.AfficherTitre();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" All results for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(driverLastNameString);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" :\n\n");
                int compteur = 0;
                int[] driverIdArray = new int[1000];

                using (var objNames = new Database1Entities())
                {
                    var query = from x
                                in objNames.DriverSet
                                where x.Last_Name.Equals(driverLastNameString)
                                select x;
                    var queryCount = query.Count();

                    if (queryCount == 0) // Personne n'existe, on redirige
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Nobody exist with {0} Last Name.\n", driverLastNameString);

                        do
                        {
                            bonneReponse = false;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" Press Y to continue : ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string reponse = Console.ReadLine();

                            Console.ForegroundColor = ConsoleColor.Red;
                            if (string.IsNullOrEmpty(reponse)) // Si c'est null -> erreur
                            {
                                Console.WriteLine(" Answer can't be null. Press Y.\n");
                            }
                            else if (reponse == "Y" || reponse == "y") // Si c'est y -> OK, on continue
                            {
                                bonneReponse = true;
                                Console.WriteLine(" Bad answer. Press Y.\n");
                            }
                        } while (bonneReponse == false);
                        Console.Clear();
                        EditerUnDriver(); // Redirection
                    }
                    else // quelqu'un porte bien ce nom, on continue
                    {
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
                    }
                }
                Console.WriteLine();

                // Il faut maintenant choisir

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Which one do you want to edit : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string choixString = Console.ReadLine();
                    analyseur = int.TryParse(choixString, out choixInt);

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

                AfficherDonneesEditerDriverSVP.AfficherDonneesEditerDriver(driverIdArray[choixInt]);
            }
        }
    }
}
