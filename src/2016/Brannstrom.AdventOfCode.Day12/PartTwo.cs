using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Value_In_Register_a_When_Register_c_Starts_At_One()
        {
            var instructions = new InputReader().ReadFile().ToList();

            var instructionExecutors = new List<IExecuteInstruction>()
            {
                new CopyInstruction(),
                new DecreaseInstruction(),
                new IncreaseInstruction(),
                new JumpInstruction()
            };

            var computer = new Computer(instructionExecutors, instructions);

            computer.SetRegisterValue("c", 1);
            computer.ExecuteInstructions();

            computer.GetRegisterValue("a").Should().Be(9227657);
        }
    }
}
