using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
  [TestFixture]
  public class PointTests
  {
    [Test]
    public void Should_Create_Point_From_Input()
    {
      var point = Point.Parse("position=< 7,  1> velocity=<-1,  17>");
      point.X.Should().Be(7);
      point.Y.Should().Be(1);
      point.V.X.Should().Be(-1);
      point.V.Y.Should().Be(17);
    }

    [Test]
    public void Point_Should_Generate_Next_Point()
    {
      var next = Point.Parse("position=<1,  -1> velocity=<-2,  3>").Next();
      next.X.Should().Be(-1);
      next.Y.Should().Be(2);
      next.V.X.Should().Be(-2);
      next.V.Y.Should().Be(3);
    }
  }
}
