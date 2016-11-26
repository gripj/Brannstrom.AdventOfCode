using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartOne
    {
        private Reader _reader;

        [SetUp]
        public void SetUp()
        {
            _reader = new Reader();
        }

        [Test]
        public void Should_Get_Amount_Of_Distinct_Molecules_Based_On_Input()
        {
            var instructions = _reader.GetInstructions();
            var machine = new MoleculeMachine(instructions);
            var molecule = _reader.GetMolecule();
            machine.GetAmountOfDistinctModules(molecule).Should().Be(535);
        }

        [Test]
        [TestCase("HOH", 4)]
        [TestCase("HOHOHO", 7)]
        public void Should_Get_Amount_Of_Distinct_Molecules(string input, int distinctResults)
        {
            var instructions = new List<ReplacementInstruction>()
            {
                new ReplacementInstruction("H", "HO"),
                new ReplacementInstruction("H", "OH"),
                new ReplacementInstruction("O", "HH")
            };
            var machine = new MoleculeMachine(instructions);
            machine.GetAmountOfDistinctModules(input).Should().Be(distinctResults);
        }

        [Test]
        public void Reader_Should_Create_Instruction_From_Input()
        {
            var instruction = _reader.MakeInstruction("Al => ThF");
            instruction.From.Should().Be("Al");
            instruction.To.Should().Be("ThF");
        }

        [Test]
        public void Reader_Should_Provide_Instructions()
        {
            _reader.GetInstructions().Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Reader_Should_Provide_Molecule()
        {
            _reader.GetMolecule()
                .Should()
                .Be(_reader.ReadFile().Last());
        }
    }
}
