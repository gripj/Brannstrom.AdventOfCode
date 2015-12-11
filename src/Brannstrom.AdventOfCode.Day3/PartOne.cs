using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartOne
    {
        private Santa _santa;

        [SetUp]
        public void SetUp()
        {
            _santa = new Santa();
        }

        [Test]
        public void Calculate_Amount_Of_Houses_To_Receive_Presents()
        {
            var directions = new Elf().GetDirections();
            _santa.DeliverPresents(directions);
            _santa.VisitedHouses.Count().Should().Be(2592);
        }

        [Test]
        [TestCase(">", 2)]
        [TestCase("^>v<", 4)]
        public void Should_Calculate_Amount_Of_Houses_That_Receive_Presents(string directions, int expectedAmountOfHouses)
        {
            _santa.DeliverPresents(directions);
            _santa.VisitedHouses.Count().Should().Be(expectedAmountOfHouses);
        }
    }
}
