using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    [TestCase(18, 16, "90,269,16")]
    [TestCase(42, 12, "232,251,12")]
    public void Should_Find_Identifier_For_Square_With_Largest_Total_Power_In_Examples(int serialNumber, int size, string expectedIdentifier)
    {
      var identifier = PowerGrid.FindIdentifierOfSquareWithLargestTotalPower(serialNumber, size);
      identifier.Should().Be(expectedIdentifier);
    }

    [Test]
    public void Should_Find_Identifier_For_Square_With_Largest_Total_Power()
    {
      var identifier = PowerGrid.FindIdentifierOfSquareWithLargestTotalPower(7139);
      identifier.Should().Be("229,61,16");
    }
  }
}
