using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Calculate_Resulting_Frequency()
    {
      InputReader.Read().Select(int.Parse).Sum().Should().Be(529);
    }
  }
}
