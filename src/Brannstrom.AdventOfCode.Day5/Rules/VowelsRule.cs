using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day5.Rules
{
    public class VowelsRule : IRule
    {
        private static readonly List<char> Vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        public bool IsNice(string input)
        {
            var charArray = input.ToCharArray();
            var numberOfVowels = charArray.Where(Vowels.Contains).Count();
            return numberOfVowels >= 3;
        }
    }
}
