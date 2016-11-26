using Brannstrom.AdventOfCode.Day23.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartOne
    {
        private uint[] _registers;
        private readonly int _indexOfA = 0;
        private readonly int _indexOfB = 1;

        [SetUp]
        public void SetUp()
        {
            _registers = new uint[2];
        }

        [Test]
        public void Should_Find_Value_For_Register_B()
        {
            new Computer().CalculateRegistryValue(0).Should().Be(184);
        }

        [Test]
        public void IncrementInstruction_Should_Increment_Register_By_One()
        {
            AssertCorrectValueCalculated(new IncrementInstruction(_indexOfA), _indexOfA, 1);
        }

        [Test]
        public void HalfInstruction_Should_Halve_Registry_Value()
        {
            _registers[_indexOfB] = 6;
            AssertCorrectValueCalculated(new HalfInstruction(_indexOfB), _indexOfB, 3);
        }

        [Test]
        public void TripleInstruction_Should_Triple_Registry_Value()
        {
            _registers[_indexOfA] = 5;
            AssertCorrectValueCalculated(new TripleInstruction(_indexOfA), _indexOfA, 15);
        }

        [Test]
        public void UnconditionalRelativeJumpInstruction_Should_Return_Registry_Value()
        {
            _registers[_indexOfA] = 2;
            AssertCorrectValueCalculated(new UnconditionalRelativeJumpInstruction(_indexOfA), _indexOfA, 2);
        }

        [Test]
        public void RelativeJumpIfOne_Should_Add_JumpOffset_To_Next_Instruction_If_Registry_Value_Is_1()
        {
            _registers[_indexOfB] = 1;
            const int jumpOffset = 3;
            var instruction = new RelativeJumpIfOneInstruction(_indexOfB, jumpOffset);
            AssertCorrectRelativeValue(instruction, _indexOfB, jumpOffset);
        }

        [Test]
        public void RelativeJumpIfOne_Should_Not_Add_JumpOffset_To_Next_Instruction_If_Value_Is_Not_One()
        {
            _registers[_indexOfB] = 2;
            const int jumpOffset = 3;
            var instruction = new RelativeJumpIfOneInstruction(_indexOfB, jumpOffset);
            AssertCorrectRelativeValue(instruction, _indexOfB, 1);
        }

        [Test]
        public void RelativeJumpIfEven_Should_Add_JumpOffset_To_Next_Instruction_If_Value_Is_Even()
        {
            _registers[_indexOfB] = 4;
            const uint jumpOffset = 3;
            var instruction = new RelativeJumpIfEvenInstruction(_indexOfB, (int)jumpOffset);
            AssertCorrectRelativeValue(instruction, _indexOfB, (int)jumpOffset);
        }

        [Test]
        public void RelativeJumpIfEven_Should_Not_Add_JumpOffset_To_Next_Instruction_If_Value_Is_Odd()
        {
            _registers[_indexOfB] = 3;
            const int jumpOffset = 3;
            var instruction = new RelativeJumpIfEvenInstruction(_indexOfB, jumpOffset);
            AssertCorrectRelativeValue(instruction, _indexOfB, 1);
        }

        private void AssertCorrectValueCalculated(IInstruction instruction, int registryIndex, uint expectedValue)
        {
            _registers[instruction.Destination()] = instruction.Calculate(_registers);
            _registers[registryIndex].Should().Be(expectedValue);
        }

        private void AssertCorrectRelativeValue(IInstruction instruction, int registryIndex, int jumpOffset)
        {
            instruction.Calculate(_registers);
            instruction.NextInstruction(0).Should().Be(jumpOffset);
        }
    }
}
