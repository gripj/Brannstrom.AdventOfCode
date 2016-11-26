using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartTwo
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
            _seatArranger.SeatHost();
            var maximumHappiness = _seatArranger.GetBestSeatPlacements();
            maximumHappiness.Should().Be(640);
        }
    }
}
