using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Judge_Should_Count_Matching_Pairs_With_Critera_In_Example()
        {
            var generatorA = new Generator("A", 16807, 65);
            var generatorB = new Generator("B", 48271, 8921);

            var judge = new Judge(generatorA, generatorB);

            judge.CountMatchingPairsWithCritera(1056).Should().Be(1);
        }

        [Test]
        [Ignore("Long running")]
        public void Judge_Should_Count_Matching_Pairs_With_Critera()
        {
            var generatorA = new Generator("A", 16807, 289);
            var generatorB = new Generator("B", 48271, 629);

            var judge = new Judge(generatorA, generatorB);

            judge.CountMatchingPairsWithCritera(5000000).Should().Be(343);
        }
    }
}
