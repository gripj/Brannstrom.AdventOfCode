using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Find_Location_Of_First_Crash_In_Example()
    {
      var exampleInput = new List<string>()
      {
        "/->-\\        ",
        "|   |  /----\\",
        "| /-+--+-\\  |",
        "| | |  | v  |",
        "\\-+-/  \\-+--/",
        "\\------/     "
      };

      RailTrack.FindLocationOfFirstCrash(exampleInput).Should().Be("7,3");
    }

    [Test]
    public void Should_Find_Location_Of_First_Crash()
    {
      RailTrack.FindLocationOfFirstCrash(InputReader.Read()).Should().Be("109,23");
    }
  }
}
