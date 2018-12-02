using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    [TestCase(new[] { 1, -2, 3, 1 }, 2)]
    [TestCase(new[] { 1, -1 }, 0)]
    [TestCase(new[] { 3, 3, 4, -2, -4 }, 10)]
    [TestCase(new[] { -6, 3, 8, 5, -6 }, 5)]
    [TestCase(new[] { 7, 7, -2, -7, -4 }, 14)]
    public void Should_Find_First_Frequency_Reached_Twice_In_Examples(IEnumerable<int> changes, int firstRepeatedFrequency)
    {
      RepeatingFrequencyFinder.Find(changes).Should().Be(firstRepeatedFrequency);
    }

    [Test]
    public void Should_Find_First_Frequency_Reached_Twice()
    {
      RepeatingFrequencyFinder.Find(InputReader.Read().Select(int.Parse)).Should().Be(464);
    }

    public static class RepeatingFrequencyFinder
    {
      public static int Find(IEnumerable<int> changes)
      {
        var frequencies = new HashSet<int>() { 0 };
        var currentFrequency = frequencies.Last();
        foreach (var change in IterateOver(changes))
        {
          currentFrequency += change;

          if (frequencies.Contains(currentFrequency))
            return currentFrequency;

          frequencies.Add(currentFrequency);
        }

        throw new InvalidOperationException("Unreachable");
      }

      private static IEnumerable<int> IterateOver (IEnumerable<int> changes)
      {
        while (true)
          foreach (var change in changes)
            yield return change;
      }
    }
  }
}
