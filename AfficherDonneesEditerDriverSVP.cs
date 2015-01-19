using System;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class AfficherDonneesEditerDriverSVP
    {
        public static void AfficherDonneesEditerDriver(int driverId)
        {
            // On les enregistres dans des variables
            string reponse;
            bool bonneReponse;
            int choixInt;
            string lastName;
            string firstName;
            string carModel;
            int age;
            int salary;
            int campus;
            string city;

            Console.Clear();
            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Edit an existing driver by ID ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(driverId);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" :\n\n");

            // Récupération des données dans la base

            using (var objRecupDonnees = new Database1Entities())
            {
                var query = from x
                    in objRecupDonnees.DriverSet
                            where x.Id.Equals(driverId)
                            select x;
                var resultatQuery = query.First();

                // Affiche les informations du Driver contenu dans la base de donnée

                // Last Name
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("1");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Last Name :  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                resultatQuery.Last_Name = UneMajusculeDevantSVP.UneMajusculeDevant(resultatQuery.Last_Name);
                Console.Write(resultatQuery.Last_Name);
                Console.Write("\n\n");

                // First Name
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("2");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  First Name : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                resultatQuery.First_Name = UneMajusculeDevantSVP.UneMajusculeDevant(resultatQuery.First_Name);
                Console.Write(resultatQuery.First_Name);
                Console.Write("\n\n");

                // Car Model
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("3");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Car Model :  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                resultatQuery.Car_Model = UneMajusculeDevantSVP.UneMajusculeDevant(resultatQuery.Car_Model);
                Console.Write(resultatQuery.Car_Model);
                Console.Write("\n\n");

                // age
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("4");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Age :        ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(resultatQuery.Age);
                Console.Write("\n\n");

                // salary
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("5");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Salary :     ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string salaryString = resultatQuery.Salary.ToString();

                if (resultatQuery.Salary > 0 && resultatQuery.Salary < 1000) // Si le salaire est entre 1 et 999, on affiche salary
                {
                    Console.Write("${0}", resultatQuery.Salary);
                }
                else if (resultatQuery.Salary >= 1000 && resultatQuery.Salary < 10000) // Si le salaire est compris entre 1000 et 9999 on affiche le salaire sous forme $X.XXX
                {
                    Console.Write("${0}.{1}{2}{3}", salaryString[0], salaryString[1], salaryString[2], salaryString[3]);
                }
                else if (resultatQuery.Salary >= 10000 && resultatQuery.Salary <= 20000) // Si le salaire est compris entre 10000 et 19999 on affiche le salaire sous forme $XX.XXX
                {
                    Console.Write("${0}{1}.{2}{3}{4}", salaryString[0], salaryString[1], salaryString[2], salaryString[3], salaryString[4]);
                }
                Console.Write("\n\n");

                lastName = resultatQuery.Last_Name;
                firstName = resultatQuery.First_Name;
                carModel = resultatQuery.Car_Model;
                age = resultatQuery.Age;
                salary = resultatQuery.Salary;
                campus = resultatQuery.Campus;
                city = resultatQuery.City;

                // campus
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("6");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Campus :     ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(resultatQuery.Campus);
                Console.Write("\n\n");

                // city
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" [ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("7");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  City :       ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                resultatQuery.City = UneMajusculeDevantSVP.UneMajusculeDevant(resultatQuery.City);
                Console.Write(resultatQuery.City);
                Console.WriteLine("\n\n");
            }

            // Les données sont maintenant récupérées et affichées

            do
            {
                // What is your choice ?
                bonneReponse = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Y");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to continue or ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to back : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                reponse = Console.ReadLine();

                if (reponse == "Y" || reponse == "y") // Si Yes, on continue
                {
                    bonneReponse = true;
                }
                else if (reponse == "N" || reponse == "n") // Si No, on quitte
                {
                    bonneReponse = true;
                    Console.Clear();
                    EditerUnDriverSVP.EditerUnDriver(); // Redirection sur l'édition + reset des valeurs
                }
                else // En cas d'erreur
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid answer. Press Y or N.\n");
                }
            } while (bonneReponse == false);
            Console.WriteLine("");

            // On peut maintenant choisir quel valeur doit être éditée

            do
            {
                // What is your choice ?
                bonneReponse = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" What do you want to edit : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                reponse = Console.ReadLine();
                bool analyseur = int.TryParse(reponse, out choixInt);

                Console.ForegroundColor = ConsoleColor.Red;
                if (analyseur == false) // Si ce n'est pas un nombre -> erreur
                {
                    bonneReponse = false;
                    Console.WriteLine(" This is not a number.\n");
                }
                else if (choixInt < 1 || choixInt > 7) // En cas d'erreur autre
                {
                    Console.WriteLine(" Wrong number.\n");
                }
            } while (bonneReponse == false);
            Console.WriteLine();

            // Le choix est bon

            switch (choixInt)
            {
                // Redirection
                case 1:
                    EditerDonnees.EditerLastName(lastName, driverId);
                    break;
                case 2:
                    EditerDonnees.EditerFirstName(firstName, driverId);
                    break;
                case 3:
                    EditerDonnees.EditerCarModel(carModel, driverId);
                    break;
                case 4:
                    EditerDonnees.EditerAge(age, driverId);
                    break;
                case 5:
                    EditerDonnees.EditerSalary(salary, driverId);
                    break;
                case 6:
                    EditerDonnees.EditerCampus(campus, driverId);
                    break;
                case 7:
                    EditerDonnees.EditerCity(city, driverId);
                    break;
            }
        }
    }
}
