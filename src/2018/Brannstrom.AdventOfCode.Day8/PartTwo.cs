using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Calculate_Value_Of_Root_Node_In_Example()
    {
      Node.Parse("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2").Value().Should().Be(66);
    }

    [Test]
    public void Should_Calculate_Value_Of_Root_Node()
    {
      Node.Parse(InputReader.Read()).Value().Should().Be(23636);
    }
  }
}
