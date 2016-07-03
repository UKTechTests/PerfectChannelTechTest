using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Domain.HelperClasses
{
    public static class StringHelperClass
    {
        public static char[] ToCharArray(string text)
        {
            var result = new List<char>();

            foreach (var character in text)
            {
                result.Add(character);
            }

            return result.ToArray();
        }

        public static int LengthOfString(string subtext)
        {
            int count = 0;
            foreach (char letter in subtext)
            {
                count++;
            }

            return count;
        }

        public static List<string> SplitString(string input)
        {
            var result = new List<string>();


            string arrayElement = null;

            foreach (var character in input)
            {
                if (char.IsLetter(character))
                {
                    arrayElement += character;
                }

                if (!char.IsLetter(character) && arrayElement != null)
                {
                    result.Add(arrayElement);
                    arrayElement = null;
                }

            }

            if (arrayElement != null)
            {
                result.Add(arrayElement);
            }

            return result;
        }
    }
}
