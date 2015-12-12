using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Brannstrom.AdventOfCode.Day5
{
    public class StringAnalyzer
    {
        private int NumberOfVowelsFound { get; set; }
        private bool HasLetterTwiceInARow { get; set; }
        private readonly List<string> _disallowedStrings = new List<string>() { "ab", "cd", "pq", "xy"};
        private int MinNumberOfVowels => 3;


        public bool StringIsNice(string input)
        {
            Initialize();

            var charArray = input.ToCharArray();
            char lastCharacter = '\0';
            foreach (var ch in charArray)
            {
                if (ch.IsVowel())
                    NumberOfVowelsFound++;
                if (ch.Equals(lastCharacter))
                    HasLetterTwiceInARow = true;

                lastCharacter = ch;
            }

            return NumberOfVowelsFound >= MinNumberOfVowels && HasLetterTwiceInARow && !_disallowedStrings.Any(input.Contains);
        }

        private void Initialize()
        {
            NumberOfVowelsFound = 0;
            HasLetterTwiceInARow = false;
        }



        public int GetNumberOfNiceStringsFromSantasList()
        {
            return GetNumberOfNiceStringsFromList(ReadSantasStringList());
        }

        public int GetNumberOfNiceStringsFromList(IEnumerable<string> stringList)
        {
            return stringList.Count(StringIsNice);
        }

        private IEnumerable<string> ReadSantasStringList()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day5.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
