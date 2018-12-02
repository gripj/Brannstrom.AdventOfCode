using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Number_Of_Times_Mul_Instruction_Is_Invoked()
        {
            new Computer().CalculateTimesMulIsInvoked(File.ReadAllLines("input.txt")).Should().Be(9409);
        }
    }
}
