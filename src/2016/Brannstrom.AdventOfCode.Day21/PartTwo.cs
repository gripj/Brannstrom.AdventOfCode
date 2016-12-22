using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day21.Operations;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void SwapPositionXWithYOperation_Should_Unscramble()
        {
            new SwapPositionXWithYOperation()
                .Unscramble("ebcda", "swap position 4 with position 0")
                .Should()
                .Be("abcde");
        }

        [Test]
        public void SwapLetterXWithYOperation_Should_Unscramble()
        {
            new SwapLetterXWithYOperation()
                .Unscramble("edcba", "swap letter d with letter b")
                .Should()
                .Be("ebcda");
        }

        [Test]
        [TestCase("bcdea", "rotate left 1 step", "abcde")]
        [TestCase("deabc", "rotate left 3 steps", "abcde")]
        public void RotateNumberOfStepsOperation_Should_Unscramble_Left(string password, string operation, string result)
        {
            new RotateNumberOfStepsOperation()
                .Unscramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        [TestCase("dabc", "rotate right 1 step", "abcd")]
        [TestCase("cdab", "rotate right 2 steps", "abcd")]
        public void RotateNumberOfStepsOperation_Should_Unscramble_Right(string password, string operation, string result)
        {
            new RotateNumberOfStepsOperation()
                .Unscramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        public void RotateBasedOnPositionOperation_Should_Unscramble()
        {
            new RotateOnPositionOperation()
                .Unscramble("ecabd", "rotate based on position of letter b")
                .Should()
                .Be("abdec");
        }

        [Test]
        [TestCase("abcde", "reverse positions 0 through 4", "edcba")]
        [TestCase("ebcda", "reverse positions 1 through 3", "edcba")]
        public void ReversePositionsXThroughYOperation_Should_Unscramble(
            string password, string operation, string result)
        {
            new ReversePositionsXThroughYOperation()
                .Unscramble(password, operation)
                .Should()
                .Be(result);
        }

        [Test]
        public void MovePositionXToYOperation_Should_Unscramble()
        {
            new MovePositionXToYOperation()
                .Unscramble("bdeac", "move position 1 to position 4")
                .Should()
                .Be("bcdea");
        }

        [Test]
        public void Should_Unscramble_Password_In_Example()
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
                .UnscramblePassword("decab", instructions)
                .Should()
                .Be("abcde");
        }

        [Test]
        public void Should_Unscramble_Password()
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
                .UnscramblePassword("fbgdceah", instructions)
                .Should()
                .Be("afhdbegc");
        }
    }
}
