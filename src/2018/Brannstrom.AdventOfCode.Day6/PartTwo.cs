using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Find_Size_Of_Region_In_Example()
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

      CoordinateCalculator.FindLargestRegion(coordinates, 32).Should().Be(16);
    }

    [Test]
    public void Should_Find_Size_Of_Region()
    {
      CoordinateCalculator.FindLargestRegion(InputReader.Read(), 10000).Should().Be(40244);
    }
  }
}
