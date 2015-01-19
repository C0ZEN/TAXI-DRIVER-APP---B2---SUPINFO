using System;
using System.Linq;
using System.Globalization;

namespace B2_2NET_Mini_Projet1
{
    public static class AjouterUnVoyageSVP
    {
        public static void AjouterUnVoyage()
        {
            // *ReSharper : AjouterUnVoyage() 'Method body is too complex to analyse..'* -> Je sais, désolé
            // Cette méthode comme son nom l'indique permet d'ajouter un voyage
            // On commence par la saisie des données et leur vérifications
            // On demande de saisir l'id du driver pour associer le trip au driver : logique
            // Si le driver id est bon et qu'il n'y a pas de doublon, on ajoute le nouveau voyage

            // Initialisation des variables
            string departureTown = null;
            string departureAddress = null;
            DateTime departureTime = new DateTime(1994, 04, 16, 8, 12, 30); // Date par défaut (16 Avril 1994 à 8h12min)
            string arrivalTown = null;
            string arrivalAddress = null;
            DateTime arrivalTime = new DateTime(1994, 04, 16, 8, 12, 30);
            string clientFirstName = null;
            string clientLastName = null;
            bool donneesCorrectes = true;
            int compteur = 0;
            bool analyseur;
            bool bonneReponse;
            string reponse;
            int resultat;
            Int64 resultat64;
            AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);

            // Prompt et vérifications des données
            do
            {
                // Permet de confirmer la demande de création de voyage ou de revenir au menu
                // Prompt qui fait office de navigateur en quelque sorte

                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to add a new trip or ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to back : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                reponse = Console.ReadLine();

                if (reponse == "Y" || reponse == "y")
                {
                    bonneReponse = true;
                    Console.Clear();
                    AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
                }
                else if (reponse == "N" || reponse == "n")
                {
                    bonneReponse = true;
                    Console.Clear();
                    Program.AfficherMenuPrincipal(); // Redirection sur le menu
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid answer. Press Y or N.\n");
                }
            } while (bonneReponse == false);

            if (compteur == 0) // Departure Town
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Departure Town : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    departureTown = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(departureTown)) // Si c'est null -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Departure Town can not be null.\n");
                    }
                    else if (departureTown.Length > 50) // Si departureTown fait plus de 50   char -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Departure Town is 50 char maximum.\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(departureTown) == false) // Si departureTown ne contient pas que des lettres -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Departure Town must contain only letters.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite
                departureTown = UneMajusculeDevantSVP.UneMajusculeDevant(departureTown); // Toujours mieux avec la majuscule

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
            }

            if (compteur == 1) // Departure Address
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Departure Address : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    departureAddress = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (departureAddress.Length > 0) // Si au moins un char d'entré -> on continue
                    {
                        // Le but est de récupéré d'abord le numéro d'adresse
                        string departureAddressReplace = departureAddress.Replace(" ", "");
                        char premierChar = departureAddress[0]; // Stocke le premier char dans un char
                        string premierString = premierChar.ToString(); // Convertit le char en string
                        analyseur = int.TryParse(premierString, out resultat); // TryParse le string

                        if (departureAddress.Length > 50) // Une adresse ne peut faire plus de 50 char
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Departure Address is 50 char maximum.\n");
                        }
                        else if (analyseur == false) // L'adresse commence toujours par le numéro de rue
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Departure Address must begin by number address.\n");
                        }
                        else if (departureAddressReplace.Length < 2) // 3 pour le principe du numero = 1, espace = 0 après replace, char = 1 donc au moins 2 char
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Departure Address is like NUMBER STREET.\n");
                        }
                    }
                    else // Debug un System.NullReferenceException
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Departure Address can not be null.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
            }

            if (compteur == 2) // Departure Time
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Departure Time : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string departureTimeString = Console.ReadLine();
                    // Le but est d'obtenir une date du type YYYY-MM-dd-hh-mm (ex: 1994 04 16 08)
                    // L'heure est européenne, donc sur 24h mais on affichera l'heure anglaise par la suite
                    string departureTimeStringTrim = departureTimeString.Replace(" ", "");

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (departureTimeString.Length > 0) // Si au moins un char d'entré -> on continue
                    {
                        analyseur = Int64.TryParse(departureTimeStringTrim, out resultat64);
                        DateTime.TryParseExact(departureTimeString, "yyyy MM dd HH mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out departureTime);

                        if (analyseur == false) // Si autre que int -> ne peut contenir de lettres
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Departure Time must contain only numbers.\n");
                        }
                        else if (departureTimeStringTrim.Length != 12) // Si chaine pas égale à 12 -> caractère en trop
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Departure Time must be like YYYY MM DD HH MM.\n");
                        }
                        else if (departureTimeStringTrim.Length == 12)
                        {
                            string departureTimeString45 = String.Concat(departureTimeStringTrim[4],
                                departureTimeStringTrim[5]);
                            int departureTimeInt45;
                            bool bool45 = int.TryParse(departureTimeString45, out departureTimeInt45);
                            // Utile pour vérification du mois

                            string departureTimeString67 = String.Concat(departureTimeStringTrim[6],
                                departureTimeStringTrim[7]);
                            int departureTimeInt67;
                            bool bool67 = int.TryParse(departureTimeString67, out departureTimeInt67);
                            // Utile pour vérification du jour

                            string departureTimeString89 = String.Concat(departureTimeStringTrim[8],
                                departureTimeStringTrim[9]);
                            int departureTimeInt89;
                            bool bool89 = int.TryParse(departureTimeString89, out departureTimeInt89);
                            // Utile pour vérification de l'heure

                            string departureTimeString1011 = String.Concat(departureTimeString[10],
                                departureTimeString[11]);
                            int departureTimeInt1011;
                            bool bool1011 = int.TryParse(departureTimeString1011, out departureTimeInt1011);
                            // Utile pour vérification des minutes

                            if (departureTimeInt45 > 12) // Un mois ne peut être plus grand que 12
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Month can not be greater than 12.\n");
                            }
                            else if (departureTimeInt67 > 31) // Un jour ne peut être plus grand que le 31
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Day can not be greater than 31.\n");
                            }
                            else if (departureTimeInt89 > 59) // Une heure ne dépasse pas 59
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Hour can not be greater than 59.\n");
                            }
                            else if (departureTimeInt1011 > 59) // Une minute ne dépasse pas 59
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Minut can not be greater than 59.\n");
                            }
                        }
                    }
                    else // Debug un System.NullReferenceException
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Departure Date can not be null.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
            }

            if (compteur == 3) // Arrival Town
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Arrival Town : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    arrivalTown = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(arrivalTown)) // Si pas de données -> ne peut être null
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Arrival Town can not be null.\n");
                    }
                    else if (arrivalTown.Length > 50) // La ville ne peut faire plus de 50 char
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Arrival Town is 50 char maximum.\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(arrivalTown) == false) // Une ville ne contient que des lettres
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Arrival Town must contain only letters.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite
                arrivalTown = UneMajusculeDevantSVP.UneMajusculeDevant(arrivalTown); // Toujours mieux avec la majuscule

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
            }

            if (compteur == 4) // Arrival Address
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Arrival Address : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    arrivalAddress = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (arrivalAddress.Length > 0) // Si au moins un char d'entré -> on continue
                    {
                        string arrivalAddressReplace = arrivalAddress.Replace(" ", "");
                        char premierChar = arrivalAddress[0];
                        string premierString = premierChar.ToString();
                        analyseur = int.TryParse(premierString, out resultat);

                        if (arrivalAddress.Length > 50) // Une adresse ne peut faire plus de 50 char
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Arrival Address is 50 char maximum.\n");
                        }
                        else if (analyseur == false) // L'adresse commence toujours par le numéro de rue
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Arrival Address must begin by number address.\n");
                        }
                        else if (arrivalAddressReplace.Length < 2) // 3 pour le principe du numero = 1, espace = 0 avec replace, char = 1 donc au moins 3 char
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Arrival Address is like NUMBER STREET.\n");
                        }
                    }
                    else // Debug un System.NullReferenceException
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Arrival Address can not be null.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
            }

            if (compteur == 5) // Arrival Time
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Arrival Time : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string arrivalTimeString = Console.ReadLine();
                    string arrivalTimeStringTrim = arrivalTimeString.Replace(" ", "");
                    // Suppression des espaces
                    analyseur = Int64.TryParse(arrivalTimeStringTrim, out resultat64);
                    DateTime.TryParseExact(arrivalTimeString, "yyyy MM dd HH mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrivalTime);

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (arrivalTimeString.Length > 0) // Si au moins un char d'entré -> on continue
                    {
                        if (analyseur == false) // Si autre que int -> ne peut contenir de lettres
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Arrival Time must contain only numbers.\n");
                        }
                        else if (arrivalTimeStringTrim.Length != 12) // Si chaine pas égale à 12 -> caractère en trop
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Arrival Time must be like YYYY MM DD HH MM.\n");
                        }
                        else if (arrivalTimeStringTrim.Length == 12)
                        {
                            // Quelques vérifications supplémentaires sur les valeurs limites d'une date
                            string arrivalTimeString45 = String.Concat(arrivalTimeStringTrim[4],
                                arrivalTimeStringTrim[5]);
                            int arrivalTimeInt45;
                            var bool45 = int.TryParse(arrivalTimeString45, out arrivalTimeInt45);
                            // Utile pour vérification du mois

                            string arrivalTimeString67 = String.Concat(arrivalTimeString[6], arrivalTimeString[7]);
                            int arrivalTimeInt67;
                            var bool67 = int.TryParse(arrivalTimeString67, out arrivalTimeInt67);
                            // Utile pour vérification du jour

                            string arrivalTimeString89 = String.Concat(arrivalTimeString[8], arrivalTimeString[9]);
                            int arrivalTimeInt89;
                            var bool89 = int.TryParse(arrivalTimeString89, out arrivalTimeInt89);
                            // Utile pour vérification de l'heure

                            string arrivalTimeString1011 = String.Concat(arrivalTimeString[10], arrivalTimeString[11]);
                            int arrivalTimeInt1011;
                            var bool1011 = int.TryParse(arrivalTimeString1011, out arrivalTimeInt1011);
                            // Utile pour vérification des minutes

                            if (arrivalTimeInt45 > 12) // Un mois ne peut être plus grand que 12
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Month can not be greater than 12.\n");
                            }
                            else if (arrivalTimeInt67 > 31) // Un jour ne peut être plus grand que le 31
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Day can not be greater than 31.\n");
                            }
                            else if (arrivalTimeInt89 > 59) // Une heure ne dépasse pas 59
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Hour can not be greater than 59.\n");
                            }
                            else if (arrivalTimeInt1011 > 59) // Une minute ne dépasse pas 59
                            {
                                donneesCorrectes = false;
                                Console.WriteLine(" Minut can not be greater than 59.\n");
                            }
                        }
                    }
                    else // Debug un System.NullReferenceException
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Arrival Date can not be null.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);

                if (compteur == 6) // Client First Name
                {
                    do
                    {
                        donneesCorrectes = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" Enter the Client First Name : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        clientFirstName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Red;
                        if (string.IsNullOrEmpty(clientFirstName)) // Si c'est null -> erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client First Name can not be null.\n");
                        }
                        else if (clientFirstName.Length > 50) // Si clientFirstName fait plus de 50 char -> erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client First Name is 50 char maximum.\n");
                        }
                        else if (QueDesLettresSVP.QueDesLettres(clientFirstName) == false) // Si clientFirstName ne contient pas que des lettres - > erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client First Name must contain only letters.\n");
                        }
                    } while (donneesCorrectes == false);
                    compteur += 1; // Tout est bon, on passe à la suite
                    clientFirstName = UneMajusculeDevantSVP.UneMajusculeDevant(clientFirstName); // Toujours mieux avec la majuscule

                    Console.Clear();
                    AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
                }

                if (compteur == 7) // Client Last Name
                {
                    do
                    {
                        donneesCorrectes = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" Enter the Client Last Name : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        clientLastName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Red;
                        if (string.IsNullOrEmpty(clientLastName)) // Si c'est null -> erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client Last Name can not be null.\n");
                        }
                        else if (clientLastName.Length > 50) // Si clientLastName fait plus de 50  char -> erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client Last Name is 50 char maximum.\n");
                        }
                        else if (QueDesLettresSVP.QueDesLettres(clientLastName) == false) // Si clientLastName ne contient pas que des lettres -> erreur
                        {
                            donneesCorrectes = false;
                            Console.WriteLine(" Client Last Name must contain only letters.\n");
                        }
                    } while (donneesCorrectes == false);
                    clientLastName = UneMajusculeDevantSVP.UneMajusculeDevant(clientLastName); // Toujours mieux avec la majuscule

                    Console.Clear();
                    AjouterUnVoyageAffichageSVP.AjouterUnVoyageAffichage(departureTown, departureAddress, departureTime, arrivalTown, arrivalAddress, arrivalTime, clientFirstName, clientLastName);
                }

                // Toutes les données sont bonnes
                // Il faut maintenant choisir le drvierID

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

                // L'ID du driver est correct, on passe à la suite

                Console.WriteLine();
                string departureTimeDb = departureTime.ToString("dddd, dd MMM yyyy hh:mm tt", new CultureInfo("en-US", true));
                string arrivalTimeDb = arrivalTime.ToString("dddd, dd MMM yyyy hh:mm tt", new CultureInfo("en-US", true));

                do
                {
                    // Petit prompt qui permet de valider l'insert dans la base ou pas
                    bonneReponse = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Press ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Y");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" to confirm or ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("N");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" to reset : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    reponse = Console.ReadLine();

                    if (reponse == "Y" || reponse == "y") // On accepte les données
                    {
                        using (var objDejaPresent = new Database1Entities())
                        {
                            // Sur le même principe que pour le driver
                            // On vérifie au préalable qu'aucun voyage identique n'existe déjà dans la base
                            string departureConcat = departureTown + " " + departureAddress;
                            string arrivalConcat = arrivalTown + " " + arrivalAddress;

                            // Verifie que le trip existe déjà ou non
                            var query1 = from x
                                         in objDejaPresent.TripsSet
                                         where x.Departure.Equals(departureConcat)
                                         && x.Departure_Time.Equals(departureTimeDb)
                                         && x.Arrival.Equals(arrivalConcat)
                                         && x.Arrival_Time.Equals(arrivalTimeDb)
                                         && x.Client_First_Name.Equals(clientFirstName)
                                         && x.Client_Last_Name.Equals(clientLastName)
                                         select x;
                            var result1 = query1.Count();

                            if (result1 == 0) // Si 0 alors aucun voyage identique, on peut créer le voyage
                            {
                                using (var objInsert = new Database1Entities())
                                {
                                    // Insert un nouveau trip
                                    Trips objTrips = new Trips();
                                    objTrips.Departure = departureConcat;
                                    objTrips.Departure_Time = departureTimeDb;
                                    objTrips.Arrival = arrivalConcat;
                                    objTrips.Arrival_Time = arrivalTimeDb;
                                    objTrips.Client_First_Name = clientFirstName;
                                    objTrips.Client_Last_Name = clientLastName;
                                    objTrips.DriverId = driverId;
                                    objInsert.TripsSet.Add(objTrips);
                                    objInsert.SaveChanges();
                                }

                                using (var objSelectId = new Database1Entities())
                                {
                                    // Retourne le trip ID fraichement créer
                                    var query2 = from x
                                                 in objSelectId.TripsSet
                                                 where x.Departure.Equals(departureConcat)
                                                 && x.Departure_Time.Equals(departureTimeDb)
                                                 && x.Arrival.Equals(arrivalConcat)
                                                 && x.Arrival_Time.Equals(arrivalTimeDb)
                                                 && x.Client_First_Name.Equals(clientFirstName)
                                                 && x.Client_Last_Name.Equals(clientLastName)
                                                 && x.DriverId.Equals(driverId)
                                                 select x;
                                    var result2 = query2.First();

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(" New trip created successfully with id ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("{0}\n", result2.Id);
                                }
                            }
                            else // Un voyage identique existe déjà
                            {
                                using (var objSelectId = new Database1Entities())
                                {
                                    // Retourne le voyage ID déjà existant
                                    var query3 = from x
                                                 in objSelectId.TripsSet
                                                 where x.Departure.Equals(departureConcat)
                                                 && x.Departure_Time.Equals(departureTimeDb)
                                                 && x.Arrival.Equals(arrivalConcat)
                                                 && x.Arrival_Time.Equals(arrivalTimeDb)
                                                 && x.Client_First_Name.Equals(clientFirstName)
                                                 && x.Client_Last_Name.Equals(clientLastName)
                                                 && x.DriverId.Equals(driverId)
                                                 select x;
                                    var result3 = query3.First();

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(" A trip already exists with id ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("{0}", result3.Id);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(" for driver ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("{0}.\n", result3.DriverId);
                                }
                            }
                        }

                        bonneReponse = true;
                        bool bonneReponse2;

                        do
                        {
                            // Le petit prompt pour continuer
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" Press Y to continue : ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string reponse2 = Console.ReadLine();
                            bonneReponse2 = false;

                            if (reponse2 == "Y" || reponse2 == "y")
                            {
                                bonneReponse2 = true;
                                Console.Clear();
                                AjouterUnVoyage(); // On retourne sur le menu d'ajout de voyage
                            }
                            else // En cas d'erreur
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Invalid answer. Press Y.\n");
                            }
                        } while (bonneReponse2 == false);
                    }
                    else if (reponse == "N" || reponse == "n") // L'utilisateur ne veut pas ajouter ce voyage
                    {
                        bonneReponse = true;
                        Console.Clear();
                        AjouterUnVoyage(); // On efface les champs et retour sur le menu d'ajout de voyage
                    }
                    else // En cas d'erreur
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Invalid answer. Press Y or N.\n");
                    }
                } while (bonneReponse == false);
            }
        }
    }
}
