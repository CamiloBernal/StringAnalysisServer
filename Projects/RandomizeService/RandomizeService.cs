using RandomizeService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomizeService
{
    public static class Text
    {
        private static System.Random Generator = new System.Random();

        private static string GetRandomChar(bool AllowSpecialChars)
        {
            string vRet = String.Empty;
            List<string> ValidChars = null;
            if (AllowSpecialChars)
            {
                ValidChars = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ". ", ".\n", ", " };
            }
            else
            {
                ValidChars = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            }
            int ValidCharIndex = GetRandomNumber(1, ValidChars.Count - 1);
            ValidChars.Shuffle();
            vRet = ValidChars[ValidCharIndex];
            return vRet;
        }

        public static string GetRandomPhrase(int PhraseLen, bool AllowSpecialChars = false)
        {
            string GeneratePhrase = String.Empty;
            for (int i = 1; i <= PhraseLen; i++)
            {
                GeneratePhrase += GetRandomChar(AllowSpecialChars);
            }
            return GeneratePhrase;
        }

        public static string GetRandomPhrase(int PhraseSize)
        {
            StringBuilder sbGeneratePhrase = new StringBuilder(String.Empty);
            List<string> ValidChars = new List<string> { ".\n", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", " ", "k", "m", "n", "o", "p", "q", "r", " ", "s", "t", "u", "v", "w", "x", "y", "z", " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", " ", "K", "L", "M", "N", "O", "P", "Q", "R", "S", " ", "T", "U", "V", "W", "X", "Y", "Z", "0", " ", "1", "2", "3", "4", "5", "6", "7", "8", " ", "9", ". ", ", ", " " };
            bool PhraseComplete = false;
            int currentSize = 0;

            while (!PhraseComplete)
            {
                ValidChars.Shuffle();
                var newOrder = ValidChars.OrderBy(t => new Random());
                ValidChars.ForEach(i => sbGeneratePhrase.Append(i));
                currentSize = System.Text.ASCIIEncoding.ASCII.GetByteCount(sbGeneratePhrase.ToString());

                if (currentSize > 1000)
                    PhraseComplete = true;
            }
            return sbGeneratePhrase.ToString();
        }

        private static int GetRandomNumber(int min, int max)
        {
            lock (Generator)
            {
                return Generator.Next(min, max);
            }
        }
    }
}