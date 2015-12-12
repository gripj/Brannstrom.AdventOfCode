using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day5.Rules;

namespace Brannstrom.AdventOfCode.Day5
{
    public class StringAnalyzer
    {
        private readonly IEnumerable<IRule> _rules;
        private readonly Elf _elf;
         
        public StringAnalyzer(IEnumerable<IRule> rules)
        {
            _rules = rules;
            _elf = new Elf();
        }

        public bool StringIsNice(string input)
        {
            return _rules.All(x => x.IsNice(input));
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
            return _elf.ReadSantasStringList();
        }
    }
}
