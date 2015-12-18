using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Number_Of_Combinations_For_Minimum_Amount_Of_Combinations()
        {
            var containerSizes = new Reader().GetAvailableContainerSizes();
            var numberOfCombinations = new ContainerAnalyzer().GetNumberOfCombinationsForMinimumAmountOfContainers(containerSizes, 150);
            numberOfCombinations.Should().Be(18);
        }

        [Test]
        public void Should_Find_Combinations_Based_On_Container_Sizes()
        {
            var containerSizes = new List<string>() { "20", "15", "10", "5", "5" };
            var numberOfCombinations = new ContainerAnalyzer().GetNumberOfCombinationsForMinimumAmountOfContainers(containerSizes, 25);
            numberOfCombinations.Should().Be(3);
        }
    }
}
