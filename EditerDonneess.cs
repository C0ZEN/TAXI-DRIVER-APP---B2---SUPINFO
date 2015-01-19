using System;
using System.Collections.Generic;
using System.Linq;

namespace B2_2NET_Mini_Projet1
{
    public static class EditerDonnees
    {
        public static void EditerLastName(string oldLastName, int driverId)
        {
            string newLastName;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                // Verifications des données saisies
                donneesCorrectes = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new Last Name : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                newLastName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(newLastName))
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Last Name can not be null.\n");
                }
                else if (newLastName.Length > 50)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Last Name is 50 char maximum.\n");
                }
                else if (QueDesLettresSVP.QueDesLettres(newLastName) == false)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Last Name must contain only letters.\n");
                }
            } while (donneesCorrectes == false);
            Console.WriteLine();

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                // Si le driverId = 3,
                // Alors il faut chercher à l'index driverId - 1 pour obtenir la bonne occurence
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.Last_Name = newLastName;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new Last Name is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newLastName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldLastName);
            Console.WriteLine();
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }

        public static void EditerFirstName(string oldFirstName, int driverId)
        {
            string newFirstName;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                donneesCorrectes = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new First Name : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                newFirstName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(newFirstName))
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" First Name can not be null.\n");
                }
                else if (newFirstName.Length > 50)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" First Name is 50 char maximum.\n");
                }
                else if (QueDesLettresSVP.QueDesLettres(newFirstName) == false)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" First Name must contain only letters.\n");
                }
            } while (donneesCorrectes == false);
            Console.WriteLine();

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.First_Name = newFirstName;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new First Name is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(newFirstName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldFirstName);
            Console.WriteLine();
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }

        public static void EditerCarModel(string oldCarModel, int driverId)
        {
            string newCarModel;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                donneesCorrectes = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new Car Model : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                newCarModel = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                if (string.IsNullOrEmpty(newCarModel))
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Car Model can not be null.\n");
                }
                else if (newCarModel.Length > 50)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Car Model is 50 char maximum.\n");
                }
                else if (QueDesLettresSVP.QueDesLettres(newCarModel) == false)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Car Model must contain only letters.\n");
                }
            } while (donneesCorrectes == false);
            Console.WriteLine();

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.Car_Model = newCarModel;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new Car Model is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newCarModel);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldCarModel);
            Console.WriteLine();
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }

        public static void EditerAge(int oldAge, int driverId)
        {
            int newAge;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                donneesCorrectes = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new age : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string newAgeString = Console.ReadLine();
                bool analyseur = int.TryParse(newAgeString, out newAge);

                Console.ForegroundColor = ConsoleColor.Red;
                if (analyseur == false)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" This is not a number.\n");
                }
                else if (newAge < 21)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" A taxi driver is at least 21 years old.\n");
                }
                else if (newAge > 99)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" Nobody can drive at {0} years.\n", newAge);
                }
            } while (donneesCorrectes == false);
            Console.WriteLine();

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.Age = newAge;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new age is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newAge);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldAge);
            Console.WriteLine();
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }

        public static void EditerSalary(int oldSalary, int driverId)
        {
            int newSalary;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                donneesCorrectes = true;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new salary : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string newSalaryString = Console.ReadLine();
                bool analyseur = int.TryParse(newSalaryString, out newSalary);

                Console.ForegroundColor = ConsoleColor.Red;
                if (analyseur == false)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" This is not a number.\n");
                }
                else if (newSalary < 500)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" A taxi driver earn more than {0}.\n", newSalary);
                }
                else if (newSalary > 20000)
                {
                    donneesCorrectes = false;
                    Console.WriteLine(" A taxi driver can't earn more than 20000 per month.\n");
                }
            } while (donneesCorrectes == false);

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.Salary = newSalary;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new salary is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newSalary);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldSalary);
            Console.WriteLine();
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }

        public static void EditerCampus(int oldCampus, int driverId)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" You can't change the campus.\n");
            YesOrNo.AfficherYesOrNo(driverId);
        }

        public static void EditerCity(string oldCity, int driverId)
        {
            string newCity;
            bool donneesCorrectes;
            int driverIdImpec = driverId;

            do
            {
                donneesCorrectes = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Enter the new city : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                newCity = Console.ReadLine();
                newCity = newCity.ToLower();

                Console.ForegroundColor = ConsoleColor.Red;
                if (newCity.Equals("paris") || newCity.Equals("lyon") || newCity.Equals("marseille"))
                {
                    donneesCorrectes = true;
                }
                else if (string.IsNullOrEmpty(newCity))
                {
                    Console.WriteLine(" City can not be null.\n");
                }
                else
                {
                    Console.WriteLine(" The city must be Paris, Marseille or Lyon.\n");
                }
            } while (donneesCorrectes == false);
            Console.WriteLine();

            // Les données sont correctes, on peut faire l'update

            using (var objUpdate = new Database1Entities())
            {
                List<Driver> objDrivers = objUpdate.DriverSet.ToList<Driver>();
                Driver objDriver = objDrivers[driverId - 1];
                objDriver.City = newCity;
                objUpdate.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The new city is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(newCity);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" The old one is ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(oldCity);
            YesOrNo.AfficherYesOrNo(driverIdImpec);
        }
    }
}
