using System;
using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day2.InputCalculators;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        private KeyPad _keyPad;

        [SetUp]
        public void SetUp()
        {
            var inputCalculators = new List<ICalculateInput>()
            {
                new UpInput(),
                new DownInput(),
                new LeftInput(),
                new RightInput()
            };
            _keyPad = new KeyPad(inputCalculators);
        }

        [Test]
        [TestCase("5", "2")]
        [TestCase("2", "2")]
        public void Up_Input_Should_Get_Next_Position(string currentKey, string expectedFollowingKey)
        {
            new UpInput().CalculateNextKey(_keyPad.GetLayout(), currentKey).Should().Be(expectedFollowingKey);
        }

        [Test]
        [TestCase("5", "8")]
        [TestCase("8", "8")]
        public void Down_Input_Should_Get_Next_Position(string currentKey, string expectedFollowingKey)
        {
            new DownInput().CalculateNextKey(_keyPad.GetLayout(), currentKey).Should().Be(expectedFollowingKey);
        }

        [Test]
        [TestCase("5", "4")]
        [TestCase("4", "4")]
        public void Left_Input_Should_Get_Next_Position(string currentKey, string expectedFollowingKey)
        {
            new LeftInput().CalculateNextKey(_keyPad.GetLayout(), currentKey).Should().Be(expectedFollowingKey);
        }

        [Test]
        [TestCase("5", "6")]
        [TestCase("6", "6")]
        public void Right_Input_Should_Get_Next_Position(string currentKey, string expectedFollowingKey)
        {
            new RightInput().CalculateNextKey(_keyPad.GetLayout(), currentKey).Should().Be(expectedFollowingKey);
        }

        [Test]
        [TestCase("5", "ULL", "1")]
        [TestCase("1", "RRDDD", "9")]
        [TestCase("9", "LURDL", "8")]
        [TestCase("8", "UUUUD", "5")]
        public void Should_Get_Expected_Key_From_Instructions(string startingKey, string instructions, string expected)
        {
            _keyPad.SetStartingKey(startingKey);
            _keyPad.GetNextKeyFromInstructions(instructions).Should().Be(expected);
        }

        [Test]
        public void Should_Get_Expected_Key_Code_From_List_Of_Instructions()
        {
            var listOfInstructions = new List<string>()
            {
                "ULL",
                "RRDDD",
                "LURDL",
                "UUUUD"
            };

            _keyPad.GetCodeFromInstructions(listOfInstructions).Should().Be("1985");
        }

        [Test]
        public void InputReader_Should_Read_Input()
        {
            new InputReader().ReadFile().Count().Should().Be(5);
        }

        [Test]
        public void Should_Calculate_Key_Code()
        {
            _keyPad.GetCodeFromInstructions(new InputReader().ReadFile()).Should().Be("73597");
        }
    }
}
