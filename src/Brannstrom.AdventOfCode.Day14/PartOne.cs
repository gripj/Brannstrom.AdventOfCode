using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Race()
        {
            var contestants = new Lineup().GetContestants().ToList();
            var race = new Race(contestants);
            race.Go(2503);
            race.DistanceLeader.DistanceTravelled.Should().Be(2655);
        }

        [Test]
        public void Reindeer_Should_Fly()
        {
            var reindeer = new Reindeer("Rudolf", 10, 10, 10);
            reindeer.Fly();
            reindeer.DistanceTravelled.Should().Be(10);
        }

        [Test]
        [TestCase(10, 2, 3, 80)]
        [TestCase(20, 20, 0, 400)]
        [TestCase(1, 1, 19, 1)]
        [TestCase(3, 7, 5, 42)]
        public void Should_Not_Fly_When_Resting(int speed, int timeUntilRest, int restTime, int expectedDistanceTravelled)
        {
            var reindeer = new Reindeer("Rudolf", speed, timeUntilRest, restTime);

            for (var i = 1; i <= 20; i++ )
                reindeer.Fly();

            reindeer.DistanceTravelled.Should().Be(expectedDistanceTravelled);
        }

        [Test]
        public void Race_Should_Elapse_For_Specified_Amount_Of_Time()
        {
            var contestants = new List<Reindeer>()
            {
                new Reindeer("A", 10, 2, 3),
                new Reindeer("B", 13, 17, 8),
                new Reindeer("C", 3, 7, 5)
            };
            var race = new Race(contestants);

            race.Go(30);

            contestants.Single(x => x.Name.Equals("A")).DistanceTravelled.Should().Be(120);
            contestants.Single(x => x.Name.Equals("B")).DistanceTravelled.Should().Be(13*22);
            contestants.Single(x => x.Name.Equals("C")).DistanceTravelled.Should().Be(20*3);
        }

        [Test]
        public void Lineup_Should_Provide_Contestants()
        {
            var contestants = new Lineup().GetContestants().ToList();
            contestants.Count().Should().BeGreaterThan(0);

            foreach (var contestant in contestants)
                contestant.Name.Should().NotBeEmpty();
        }
    }
}
