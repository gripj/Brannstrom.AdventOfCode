using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Copy_Instruction_Should_Copy_Value()
        {
            var registers = new List<Register>()
            {
                new Register("a", 3)
            };

            new CopyInstruction().Execute(registers, "cpy 41 a");

            registers.First().Value.Should().Be(41);
        }

        [Test]
        public void Copy_Instruction_Should_Copy_Value_From_Register()
        {
            var registers = new List<Register>()
            {
                new Register("a", 3),
                new Register("b", 7)
            };

            new CopyInstruction().Execute(registers, "cpy b a");

            registers.First().Value.Should().Be(7);
        }

        [Test]
        public void Copy_Instruction_Should_Copy_Negative_Numbers()
        {
            var registers = new List<Register>()
            {
                new Register("c", 7)
            };

            new CopyInstruction().Execute(registers, "cpy -16 c");

            registers.First().Value.Should().Be(-16);
        }

        [Test]
        public void Increase_Instruction_Should_Increase_Register_Value_By_One()
        {
            var registers = new List<Register>()
            {
                new Register("a", 3)
            };

            new IncreaseInstruction().Execute(registers, "inc a");

            registers.First().Value.Should().Be(4);
        }

        [Test]
        public void Decrease_Instruction_Should_Decrease_Register_Value_By_One()
        {
            var registers = new List<Register>()
            {
                new Register("a", 3)
            };

            new DecreaseInstruction().Execute(registers, "dec a");

            registers.First().Value.Should().Be(2);

        }

        [Test]
        public void Jump_Instruction_Should_Jump_Steps_If_Register_Has_Non_Zero_Value()
        {
            var registers = new List<Register>()
            {
                new Register("a", 3)
            };

            var steps = new JumpInstruction().Execute(registers, "jnz a -2");

            steps.Should().Be(-2);
        }

        [Test]
        public void Jump_Instruction_Should_Go_To_Next_Instruction_If_Register_Has_Zero_As_Value()
        {
            var registers = new List<Register>()
            {
                new Register("a", 0)
            };

            var steps = new JumpInstruction().Execute(registers, "jnz a -2");

            steps.Should().Be(1);
        }

        [Test]
        public void Jump_Instruction_Should_Jump_Steps_If_Value_Is_Non_Zero()
        {
            var registers = new List<Register>()
            {
                new Register("a", 0)
            };

            var steps = new JumpInstruction().Execute(registers, "jnz 1 -2");

            steps.Should().Be(-2);
        }

        [Test]
        public void Should_Calculate_Value_In_Example_Instructions()
        {
            var instructions = new List<string>()
            {
                "cpy 41 a",
                "inc a",
                "inc a",
                "dec a",
                "jnz a 2",
                "dec a"
            };

            var instructionExecutors = new List<IExecuteInstruction>()
            {
                new CopyInstruction(),
                new DecreaseInstruction(),
                new IncreaseInstruction(),
                new JumpInstruction()
            };

            var computer = new Computer(instructionExecutors, instructions);

            computer.ExecuteInstructions();

            computer.GetRegisterValue("a").Should().Be(42); 
        }

        [Test]
        public void Should_Calculate_Value_In_Register_a()
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

            computer.ExecuteInstructions();

            computer.GetRegisterValue("a").Should().Be(318003);
        }
    }
}
