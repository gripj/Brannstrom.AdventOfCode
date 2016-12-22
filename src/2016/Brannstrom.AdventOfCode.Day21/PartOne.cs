using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day21.Operations;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void SwapPositionXWithYOperation_Should_Swap_Positions()
        {
            new SwapPositionXWithYOperation()
                .Scramble("abcde", "swap position 4 with position 0")
                .Should()
                .Be("ebcda");
        }

        [Test]
        public void SwapLetterXWithYOperation_Should_Swap_Letters()
        {
            new SwapLetterXWithYOperation()
                .Scramble("ebcda", "swap letter d with letter b")
                .Should()
                .Be("edcba");
        }

        [Test]
        [TestCase("abcde", "rotate left 1 step", "bcdea")]
        [TestCase("abcde", "rotate left 3 steps", "deabc")]
        public void RotateNumberOfStepsOperation_Should_Rotate_Left(string password, string operation, string result)
        {
            new RotateNumberOfStepsOperation()
                .Scramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        [TestCase("abcd", "rotate right 1 step", "dabc")]
        [TestCase("abcd", "rotate right 2 steps", "cdab")]
        public void RotateNumberOfStepsOperation_Should_Rotate_Right(string password, string operation, string result)
        {
            new RotateNumberOfStepsOperation()
                .Scramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        public void RotateBasedOnPositionOperation_Should_Rotate_On_Position()
        {
            new RotateOnPositionOperation()
                .Scramble("abdec", "rotate based on position of letter b")
                .Should()
                .Be("ecabd");
        }

        [Test]
        public void RotateBasedOnPositionOperation_Should_Rotate_Additional_Time_If_Index_Is_At_Least_4()
        {
            new RotateOnPositionOperation()
                .Scramble("ecabd", "rotate based on position of letter d")
                .Should()
                .Be("decab");
        }

        [Test]
        [TestCase("edcba", "reverse positions 0 through 4", "abcde")]
        [TestCase("edcba", "reverse positions 1 through 3", "ebcda")]
        public void ReversePositionsXThroughYOperation_Should_Reverse_String_On_Given_Positions(
            string password, string operation, string result)
        {
            new ReversePositionsXThroughYOperation()
                .Scramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        public void MovePositionXToYOperation_Should_Move_Letter_At_Position_X_To_Position_Y()
        {
            new MovePositionXToYOperation()
                .Scramble("bcdea", "move position 1 to position 4")
                .Should()
                .Be("bdeac");
        }

        [Test]
        public void Should_Scramble_Password_In_Example()
        {
            var instructions = new List<string>()
            {
                "swap position 4 with position 0",
                "swap letter d with letter b",
                "reverse positions 0 through 4",
                "rotate left 1 step",
                "move position 1 to position 4",
                "move position 3 to position 0",
                "rotate based on position of letter b",
                "rotate based on position of letter d"
            };

            var scrambleOperations = new List<IScrambleOperation>()
            {
                new MovePositionXToYOperation(),
                new ReversePositionsXThroughYOperation(),
                new RotateNumberOfStepsOperation(),
                new RotateOnPositionOperation(),
                new SwapLetterXWithYOperation(),
                new SwapPositionXWithYOperation()
            };

            new PasswordScrambler(scrambleOperations)
                .ScramblePassword("abcde", instructions)
                .Should()
                .Be("decab");
        }

        [Test]
        public void Should_Scramble_Password()
        {
            var instructions = new InputReader().ReadFile();

            var scrambleOperations = new List<IScrambleOperation>()
            {
                new MovePositionXToYOperation(),
                new ReversePositionsXThroughYOperation(),
                new RotateNumberOfStepsOperation(),
                new RotateOnPositionOperation(),
                new SwapLetterXWithYOperation(),
                new SwapPositionXWithYOperation()
            };

            new PasswordScrambler(scrambleOperations)
                .ScramblePassword("abcdefgh", instructions)
                .Should()
                .Be("agcebfdh");
        }
    }
}
