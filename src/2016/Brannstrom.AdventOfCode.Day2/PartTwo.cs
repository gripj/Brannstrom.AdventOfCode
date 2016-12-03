using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day2.InputCalculators;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartTwo
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
            _keyPad.UseAdvancedKeyLayout();
        }

        [Test]
        public void Up_Input_Should_Stop_At_Edge()
        {
            new UpInput().CalculateNextKey(_keyPad.GetLayout(), "2").Should().Be("2");
        }

        [Test]
        public void Down_Input_Should_Stop_At_Edge()
        {
            new DownInput().CalculateNextKey(_keyPad.GetLayout(), "5").Should().Be("5");
        }

        [Test]
        public void Left_Input_Should_Stop_At_Edge()
        {
            new LeftInput().CalculateNextKey(_keyPad.GetLayout(), "A").Should().Be("A");
        }

        [Test]
        public void Right_Input_Should_Stop_At_Edge()
        {
            new RightInput().CalculateNextKey(_keyPad.GetLayout(), "D").Should().Be("D");
        }

        [Test]
        public void Should_Calculate_Example_Code()
        {
            var listOfInstructions = new List<string>()
            {
                "ULL",
                "RRDDD",
                "LURDL",
                "UUUUD"
            };

            _keyPad.GetCodeFromInstructions(listOfInstructions).Should().Be("5DB3");
        }

        [Test]
        public void Should_Calculate_Key_Code()
        {
            _keyPad.GetCodeFromInstructions(new InputReader().ReadFile()).Should().Be("A47DA");
        }
    }
}
