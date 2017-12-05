using System.IO;
using System.Linq;
using Brannstrom.AdventOfCode.Day5.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void StrangeJumpInstruction_Should_Increase_Offset_By_One_After_Jump()
        {
            var instruction = new StrangeJumpInstruction(-1);
            instruction.Jump().Should().Be(-1);
            instruction.Jump().Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Steps_To_Reach_Exit_In_Example()
        {
            new Computer(
                "0 3 0 1 -3"
                    .Split(' ')
                    .Select(x => new StrangeJumpInstruction(int.Parse(x)))
                    .ToArray<JumpInstruction>()
            )
            .CalculateStepsToReachExit()
            .Should()
            .Be(5);
        }

        [Test]
        public void Should_Calculate_Steps_To_Reach_Exit()
        {
            new Computer(
                File
                .ReadAllLines("input.txt")
                .Select(x => new StrangeJumpInstruction(int.Parse(x)))
                .ToArray<JumpInstruction>()
            )
            .CalculateStepsToReachExit()
            .Should()
            .Be(358131);
        }
    }
}
