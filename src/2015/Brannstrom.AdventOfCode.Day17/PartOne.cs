using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_Maximum_Number_Of_Combinations()
        {
            var containerSizes = new Reader().GetAvailableContainerSizes();
            var numberOfCombinations = new ContainerAnalyzer().GetNumberOfCombinationsContainersCanBeFilled(containerSizes, 150);
            numberOfCombinations.Should().Be(1304);
        }

        [Test]
        public void Should_Find_Combinations_Based_On_Container_Sizes()
        {
            var containerSizes = new List<string>() { "20", "15", "10", "5", "5" };
            var numberOfCombinations = new ContainerAnalyzer().GetNumberOfCombinationsContainersCanBeFilled(containerSizes, 25);
            numberOfCombinations.Should().Be(4);
        }
    }
}
