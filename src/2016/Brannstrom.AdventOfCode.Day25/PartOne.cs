using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day25
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void OutInstruction_Should_Transmit_Value()
        {
            new OutInstruction()
                .Execute(new List<Register>(), "out 1")
                .Should()
                .Be(1);
        }

        [Test]
        public void OutInstruction_Should_Transmit_Register_Value()
        {
            new OutInstruction()
                .Execute(new List<Register>() { new Register("a", 2)}, "out a")
                .Should()
                .Be(2);
        }

        [Test]
        public void Should_Generate_Signal()
        {
            var instructionExecutors = new List<IExecuteInstruction>()
            {
                new CopyInstruction(),
                new DecreaseInstruction(),
                new IncreaseInstruction(),
                new JumpInstruction(),
                new OutInstruction()
            };

            var instructions = new InputReader().ReadFile().ToList();

            var signalIsAlternatingPatternOfZeroAndOne = false;
            for (var i = 0; !signalIsAlternatingPatternOfZeroAndOne; i++)
            {
                var signal = new SignalComputer(instructionExecutors, instructions)
                                    .ExecuteInstructions("a", i);

                var evenSignalValuesAreZero = signal.Where((x, a) => a % 2 == 0).All(y => y == 0);
                var unevenSignalValuesAreOne = signal.Where((x, a) => a % 2 != 0).All(y => y == 1);
                signalIsAlternatingPatternOfZeroAndOne = evenSignalValuesAreZero && unevenSignalValuesAreOne;

                if (signalIsAlternatingPatternOfZeroAndOne)
                    i.Should().Be(196);
            }
        }
    }
}
