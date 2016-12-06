using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day6
{
    public class SignalDecrypter
    {
        public string DecryptSignalsIntoMessage(IEnumerable<string> signals)
        {
            return new string(
                GroupSignalsIntoCharactersLists(signals)
                    .Select(signalCollection => signalCollection.GroupBy(x => x)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key).First())
                    .ToArray());
        }

        public string DecryptSignalsIntoMessageUsingLeastLikelyMethod(IEnumerable<string> signals)
        {
            return new string(
                GroupSignalsIntoCharactersLists(signals)
                    .Select(signalCollection => signalCollection.GroupBy(x => x)
                    .OrderBy(grp => grp.Count())
                    .Select(grp => grp.Key).First())
                    .ToArray());
        }

        private static IEnumerable<List<char>> GroupSignalsIntoCharactersLists(IEnumerable<string> signals)
        {
            var collectionOfSignalCharacters = new List<List<char>>();

            for (var i = 0; i<signals.First().Length; i++)
                collectionOfSignalCharacters.Add(signals.Select(x => x[i]).ToList());

            return collectionOfSignalCharacters;
        } 
    }
}
