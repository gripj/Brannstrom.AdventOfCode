using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day14
{
  public static class RecipeScoreCalculation
  {
    public static string CalculateScoresFollowingNumberOfRecipes(int number) => SlidingWindow(10).ElementAt(number).st;

    public static int CalculateNumberOfRecipesLeftOfScore(string input) => SlidingWindow(input.Length).First(item => item.st == input).i;

    public static IEnumerable<(int i, string st)> SlidingWindow(int w)
    {
      var scores = "";
      var i = 0;
      foreach (var score in Scores())
      {
        i++;
        scores += score;
        if (scores.Length > w)
          scores = scores.Substring(scores.Length - w);

        if (scores.Length == w)
          yield return (i - w, scores);
      }
    }

    public static IEnumerable<int> Scores()
    {
      var scores = new List<int>();
      Func<int, int> add = (i) => { scores.Add(i); return i; };

      var elf1 = 0;
      var elf2 = 1;

      yield return add(3);
      yield return add(7);

      while (true)
      {
        var sum = scores[elf1] + scores[elf2];

        if (sum >= 10)
          yield return add(sum / 10);

        yield return add(sum % 10);

        elf1 = (elf1 + scores[elf1] + 1) % scores.Count;
        elf2 = (elf2 + scores[elf2] + 1) % scores.Count;
      }
    }
  }
}
