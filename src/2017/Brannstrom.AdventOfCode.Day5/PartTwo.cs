using System.IO;
using System.Linq;
using Brannstrom.AdventOfCode.Day5.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        public void StrangerJumpInstruction_Should_Decrease_Offset_By_One_If_Previous_Was_Three_Or_More(int previousOffset, int nextExpectedOffset)
        {
            var instruction = new StrangerJumpInstruction(previousOffset);
            instruction.Jump();
            instruction.Jump().Should().Be(nextExpectedOffset);
        }

        [Test]
        public void StrangerJumpInstruction_Should_Increase_Offset_By_One_If_Previous_Was_Less_Than_Three()
        {
            var instruction = new StrangerJumpInstruction(2);
            instruction.Jump();
            instruction.Jump().Should().Be(3);
        }

        [Test]
        public void Should_Calculate_Steps_To_Reach_Exit_In_Example()
        {
            new Computer(
                    "0 3 0 1 -3"
                        .Split(' ')
                        .Select(x => new StrangerJumpInstruction(int.Parse(x)))
                        .ToArray<JumpInstruction>()
                )
                .CalculateStepsToReachExit()
                .Should()
                .Be(10);
        }

        [Test]
        public void Should_Calculate_Steps_To_Reach_Exit()
        {
            new Computer(
                    File
                        .ReadAllLines("input.txt")
                        .Select(x => new StrangerJumpInstruction(int.Parse(x)))
                        .ToArray<JumpInstruction>()
                )
                .CalculateStepsToReachExit()
                .Should()
                .Be(25558839);
        }
    }
}
