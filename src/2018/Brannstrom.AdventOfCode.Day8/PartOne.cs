using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Calculate_Sum_Of_Metadata_Entries_In_Example()
    {
      CalculateSumOfMetadata("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2").Should().Be(138);
    }

    [Test]
    public void Should_Calculate_Sum_Of_Metadata_Entries()
    {
      CalculateSumOfMetadata(InputReader.Read()).Should().Be(47647);
    }

    private static int CalculateSumOfMetadata(string input) =>
      Node.Parse(input).Reduce(0, (cur, node) => cur + node.Metadata.Sum());
  }
}
