using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Calculate_Number_Of_Pots_With_Plants_After_Fifty_Billion_Generations()
    {
      new RowOfPots().CalculateNumberOfPlantsAfterNGenerations(InputReader.Read(), 50000000000).Should().Be(3099999999491);
    }
  }
}
