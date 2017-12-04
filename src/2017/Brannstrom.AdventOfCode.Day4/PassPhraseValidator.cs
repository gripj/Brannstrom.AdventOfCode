using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day4
{
    public class PassPhraseValidator
    {
        public bool ValidateDistinct(string passphrase)
        {
            var words = passphrase.Split(' ');
            return words.Distinct().Count() == words.Length;
        }

        public bool Validate(string passphrase)
        {
            return ValidateDistinct(passphrase.SortWordCharacters());
        }
    }

    public static class PassPhraseExtensions {
        public static string SortWordCharacters(this string @string)
        {
            return @string
                    .Split(' ')
                    .Select(SortWord)
                    .Join();
        }

        private static string SortWord(string word)
        {
            return word.ToCharArray().Sort().ToWord();
        }

        private static char[] Sort(this char[] array)
        {
            Array.Sort(array);
            return array;
        }

        private static string ToWord(this char[] array) => new string(array);
        private static string Join(this IEnumerable<string> words) => string.Join(" ", words);
    }
}
