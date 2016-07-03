using Eviivo.Domain.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Domain
{
    public class StringMatch : IStringMatch
    {
        public IList<int> Match(string text, string subtext)
        {
            var positons = new List<int>();

            var subTextArray = StringHelperClass.SplitString(subtext);
            
            foreach (var textElement in subTextArray)
            {             
                var subTextChars = StringHelperClass.ToCharArray(textElement);
                var textChars = StringHelperClass.ToCharArray(text);
                var subtextLength = StringHelperClass.LengthOfString(textElement);
                var textLength = StringHelperClass.LengthOfString(text);

                positons.AddRange(GetSubtextPositions(textChars, textLength, subTextChars, subtextLength));
            }

            return positons;
        }
        
        private IList<int> GetSubtextPositions(char[] textChars, int textLength, char[] subTextChars, int subtextLength)
        {
            int count = 0;
            int subTextPosition = 0;
            var positions = new List<int>();

            for (int charPosition = 1; charPosition <= textLength; charPosition++)
            {
                if (textChars[charPosition - 1] == subTextChars[subTextPosition])
                {
                    count = count == 0 ? charPosition : count;
                    subTextPosition++;

                    if (subTextPosition == subtextLength)
                    {
                        positions.Add(count);
                        subTextPosition = 0;
                        count = 0;
                        charPosition--;
                    }
                }
                else
                {

                    subTextPosition = 0;
                    count = 0;
                }
            }

            return positions;
        }
    }
}
