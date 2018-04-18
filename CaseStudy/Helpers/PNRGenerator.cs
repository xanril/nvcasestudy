using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Helpers
{
    public class PNRGenerator
    {
        private const int MAX_LENGTH = 6;
        private static string charset = "ABCDEFGHJKLMNOPQRSTUVWXYZ1234567890";
        private static string letterset = "ABCDEFGHJKLMNOPQRSTUVWXYZ";

        private static Random fyRandom = new Random();

        // First character should be a letter
        // exacly 6 characters
        // alpha numeric, uppercase
        public static string Get(Random rand)
        {
            // generate for first letter.
            char[] letterArray = letterset.ToCharArray();
            char[] charArray = charset.ToCharArray();

            FisherYatesShuffle<char>(letterArray);
            FisherYatesShuffle<char>(charArray);

            char firstChar = letterArray[rand.Next(0, letterset.Length)];
            StringBuilder strBuilder = new StringBuilder();

            for(int i = 0; i < MAX_LENGTH - 1; i++)
            {
                strBuilder.Append(charArray[rand.Next(0, charArray.Length)]);
            }

            string generatedPNR = string.Format("{0}{1}", firstChar, strBuilder.ToString());
            return generatedPNR;
        }

        private static void FisherYatesShuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + fyRandom.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
