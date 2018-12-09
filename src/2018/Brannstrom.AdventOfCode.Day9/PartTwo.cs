using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Calculate_Winning_Game_Score_If_Highest_Marble_Value_Is_100_Times_Larger()
    {
      var input = InputReader.Read();
      MarbleGame.CalculateHighScore(input.AmountOfPlayers, input.HighestMarbleNumber * 100).Should().Be(3527845091);
    }
  }
}
