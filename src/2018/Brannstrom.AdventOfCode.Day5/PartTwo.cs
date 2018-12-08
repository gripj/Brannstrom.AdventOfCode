using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Find_Shortest_Polymer_In_Example()
    {
      PolymerReducer.ImprovedReduce("dabAcCaCBAcCcaDA").Should().Be(4);
    }

    [Test]
    public void Should_Find_Shortest_Polymer()
    {
      PolymerReducer.ImprovedReduce(InputReader.Read()).Should().Be(4212);
    }
  }
}
