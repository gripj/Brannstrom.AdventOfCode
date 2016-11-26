using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day11.PasswordRequirements;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Next_Valid_Password()
        {
            var requirements = new List<IRequirement>()
            {
                new IncreasingStraightOfThreeLettersRequirement(),
                new DisallowedCharactersRequirement(),
                new DifferentNonOverlappingPairsRequirement()
            };
            var analyzer = new PasswordAnalyzer(requirements);

            analyzer.FindNextValidPassword(analyzer.FindNextValidPassword("vzbxkghb")).Should().Be("vzcaabcc");
        }
    }
}
