using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using Brannstrom.AdventOfCode.Day23.ToggleInstructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Register_Value()
        {
            var instructions = new InputReader()
                                .ReadFile()
                                .ToList();

            var instructionExecutors = new List<IExecuteInstruction>()
            {
                new CopyInstruction(),
                new DecreaseInstruction(),
                new IncreaseInstruction(),
                new JumpInstruction()
            };

            var instructionsTogglers = new List<IToggleInstruction>()
            {
                new ToggleOneArgumentInstruction(),
                new ToggleTwoArgumentInstruction()
            };

            var computer = new AdvancedComputer(instructionExecutors, instructionsTogglers, instructions);

            computer.SetRegisterValue("a", 12);
            computer.ExecuteInstructions();

            computer
                .GetRegisterValue("a")
                .Should()
                .Be(479009610);
        }
    }
}
