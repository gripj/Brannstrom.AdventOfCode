using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Position()
        {
            var instructions = File.ReadAllText("input.txt");
            FindPositionWhereBasementIsEntered(instructions).Should().Be(1797);
        }

        [Test]
        [TestCase(")", 1)]
        [TestCase("()())", 5)]
        public void Should_Find_Position_Where_Basement_Is_Entered(string instructions, int expectedPosition)
        {
            FindPositionWhereBasementIsEntered(instructions).Should().Be(expectedPosition);
        }

        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void Should_Throw_Exception_If_Santa_Does_Not_Enter_Basement()
        {
            FindPositionWhereBasementIsEntered("(");
        }

        private static int FindPositionWhereBasementIsEntered(string instructions)
        {
            var position = 1;
            var currentFloor = 0;
            foreach (var instruction in instructions.ToCharArray())
            {
                currentFloor = instruction.Equals(')') ? currentFloor - 1 : currentFloor + 1;

                if (currentFloor == -1)
                    return position;
                position++;
            }
            throw new AssertionException("Santa never entered the basement.");
        }
    }
}
