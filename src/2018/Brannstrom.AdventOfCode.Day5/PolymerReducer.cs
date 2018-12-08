using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day5
{
  public static class PolymerReducer
  {
    public static int Reduce(string polymer)
    {
      var stack = new Stack<string>();

      foreach (var u in polymer)
      {
        var unit = u.ToString();

        var lastUnit = stack.Count == 0 ? string.Empty : stack.Peek();

        if (lastUnit != "" && lastUnit.ToLower() == unit.ToLower() && lastUnit != unit)
          stack.Pop();
        else
          stack.Push(unit);
      }

      return stack.Count;
    }

    public static int ImprovedReduce(string polymer)
    {
      return "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
              .Select(letter => Reduce(polymer.Replace(letter.ToString(), "").Replace(letter.ToString().ToLower(), "")))
              .ToList()
              .Min();
    }
  }
}
