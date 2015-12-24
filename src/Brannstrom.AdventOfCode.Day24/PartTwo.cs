using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Quantum_Entanglement_When_Trunk_Is_Added()
        {
            new WeightDistributer().FindQuantumEntanglement(4).Should().Be(77387711);
        }
    }
}
