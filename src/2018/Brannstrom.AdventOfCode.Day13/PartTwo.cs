using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Find_Location_Of_Last_Cart()
    {
      RailTrack.FindLocationOfLastCart(InputReader.Read()).Should().Be("137,101");
    }
  }
}
