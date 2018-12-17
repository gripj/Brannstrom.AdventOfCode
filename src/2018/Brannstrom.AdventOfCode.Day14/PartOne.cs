using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Test()
    {
      RecipeScoreCalculation.CalculateScoresFollowingNumberOfRecipes(920831).Should().Be("7121102535");
    }
  }
}
