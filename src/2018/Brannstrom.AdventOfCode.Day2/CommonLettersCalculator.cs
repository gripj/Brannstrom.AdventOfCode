using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day2
{
  public static class CommonLettersCalculator
  {
    public static string Calculate(IReadOnlyList<string> boxIds)
    {
      return Enumerable.Range(1, boxIds.First().Length - 1).Select(diff =>
          boxIds
            .Select((x, i) => boxIds
              .Skip(i + 1)
              .Select(boxId => boxId.ToSimilarCharacters(boxIds.ElementAt(i))))
            .SelectMany(x => x)
            .FirstOrDefault(x => x.Count == boxIds.First().Length - diff)
            ?.Join()
        )
        .First(x => x != null);
    }
  }

  public static class Extensions
  {
    public static List<char> ToSimilarCharacters(this string word, string otherWord) => word.Where((c, i) => c == otherWord[i]).ToList();
    public static string Join(this List<char> array) => string.Join("", array);
  }
}
