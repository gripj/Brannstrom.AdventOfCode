using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_The_Sue_We_Are_Looking_For_With_New_Instructions()
        {
            var reader = new Reader();;

            var informationList = new Reader().ReadList();
            var sues = informationList.Select(information => new Sue(information)).ToList();

            var knownCompounds = reader.GetKnownCompounds();
            var theSueWeAreLookingFor = sues.Single(s => s.HasCompoundsWhenSomeValuesIndicateRanges(knownCompounds));
            theSueWeAreLookingFor.Id.Should().Be(241);
        }
    }
}
