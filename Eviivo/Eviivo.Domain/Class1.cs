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
            var subTextArray = SplitString(subtext);
            var positons = new List<int>();

            foreach (var part in subTextArray)
            {
                int count = 0;
                //text = ConvertToUpperCase(text);
                //subtext = ConvertToUpperCase(subtext);

                var subTextChars = ToCharArray(part);
                var textChars = ToCharArray(text);

                var subtextLength = LengthOf(part);
                var textLength = LengthOf(text);

                int subTextPosition = 0;

                for (int charPosition = 1; charPosition <= textLength; charPosition++)
                {
                    if (textChars[charPosition - 1] == subTextChars[subTextPosition])
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
                    }
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

        private static List<string> SplitString(string input)
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

            if(arrayElement != null)
            {
                result.Add(arrayElement);
            }

            return result;
        }
    }
}
