using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Calculate_Number_Of_Pots_With_Plants_In_Example()
    {
      var input = new List<string>()
      {
        "initial state: #..#.#..##......###...###",
        "",
        "...## => #",
        "..#.. => #",
        ".#... => #",
        ".#.#. => #",
        ".#.## => #",
        ".##.. => #",
        ".#### => #",
        "#.#.# => #",
        "#.### => #",
        "##.#. => #",
        "##.## => #",
        "###.. => #",
        "###.# => #",
        "####. => #"
      };

      new RowOfPots().CalculateNumberOfPlantsAfterNGenerations(input, 20).Should().Be(325);
    }

    [Test]
    public void Should_Calculate_Number_Of_Pots_With_Plants()
    {
      new RowOfPots().CalculateNumberOfPlantsAfterNGenerations(InputReader.Read(), 20).Should().Be(2930);
    }
  }
}
