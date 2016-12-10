using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Multiply_Specified_Output_Microchip_Values()
        {
            var instructions = new InputReader().ReadFile();

            var factory = new BotFactory();
            factory.ApplyInstructions(instructions);

            factory
                .Bots
                .Where(x => x.Id == "output 0" ||
                            x.Id == "output 1" ||
                            x.Id == "output 2")
                .SelectMany(x => x.Microchips)
                .Aggregate((a, b) => a*b)
                .Should()
                .Be(37789);
        }
    }
}
