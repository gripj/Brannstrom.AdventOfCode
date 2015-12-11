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
        private int x;
        private int y;
        private List<House> _visitedHouses;

        [SetUp]
        public void SetUp()
        {
            x = 0;
            y = 0;
            _visitedHouses = new List<House>();
        }

        [Test]
        public void Calculate_Amount_Of_Houses_To_Receive_Presents()
        {
            var directions = ReadListOfDirections().First();
            AmountOfHousesThatReceivePresents(directions).Should().Be(2592);
        }

        [Test]
        [TestCase(">", 2)]
        [TestCase("^>v<", 4)]
        public void Should_Calculate_Amount_Of_Houses_That_Receive_Presents(string directions, int expectedAmountOfHouses)
        {
            AmountOfHousesThatReceivePresents(directions).Should().Be(expectedAmountOfHouses);
        }

        private int AmountOfHousesThatReceivePresents(string directions)
        {
            _visitedHouses.Add(new House(x,y));
            foreach (var direction in directions.ToCharArray())
            {
                GoToNextHouse(direction);
                var vistedHouse = new House(x,y);
                if (!_visitedHouses.Contains(vistedHouse))
                    _visitedHouses.Add(new House(x, y));
            }
            return _visitedHouses.Count();
        }

        private void GoToNextHouse(char direction)
        {
            switch (direction)
            {
                case ('>'):
                    x++;
                    break;
                case ('<'):
                    x--;
                    break;
                case ('^'):
                    y++;
                    break;
                case ('v'):
                    y--;
                    break;
            }
        }

        private IEnumerable<string> ReadListOfDirections()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day3.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
