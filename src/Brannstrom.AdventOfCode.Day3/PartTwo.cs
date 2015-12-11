using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartTwo
    {
        private Santa _santa;
        private Santa _roboSanta;
        private Elf _elf;

        [SetUp]
        public void SetUp()
        {
            _santa = new Santa();
            _roboSanta = new Santa();
            _elf = new Elf();
        }

        [Test]
        public void Calculate_Amount_Of_Houses_To_Receive_Presents()
        {
            DeliverPresents();
            var amountOfHousesVisted = _santa.VisitedHouses.Union(_roboSanta.VisitedHouses).Count();
            amountOfHousesVisted.Should().Be(2360);
        }

        private void DeliverPresents()
        {
            var directions = _elf.GetDirections();
            var directionsToSanta = string.Join("", directions.Where((ch, index) => (index % 2) == 0));
            var directionsToRoboSanta = string.Join("", directions.Where((ch, index) => (index % 2) != 0));

            _santa.DeliverPresents(directionsToSanta);
            _roboSanta.DeliverPresents(directionsToRoboSanta);
        }
    }
}