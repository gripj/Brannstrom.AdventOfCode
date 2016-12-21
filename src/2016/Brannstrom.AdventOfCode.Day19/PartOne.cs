using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Get_Elf_With_Presents_In_Example()
        {
            new CircleOfElves(5)
                .GetWinnerWhenStealingLeft()
                .Id
                .Should()
                .Be(3);
        }

        [Test]
        public void Should_Get_Elf_With_Presents()
        {
            new CircleOfElves(3005290)
                .GetWinnerWhenStealingLeft()
                .Id
                .Should()
                .Be(1816277);
        }
    }
}
