using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Domain
{
    public class Class1
    {
        public IList<int> Match(string text, string subtext)
        {
            int count = 0;
                       
            text = ConvertToUpperCase(text);
            subtext = ConvertToUpperCase(subtext);

            var subTextChars = ToCharArray(subtext);
            var textChars = ToCharArray(text);

            var subtextLength = LengthOf(subtext);
            var textLength = LengthOf(text);

            var positons = new List<int>();

            var match = false;

            int subTextPosition = 0;

            for (int charPosition = 1; charPosition <= textLength; charPosition++)
            {
                if (textChars[charPosition -1] == subTextChars[subTextPosition])
                {
                    count = count == 0 ? charPosition : count;
                    subTextPosition++;

                    if (subTextPosition == subtextLength)
                    {
                        positons.Add(count);
                        subTextPosition = 0;
                        count = 0;
                    }
                }
                else
                {

                    subTextPosition = 0;
                    count = 0;
                    match = false;
                }
            }

            return positons;
        }

        private char[] ToCharArray(string text)
        {
            var result = new List<char>();

            foreach(var character in text)
            {
                result.Add(character);
            }

            return result.ToArray();
        }

        public static String ConvertToUpperCase(String input)
        {
            String output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    output += (char)(input[i] - 'a' + 'A');
                }
                else
                    output += input[i];
            }
            return output;
        }

        private static int LengthOf(string subtext)
        {
            int count = 0;
            foreach (char letter in subtext)
            {
                count++;
            }

            return count;
        }
    }
}
