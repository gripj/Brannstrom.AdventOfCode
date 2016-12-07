using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day7
{
    public class IPAddress
    {
        public IEnumerable<string> SupernetSequences { get; }
        public IEnumerable<string> HypernetSequences { get; }

        public IPAddress(IEnumerable<string> supernetSequences, IEnumerable<string> hypernetSequences)
        {
            SupernetSequences = supernetSequences;
            HypernetSequences = hypernetSequences;
        }

        public static IPAddress Parse(string input)
        {
            const string pattern = @"\[[a-z]+\]";

            var supernetSequences = Regex.Replace(input, pattern, "-")
                                        .Split('-')
                                        .ToList();

            var hypernetSequences = Regex.Matches(input, pattern)
                                        .Cast<Match>()
                                        .Select(m => m.Value.Trim('[', ']'))
                                        .ToList();

            return new IPAddress(supernetSequences, hypernetSequences);
        }

        public bool SupportsTLS => SupernetSequences.Any(ContainsAbba) && !HypernetSequences.Any(ContainsAbba);

        private static bool ContainsAbba(string input)
        {
            const string pattern = @"([a-z])([a-z])\2\1";

            return Regex.Matches(input, pattern)
                    .Cast<Match>()
                    .Any(m => m.Value[0] != m.Value[1]);
        }

        public bool SupportsSSL => AbaBlocks.Any(x => BabBlocks.Contains(ConvertToBAB(x)));

        private IEnumerable<string> AbaBlocks => GetAbaSequences(SupernetSequences);
        private IEnumerable<string> BabBlocks => GetAbaSequences(HypernetSequences);

        private static IEnumerable<string> GetAbaSequences(IEnumerable<string> list)
        {
            foreach (var seq in list)
                for (var i = 0; i < seq.Count() - 2; i++)
                    if (seq[i] == seq[i + 2] && seq[i] != seq[i + 1])
                        yield return seq.Substring(i, 3);
        }

        private static string ConvertToBAB(string input)
        {
            var aba = input.ToCharArray();
            char[] reversedAba = { aba[1], aba[0], aba[1] };
            return new string(reversedAba);
        }
    }
}
