using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day5.Rules
{
    public class PairOfLettersAppearingAtLeastTwiceWithoutOverlappingRule : IRule
    {
        public bool IsNice(string input)
        {
            var pairs = new List<string>();
            var charArray = input.ToCharArray();
            var lastPair = "";
            var skippedPair = false;

            for (var i = 0; i < charArray.Length - 1; i++)
            {
                var pair = charArray[i].ToString() + charArray[i + 1];
                if (pair != lastPair || skippedPair)
                {
                    skippedPair = false;
                    pairs.Add(pair);
                }
                else
                    skippedPair = true;

                lastPair = pair;
            }

            return pairs.Distinct().Count() < pairs.Count;
        }
    }
}
