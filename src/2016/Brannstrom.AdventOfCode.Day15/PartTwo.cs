using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Time_To_Press_Button()
        {
            var discDescriptions = new InputReader().ReadFile().ToList();
            discDescriptions.Add("Disc #7 has 11 positions; at time=0, it is at position 0.");

            var discs = discDescriptions.Select(Disc.Parse);

            var discAnalyzer = new DiscAnalyzer(discs);

            discAnalyzer
                .CalculateTimeToPressButton()
                .Should()
                .Be(2408135);
        }
    }
}
