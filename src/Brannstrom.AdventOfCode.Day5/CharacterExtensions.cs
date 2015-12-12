using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day5
{
    public static class CharacterExtensions
    {
        private static readonly List<char> Vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

        public static bool IsVowel(this char ch)
        {
            return Vowels.Contains(ch);
        }
    }
}
