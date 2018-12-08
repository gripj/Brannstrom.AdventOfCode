using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Reduce_Polymer_In_Example()
    {
      PolymerReducer.Reduce("dabAcCaCBAcCcaDA").Should().Be(10);
    }

    [Test]
    public void Should_Reduce_Polymer()
    {
      PolymerReducer.Reduce(InputReader.Read()).Should().Be(11364);
    }
  }
}
