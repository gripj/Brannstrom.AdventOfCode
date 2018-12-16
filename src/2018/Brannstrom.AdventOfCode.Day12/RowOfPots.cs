using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12
{
  public class RowOfPots
  {
    public long CalculateNumberOfPlantsAfterNGenerations(IEnumerable<string> input, long generations)
    {
      var (state, rules) = Parse(input);

      while (generations > 0)
      {
        var prevState = state;
        state = Step(state, rules);
        generations--;

        if (state.pots == prevState.pots)
        {
          var dLeftPos = state.left - prevState.left;
          state = new State { left = state.left + generations * dLeftPos, pots = state.pots };
          break;
        }
      }

      return Enumerable.Range(0, state.pots.Length).Select(i => state.pots[i] == '#' ? i + state.left : 0).Sum();
    }

    private static State Step(State state, Dictionary<string, string> plantLifeRules)
    {
      var pots = "....." + state.pots + ".....";
      var newPots = "";
      for (var i = 2; i < pots.Length - 2; i++)
      {
        var x = pots.Substring(i - 2, 5);
        newPots += plantLifeRules.TryGetValue(x, out var ch) ? ch : ".";
      }

      var firstFlower = newPots.IndexOf("#");
      var newLeft = firstFlower + state.left - 3;

      newPots = newPots.Substring(firstFlower).Substring(0, newPots.LastIndexOf("#") + 1);
      var res = new State { left = newLeft, pots = newPots };

      return res;
    }

    private static (State state, Dictionary<string, string> rules) Parse(IEnumerable<string> input)
    {
      var list = input.ToList();
      var state = new State { left = 0, pots = list[0].Substring("initial state: ".Length) };
      var rules = (from line in list.Skip(2) let parts = line.Split(new [] { " => " }, StringSplitOptions.None) select new { key = parts[0], value = parts[1] }).ToDictionary(x => x.key, x => x.value);
      return (state, rules);
    }

    private class State
    {
      public long left;
      public string pots;
    }
  }
}
