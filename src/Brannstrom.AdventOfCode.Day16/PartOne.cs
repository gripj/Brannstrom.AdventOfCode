using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_The_Sue_We_Are_Looking_For()
        {
            var reader = new Reader();

            var informationList = new Reader().ReadList();
            var sues = informationList.Select(information => new Sue(information)).ToList();

            var knownCompounds = reader.GetKnownCompounds();
            var theSueWeAreLookingFor = sues.Single(s => s.HasCompounds(knownCompounds));
            theSueWeAreLookingFor.Id.Should().Be(40);
        }

        [Test]
        public void Sue_Should_Be_Identifiable()
        {
            new Sue("Sue 1: goldfish: 9, cars: 0, samoyeds: 9").Id.Should().Be(1);
        }

        [Test]
        public void Sue_Should_Get_Compounds()
        {
            var sue = new Sue("Sue 1: goldfish: 9, cars: 0, samoyeds: 9");
            sue.Compounds["goldfish"].Should().Be(9);
            sue.Compounds["cars"].Should().Be(0);
            sue.Compounds["samoyeds"].Should().Be(9);
        }
    }
}
