using System;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class AjouterUnDriverSVP
    {
        public static void AjouterUnDriver()
        {
            // Cette méthode permet de saisir les données pour créer un driver
            // Des vérifications sont effectuées pour renvoyer un message précis en cas d'erreur
            // Tout fonctionne sur la base du do..while pour spam la requête facilement
            // Permet également de vérifier que les données sont compatibles avec la base de données

            // Initialisation des variables
            string lastName = null;
            string firstName = null;
            string carModel = null;
            int age = 0;
            int salary = 0;
            int campus = 0;
            string city = null;
            bool donneesCorrectes = true;
            int compteur = 0;
            bool analyseur;
            bool bonneReponse;
            string reponse;
            int resultat;
            AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);

            // Prompt et vérifications des données
            do
            {
                // Permet de confirmer la demande de création de driver ou de revenir au menu
                // Prompt qui fait office de navigateur en quelque sorte

                bonneReponse = false; // Par défaut, c'est toujours faux
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to add a new driver or ");
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
                    AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
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

            // Un compteur permet de déterminer quel est la prochaine donnée à saisir
            // Si la donnée est bonne, on incrémente le compteur pour passer à la saisie suivante

            if (compteur == 0) // Last Name
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Last Name : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    lastName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(lastName)) // Si la donnée est null -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Last Name can not be null.\n");
                    }
                    else if (lastName.Length > 50) // Si le lastName fait plus de 50 char -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Last Name is 50 char maximum.\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(lastName) == false) // Si le lastName ne contient pas que des lettres -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Last Name must contain only letters.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite
                lastName = UneMajusculeDevantSVP.UneMajusculeDevant(lastName); // Toujours mieux avec la majuscule

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }

            if (compteur == 1) // First Name
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the First Name : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    firstName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(firstName)) // Si la donnée est null -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" First Name can not be null.\n");
                    }
                    else if (firstName.Length > 50) // Si le firstName fait plus de 50 char -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" First Name is 50 char maximum.\n");
                    }
                    else if (QueDesLettresSVP.QueDesLettres(firstName) == false) // Si le firstName ne contient pas que des lettres -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" First Name must contain only letters.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite
                firstName = UneMajusculeDevantSVP.UneMajusculeDevant(firstName); // Toujours mieux avec la  majuscule

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }

            if (compteur == 2) // Car Model
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the Car Model : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    carModel = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (string.IsNullOrEmpty(carModel)) // Si la donnée est null -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Car Model can not be null.\n");
                    }
                    else if (carModel.Length > 50) // Si le carModel fait plus de 50 char -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Car Model is 50 char maximum.\n");
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite
                carModel = UneMajusculeDevantSVP.UneMajusculeDevant(carModel); // Toujours mieux avec la majuscule

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }

            if (compteur == 3) // age
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the age : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string ageString = Console.ReadLine();
                    analyseur = int.TryParse(ageString, out resultat);
                    age = resultat;

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (analyseur == false) // Si l'age ne contient pas que des chiffres -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" This is not a number.\n");
                    }
                    else if (resultat < 21) // Si l'age vaut moins que 21 -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" A taxi driver is at least 21 years old.\n");
                    }
                    else if (resultat > 99) // Si l'age vaut plus que 99 (avec très grande tolérance) -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" Nobody can drive at {0} years.\n", resultat);
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }

            if (compteur == 4) // salary
            {
                do
                {
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the salary : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string salaryString = Console.ReadLine();
                    analyseur = int.TryParse(salaryString, out resultat);
                    salary = resultat;

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (analyseur == false) // Si le salary ne contient pas que des chiffres -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" This is not a number.\n");
                    }
                    else if (resultat < 500) // Si le salary vaut moins que 500 -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" A taxi driver earn more than {0}.\n", resultat);
                    }
                    else if (resultat > 20000) // Si le salary vaut plus que 20000 -> erreur
                    {
                        donneesCorrectes = false;
                        Console.WriteLine(" A taxi driver can't earn more than 20000 per month.\n", resultat);
                    }
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }

            /*
            if (compteur == 5) // campus
            {
                do
                {
                    // A COMPLETER SI JE SAIS QUOI METTRE
                    donneesCorrectes = true;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the campus : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } while (donneesCorrectes == false);
                compteur += 1; // Tout est bon, on passe à la suite

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);
            }
             */

            compteur += 1;

            if (compteur == 6) // city
            {
                do
                {
                    donneesCorrectes = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Enter the city : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    city = Console.ReadLine();
                    city = city.ToLower(); // Reduction en lower pour éviter les mauvaise données

                    Console.ForegroundColor = ConsoleColor.Red;
                    if (city.Equals("paris") || city.Equals("lyon") || city.Equals("marseille")) // Si city est identique à l'une des trois -> OK c'est bon
                    {
                        donneesCorrectes = true;
                    }
                    else if (string.IsNullOrEmpty(city)) // Si la donnée est null -> erreur
                    {
                        Console.WriteLine(" city can not be null.\n");
                    }
                    else // city n'est pas l'un des trois de cette liste -> erreur
                    {
                        Console.WriteLine(" The city must be Paris, Marseille or Lyon.\n");
                    }
                } while (donneesCorrectes == false);
                city = UneMajusculeDevantSVP.UneMajusculeDevant(city); // Toujours mieux avec la majuscule

                Console.Clear();
                AjouterUnDriverAffichageSVP.AjouterUnDriverAffichage(lastName, firstName, carModel, age, salary, campus, city);

                // A cette étape, toutes les données ont étaient saisies et sont correctes
                // L'utilisateur peut donc voir les données saisies et au choix,
                // Valider les données ou annuler la création du nouveau driver

                do
                {
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

                    if (reponse == "Y" || reponse == "y")
                    {
                        // On valide la création du driver
                        // Il faut déjà vérifier qu'un homonyme parfait n'existe pas dans la base
                        // Si il n'y a pas d"homonyme alors on créer le driver sinon on annule

                        using (var objDejaPresent = new Database1Entities())
                        {
                            // Verifie que la personne existe déjà ou non
                            var query1 = from x
                                         in objDejaPresent.DriverSet
                                         where x.Last_Name.Equals(lastName)
                                         && x.First_Name.Equals(firstName)
                                         && x.Car_Model.Equals(carModel)
                                         && x.Age.Equals(age)
                                         && x.Salary.Equals(salary)
                                         && x.City.Equals(city)
                                         select x;
                            var result1 = query1.Count();

                            if (result1 == 0) // Si 0, alors aucun résultat donc pas d'homonyme parfait
                            {
                                using (var objInsert = new Database1Entities())
                                {
                                    // Insert un nouveau driver
                                    Driver objDriver = new Driver();
                                    objDriver.Last_Name = lastName;
                                    objDriver.First_Name = firstName;
                                    objDriver.Car_Model = carModel;
                                    objDriver.Age = age;
                                    objDriver.Salary = salary;
                                    objDriver.Campus = 170862;
                                    objDriver.City = city;
                                    objInsert.DriverSet.Add(objDriver);
                                    objInsert.SaveChanges();
                                }

                                using (var objSelectId = new Database1Entities())
                                {
                                    // Retourne le driver ID fraichement créer
                                    var query2 = from x
                                        in objSelectId.DriverSet
                                                 where x.Last_Name.Equals(lastName)
                                                       && x.First_Name.Equals(firstName)
                                                       && x.Car_Model.Equals(carModel)
                                                       && x.Age.Equals(age)
                                                       && x.Salary.Equals(salary)
                                                       && x.City.Equals(city)
                                                 select x;
                                    var result2 = query2.First();

                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(" New driver created successfully with id ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine(result2.Id);
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                // Un homonyme existe déjà
                                // On retourne l'id de ce driver

                                using (var objSelectId = new Database1Entities())
                                {
                                    // Retourne le driver ID déjà existant
                                    var query3 = from x
                                        in objSelectId.DriverSet
                                                 where x.Last_Name.Equals(lastName)
                                                       && x.First_Name.Equals(firstName)
                                                       && x.Car_Model.Equals(carModel)
                                                       && x.Age.Equals(age)
                                                       && x.Salary.Equals(salary)
                                                       && x.City.Equals(city)
                                                 select x;
                                    var result3 = query3.First();

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(" A homonym already exists with id ");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("{0}.\n", result3.Id);
                                }
                            }
                        }

                        bonneReponse = true;
                        bool bonneReponse2;

                        do
                        {
                            // Un petit prompt dire de confirmer la prise de connaissance
                            // sur la réussite de création du driver

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" Press Y to continue : ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string reponse2 = Console.ReadLine();
                            bonneReponse2 = false;

                            if (reponse2 == "Y" || reponse2 == "y")
                            {
                                bonneReponse2 = true;
                                Console.Clear();
                                AjouterUnDriver();
                            }
                            else // En cas d'erreur
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Invalid answer. Press Y.\n");
                            }
                        } while (bonneReponse2 == false);
                    }
                    else if (reponse == "N" || reponse == "n")
                    {
                        // Si l'utilisateur ne confirme pas la création du driver
                        // On redirige sur la création d'un driver avec des champs vides

                        bonneReponse = true;
                        Console.Clear();
                        AjouterUnDriver(); // On efface les champs
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
