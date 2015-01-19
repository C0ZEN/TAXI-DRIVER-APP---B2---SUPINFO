using System;

namespace B2_2NET_Mini_Projet1
{
    public static class AjouterUnDriverAffichageSVP
    {
        public static void AjouterUnDriverAffichage(string lastName, string firstName, string carModel, int age, int salary, int campus, string city)
        {
            // Cette méthode affiche les données du driver
            // Si l'utilisateur n'a pas encore saisi de données, alors les données sont null par défaut
            // Cette méthode est appelée juste après une saisie correcte par l'utilisateur
            // Par conséquent la méthode est très utile pour afficher à l'écran cette dernière donnée

            AffichageTitre.AfficherTitre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Fill the blank to create a driver\n\n");

            // Last Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Last Name :  ");

            if (lastName != null) // Si pas null, on affiche le last name saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lastName);
            }
            Console.WriteLine("\n");

            // First Name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" First Name : ");

            if (firstName != null) // Si pas null, on affiche le first name saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(firstName);
            }
            Console.WriteLine("\n");

            // Car Model
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Car Model :  ");

            if (carModel != null) // Si pas null, on affiche le car model saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(carModel);
            }
            Console.WriteLine("\n");

            // age
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Age :        ");

            if (age > 0) // Si plus grand que zero, on affiche l'age saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(age);
            }
            Console.WriteLine("\n");

            // salary
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Salary :     ");
            string salaryString = salary.ToString();

            if (salary > 0 && salary < 1000) // Si le salaire est entre 1 et 999, on affiche salary
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("${0}", salary);
            }
            else if (salary >= 1000 && salary < 10000) // Si le salaire est compris entre 1000 et 9999 on affiche le salaire sous forme $X.XXX
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("${0}.{1}{2}{3}", salaryString[0], salaryString[1], salaryString[2], salaryString[3]);
            }
            else if (salary >= 10000 && salary <= 20000) // Si le salaire est compris entre 10000 et 19999 on affiche le salaire sous forme $XX.XXX
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("${0}{1}.{2}{3}{4}", salaryString[0], salaryString[1], salaryString[2], salaryString[3], salaryString[4]);
            }
            Console.WriteLine("\n");

            // campus (non saisi par l'utilisateur, je ne sais pas ce qu'est le campus..)
            // Par défaut toujours le 170862
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Campus :     ");

            if (campus > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(campus);
            }
            Console.WriteLine("\n");

            // city
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" +");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" City :       ");

            if (city != null) // Si pas null, on affiche la ville saisi au préalable
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(city);
            }
            Console.WriteLine("\n\n");
        }
    }
}
