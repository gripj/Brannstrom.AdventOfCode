using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Generator_Should_Generate_Sequence_In_Example()
        {
            var generator = new Generator("A", 16807, 65);

            var sequence = generator.GenerateSequence().Take(5).ToList();

            sequence[0].Should().Be(1092455);
            sequence[1].Should().Be(1181022009);
            sequence[2].Should().Be(245556042);
            sequence[3].Should().Be(1744312007);
            sequence[4].Should().Be(1352636452);
        }

        [Test]
        public void Judge_Should_Count_Matching_Pairs_In_Example()
        {
            var generatorA = new Generator("A", 16807, 65);
            var generatorB = new Generator("B", 48271, 8921);

            var judge = new Judge(generatorA, generatorB);

            judge.CountMatchingPairs(5).Should().Be(1);
        }

        [Test]
        [Ignore("Long running")]
        public void Judge_Should_Count_Matching_Pairs_With_Full_Sequence_Length_In_Example()
        {
            var generatorA = new Generator("A", 16807, 65);
            var generatorB = new Generator("B", 48271, 8921);

            var judge = new Judge(generatorA, generatorB);

            judge.CountMatchingPairs(40000000).Should().Be(588);
        }

        [Test]
        [Ignore("Long running")]
        public void Judge_Should_Count_Matching_Pairs()
        {
            var generatorA = new Generator("A", 16807, 289);
            var generatorB = new Generator("B", 48271, 629);

            var judge = new Judge(generatorA, generatorB);

            judge.CountMatchingPairs(40000000).Should().Be(588);
        }
    }
}
