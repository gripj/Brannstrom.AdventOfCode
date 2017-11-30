using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using Brannstrom.AdventOfCode.Day23.ToggleInstructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase("inc a", "dec a")]
        [TestCase("dec a", "inc a")]
        [TestCase("tgl a", "inc a")]
        public void ToggleOneArgumentInstruction_Should_Toggle_One_Argument_Instructions(
            string instruction, string expectedResult)
        {
            new ToggleOneArgumentInstruction()
                .ToggleInstruction(instruction)
                .Should()
                .Be(expectedResult);
        }

        [Test]
        [TestCase("jnz 1 a", "cpy 1 a")]
        [TestCase("cpy 1 a", "jnz 1 a")]
        public void ToggleTwoArgumentInstruction_Should_Toggle_Two_Argument_Instructions(
            string instruction, string expectedResult)
        {
            new ToggleTwoArgumentInstruction()
                .ToggleInstruction(instruction)
                .Should()
                .Be(expectedResult);
        }

        [Test]
        public void Should_Calculate_Example_Register_Value()
        {
            var instructions = new List<string>()
            {
                "cpy 2 a",
                "tgl a",
                "tgl a",
                "tgl a",
                "cpy 1 a",
                "dec a",
                "dec a"
            };

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

            computer.ExecuteInstructions();

            computer
                .GetRegisterValue("a")
                .Should()
                .Be(3);
        }

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

            computer.SetRegisterValue("a", 7);
            computer.ExecuteInstructions();

            computer
                .GetRegisterValue("a")
                .Should()
                .Be(13050);
        }
    }
}
