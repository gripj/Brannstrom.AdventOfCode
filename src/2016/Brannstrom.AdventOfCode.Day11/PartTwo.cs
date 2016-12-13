using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Minimum_Number_Of_Steps_To_Bring_All_Items_To_Top_Floor()
        {
            var arrangements = new InputReader().ReadFile().ToList();

            const string additionalArrangements = 
                "The first floor contains an elerium generator, an elerium-compatible microchip, " +
                "a dilithium generator and a dilithium-compatible microchip.";

            arrangements.Add(additionalArrangements);

            new SolutionSolver()
                .Solve(arrangements)
                .Should()
                .Be(71);
        }
    }
}
