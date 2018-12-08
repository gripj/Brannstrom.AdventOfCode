using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Find_Largest_Area_In_Example()
    {
      var coordinates = new List<string>()
      {
        "1, 1",
        "1, 6",
        "8, 3",
        "3, 4",
        "5, 5",
        "8, 9"
      };

      CoordinateCalculator.FindLargestArea(coordinates).Should().Be(17);
    }

    [Test]
    public void Should_Find_Largest_Area()
    {
      CoordinateCalculator.FindLargestArea(InputReader.Read()).Should().Be(5941);
    }
  }
}
