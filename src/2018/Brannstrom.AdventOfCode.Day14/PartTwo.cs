using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Test()
    {
      RecipeScoreCalculation.CalculateNumberOfRecipesLeftOfScore("920831").Should().Be(20236441);
    }
  }
}
