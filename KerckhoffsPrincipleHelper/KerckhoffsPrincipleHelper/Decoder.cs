namespace KerckhoffsPrincipleHelper
{
    public static class Decoder
    {
        public static string GetOpenText(string codedText1, string codedText2, string openText1)
        {
            string openText2 = string.Empty;

            int lenght = codedText1.Length < codedText2.Length ? codedText1.Length : codedText2.Length;
            lenght = openText1.Length < lenght ? openText1.Length : lenght;
            for (int i = 0; i < lenght; i++)
            {
                openText2 += GetOpenLetter(codedText1[i], codedText2[i], openText1[i]);
            }
            return openText2;
        }

        public static char GetOpenLetter(char code1, char code2, char text1)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int decodedLetterIndex = (alphabet.IndexOf(code2) - alphabet.IndexOf(code1) + alphabet.IndexOf(text1));
            while (decodedLetterIndex < 0)
                decodedLetterIndex += 26;
            decodedLetterIndex %= 26;
            return alphabet[decodedLetterIndex];
        }
    }
}
