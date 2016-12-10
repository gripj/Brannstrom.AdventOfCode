using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day10.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void GiveMicrochipToBotInstruction_Should_Give_Microchip_To_Bot()
        {
            var factory = new BotFactory();

            new GiveMicrochipToBotInstruction().Apply(factory, "value 3 goes to bot 1");

            factory.GetBot("bot 1").Microchips.Should().Contain(3);
        }

        [Test]
        public void DistributeMicrochipsInstruction_Should_Distribute_Microchips()
        {
            var bots = new List<Bot>()
            {
                new Bot("bot 1", 3),
                new Bot("bot 2", 2, 5)
            };

            var factory = new BotFactory(bots);

            new DistributeMicrochipsInstruction().Apply(factory, "bot 2 gives low to bot 1 and high to bot 0");

            factory.GetBot("bot 0").Microchips.Should().Contain(5);
            factory.GetBot("bot 1").Microchips.Should().Contain(2);
            factory.GetBot("bot 2").Microchips.Should().BeEmpty();
        }

        [Test]
        public void Should_Apply_Test_Instructions_Correctly()
        {
            var instructions = new List<string>()
            {
                "value 5 goes to bot 2",
                "bot 2 gives low to bot 1 and high to bot 0",
                "value 3 goes to bot 1",
                "bot 1 gives low to output 1 and high to bot 0",
                "bot 0 gives low to output 2 and high to output 0",
                "value 2 goes to bot 2"
            };

            var factory = new BotFactory();
            factory.ApplyInstructions(instructions);

            factory
                .MicroshipTransactions
                .First(x => x.Microchips.Contains(2)
                            && x.Microchips.Contains(5))
                .BotId
                .Should()
                .Be("bot 2");
        }

        [Test]
        public void Should_Find_Bot_Responsible_For_Comparing_Specified_Microchips()
        {
            var instructions = new InputReader().ReadFile();

            var factory = new BotFactory();
            factory.ApplyInstructions(instructions);

            factory
                .MicroshipTransactions
                .First(x => x.Microchips.Contains(61) 
                            && x.Microchips.Contains(17))
                .BotId
                .Should()
                .Be("bot 101");
        }
    }
}
