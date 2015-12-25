using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_Fewest_Steps_Needed_To_Make_Molescules_Based_On_Starting_Molecule()
        {
            var reader = new Reader();
            var molecule = new Reader().GetMolecule();
            var machine = new MoleculeMachine(reader.GetInstructions());
            var result = machine.GetStepsNeededToMakeMolecule("e", molecule);
            result.Should().Be(212);
        }

        [Test]
        [TestCase("HOH", 3)]
        [TestCase("HOHOHO", 6)]
        public void Should_Get_Fewest_Steps_Needed_To_Make_Molecule(string input, int expectedAmountOfSteps)
        {
            var instructions = new List<ReplacementInstruction>()
            {
                new ReplacementInstruction("H", "HO"),
                new ReplacementInstruction("H", "OH"),
                new ReplacementInstruction("O", "HH"),
                new ReplacementInstruction("e", "H"),
                new ReplacementInstruction("e", "O")
            };
            var machine = new MoleculeMachine(instructions); 
            machine.GetStepsNeededToMakeMolecule("e", input).Should().Be(expectedAmountOfSteps);
        }
    }
}
