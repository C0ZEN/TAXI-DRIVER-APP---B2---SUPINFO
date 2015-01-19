using System;

namespace B2_2NET_Mini_Projet1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Quelques ajustements graphiques
            Console.Title = "MY TAXI DRIVER"; // Modification du titre de la console
            Console.SetWindowSize(60, 40); // Modification de la fenêtre
            Console.SetBufferSize(60, 40); // Modification du buffer et suppression des ascenseurs
            Console.ForegroundColor = ConsoleColor.White; // Texte blanc par défaut
            AfficherMenuPrincipal(); // Affichage du menu principal
        }

        public static void AfficherMenuPrincipal()
        {
            int choixInt;
            bool analyseur;
            AffichageTitre.AfficherTitre();
            Console.WriteLine("\n");

            // Add a driver
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 1 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]" + "\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Add a driver\n");

            // Edit a driver
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 2 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]" + "\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Edit a driver\n");

            // Add a trip
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 3 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]" + "\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Add a trip\n");

            // Import trips
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 4 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]" + "\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Import trips\n");

            // View all trips for a driver
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  [");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" 5 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]" + "\t   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("View all trips for a driver\n\n\n");

            do
            {
                // What is your choice ?
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" What is your choice ? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string choixString = Console.ReadLine(); // Prompt de navigation
                analyseur = int.TryParse(choixString, out choixInt); // Tentative de conversion (string -> int)

                Console.ForegroundColor = ConsoleColor.Red;
                if (analyseur == false) // Ce n'est pas un nombre
                {
                    Console.WriteLine(" This is not a number.\n");
                }
                else if (string.IsNullOrEmpty(choixString))
                {
                    Console.WriteLine(" Make a choice !\n");
                }
                else // C'est un nombre mais trop petit ou trop grand
                {
                    Console.WriteLine(" Wrong number.\n");
                }
            } while (!analyseur || choixInt <= 0 || choixInt >= 6);
            Console.Clear(); // Efface l'écran

            switch (choixInt) // Redirection en fonction du choix
            {
                case 1:
                    AjouterUnDriverSVP.AjouterUnDriver();
                    break;
                case 2:
                    EditerUnDriverSVP.EditerUnDriver();
                    break;
                case 3:
                    AjouterUnVoyageSVP.AjouterUnVoyage();
                    break;
                case 4:
                    ImporterUnVoyageSVP.ImporterUnVoyage();
                    break;
                case 5:
                    VoirVoyagePourDriverSVP.VoirVoyagePourDriver();
                    break;
                default:
                    AfficherMenuPrincipal();
                    break;
            }
        }
    }
}
