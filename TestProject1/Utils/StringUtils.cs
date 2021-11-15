using System;

namespace TestProject1.Utils
{
    class StringUtils
    {
        public static string GetRandomText(int minTextLength, int maxTextLength)
        {
            //AqualityServices.LocalizedLogger.Info("Getting random text");
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890".ToCharArray();
            Random rand = new Random();
            int textCount = rand.Next(minTextLength, maxTextLength);
            string text = "";

            for (int i = 1; i <= textCount; i++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                text += letters[letter_num];
            }

            return text;
        }
    }
}
