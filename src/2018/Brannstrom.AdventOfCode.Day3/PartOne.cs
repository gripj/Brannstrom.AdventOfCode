using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Create_Claim_From_Input()
    {
      var rectangle = Claim.Parse("#123 @ 3,2: 5x4");
      rectangle.Id.Should().Be(123);
      rectangle.FabricSquares.Count.Should().Be(20);
    }

    [Test]
    public void Should_Find_Square_Inches_Within_Several_Claims_In_Example()
    {
      new List<string>()
        {
          "#1 @ 1,3: 4x4",
          "#2 @ 3,1: 4x4",
          "#3 @ 5,5: 2x2"
        }
        .Select(Claim.Parse)
        .GetOverlappingFabricSquares()
        .Count()
        .Should()
        .Be(4);
    }

    [Test]
    public void Should_Find_Square_Inches_Within_Several_Claims()
    {
      InputReader.Read()
        .Select(Claim.Parse)
        .GetOverlappingFabricSquares()
        .Count()
        .Should()
        .Be(104126);
    }

  }
}
