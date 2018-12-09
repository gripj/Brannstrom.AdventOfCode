using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    [TestCase(9, 25, 32)]
    [TestCase(10, 1618, 8317)]
    [TestCase(13, 7999, 146373)]
    [TestCase(17, 1104, 2764)]
    [TestCase(21, 6111, 54718)]
    [TestCase(30, 5807, 37305)]
    public void Should_Calculate_Winning_Game_Scores_In_Examples(int amountOfPlayers, int highestMarbleNumber, int highScore)
    {
      MarbleGame.CalculateHighScore(amountOfPlayers, highestMarbleNumber).Should().Be(highScore);
    }

    [Test]
    public void Should_Calculate_Winning_Game_Score()
    {
      var input = InputReader.Read();
      MarbleGame.CalculateHighScore(input.AmountOfPlayers, input.HighestMarbleNumber).Should().Be(436720);
    }
  }
}
