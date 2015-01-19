namespace B2_2NET_Mini_Projet1
{
    public static class UneMajusculeDevantSVP
    {
        public static string UneMajusculeDevant(string monAncienneString)
        {
            // Affiche la première lettre d'une string en majuscule
            string maNouvelleString = monAncienneString[0].ToString().ToUpper() + monAncienneString.Substring(1).ToLower();
            return maNouvelleString;
        }
    }
}
