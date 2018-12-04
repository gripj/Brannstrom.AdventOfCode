using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Find_Claim_With_No_Overlap_in_Example()
    {
      var claims = new List<string>()
        {
          "#1 @ 1,3: 4x4",
          "#2 @ 3,1: 4x4",
          "#3 @ 5,5: 2x2"
        }
        .Select(Claim.Parse)
        .ToList();

      var overlappingClaims = new HashSet<int>(claims.GetOverlappingFabricSquares().Select(x => x.Value).SelectMany(x => x));

      claims.First(x => !overlappingClaims.Contains(x.Id)).Id.Should().Be(3);
    }

    [Test]
    public void Should_Find_Claim_With_No_Overlap()
    {
      var claims = InputReader.Read().Select(Claim.Parse).ToList();

      var overlappingClaims = new HashSet<int>(claims.GetOverlappingFabricSquares().Select(x => x.Value).SelectMany(x => x));

      claims.First(x => !overlappingClaims.Contains(x.Id)).Id.Should().Be(695);
    }
  }
}

