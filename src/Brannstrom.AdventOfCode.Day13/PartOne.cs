using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartOne
    {
        private SeatArranger _seatArranger;

        [SetUp]
        public void SetUp()
        {
            _seatArranger = new SeatArranger();
        }

        [Test]
        public void Should_Optimize_Seat_Placements()
        {
            var maximumHappiness = _seatArranger.GetBestSeatPlacements();
            maximumHappiness.Should().Be(664);
        }

        [Test]
        public void Should_Get_Possible_Seating_Arrangements()
        {
            var guests = new List<Person>()
            {
                new Person("One"),
                new Person("Two"),
                new Person("Three"),
                new Person("Four")
            };

            _seatArranger.GetPossibleSeatingArrangements(guests).Count.Should().Be(4*3*2);
        }
    }
}
