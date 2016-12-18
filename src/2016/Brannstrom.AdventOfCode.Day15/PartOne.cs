using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Parse_Disc()
        {
            var disc = Disc.Parse("Disc #2 has 17 positions; at time=0, it is at position 15.");

            disc.Id.Should().Be(2);
            disc.NumberOfPositions.Should().Be(17);
            disc.StartPosition.Should().Be(15);
        }

        [Test]
        public void Should_Calculate_Time_To_Press_Button_In_Example()
        {
            var discDescriptions = new List<string>()
            {
               "Disc #1 has 5 positions; at time=0, it is at position 4.",
                "Disc #2 has 2 positions; at time=0, it is at position 1."
            };

            var discs = discDescriptions.Select(Disc.Parse);

            var discAnalyzer = new DiscAnalyzer(discs);

            discAnalyzer
                .CalculateTimeToPressButton()
                .Should()
                .Be(5);
        }

        [Test]
        public void Should_Calculate_Time_To_Press_Button()
        {
            var discDescriptions = new InputReader().ReadFile();

            var discs = discDescriptions.Select(Disc.Parse);

            var discAnalyzer = new DiscAnalyzer(discs);

            discAnalyzer
                .CalculateTimeToPressButton()
                .Should()
                .Be(203660);
        }
    }
}
