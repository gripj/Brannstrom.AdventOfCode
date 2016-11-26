using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartOne
    {
        private WeightDistributer _weightDistributer;

        [SetUp]
        public void SetUp()
        {
            _weightDistributer = new WeightDistributer();
        }

        [Test]
        public void Should_Find_Quantum_Entanglement_Of_First_Group_Of_Packages()
        {
            _weightDistributer.FindQuantumEntanglement(3).Should().Be(11266889531);
        }

        [Test]
        public void Should_Calculate_Group_Quantum_Entanglement()
        {
            var group = new List<int>() {2,3,4};
            _weightDistributer.CalculateQE(group).Should().Be(24);
        }
    }
}
