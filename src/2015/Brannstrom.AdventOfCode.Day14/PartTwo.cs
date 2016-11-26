using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Race_Using_Points()
        {
            var contestants = new Lineup().GetContestants().ToList();
            var race = new Race(contestants);
            race.Go(2503);
            race.PointsLeader.Points.Should().Be(1059);
        }

        [Test]
        public void Should_Award_Points_To_Contestant_In_The_Lead()
        {
            var contestants = new List<Reindeer>()
            {
                new Reindeer("A", 10, 2, 10),
                new Reindeer("B", 13, 2, 10),
                new Reindeer("C", 3, 2, 10)
            };
            var race = new Race(contestants);

            race.Go(5);

            contestants.Single(x => x.Name.Equals("A")).Points.Should().Be(0);
            contestants.Single(x => x.Name.Equals("B")).Points.Should().Be(5);
            contestants.Single(x => x.Name.Equals("C")).Points.Should().Be(0);
        }
    }
}
