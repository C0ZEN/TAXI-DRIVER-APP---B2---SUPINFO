namespace B2_2NET_Mini_Projet1
{
    public static class QueDesLettresSVP
    {
        public static bool QueDesLettres(string stringPrompt)
        {
            // Retourne true si la string contient que des lettres
            bool resultat = true;

            foreach (char lettre in stringPrompt)
            {
                if (char.IsLetter(lettre) == false)
                {
                    resultat = false;
                }
            }

            return resultat;
        }
    }
}
