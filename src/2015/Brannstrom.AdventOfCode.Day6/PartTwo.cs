using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartTwo
    {
        private HouseOwner _houseOwner;

        [SetUp]
        public void SetUp()
        {
            _houseOwner = new HouseOwner();
            _houseOwner.LearnAncientElvish();
        }

        [Test]
        public void Calculate_Total_Brightness()
        {
            foreach (var instruction in _houseOwner.ReadSantasInstructions())
            {
                _houseOwner.SetupLights(instruction);
            }
            _houseOwner.House.TotalBrighness().Should().Be(14110788);
        }

        [Test]
        public void TurnOff_Instruction_Should_Decrease_Brightness()
        {
            var toggleInstruction = new Instruction("toggle 0,0 through 999,999");
            var turnOffInstruction = new Instruction("turn off 0,0 through 999,999");
            _houseOwner.SetupLights(toggleInstruction);
            _houseOwner.SetupLights(turnOffInstruction);
            _houseOwner.House.TotalBrighness().Should().Be(1000000);
        }

        [Test]
        public void TurnOff_Instruction_Should_Not_Decrease_Brightness_Beyond_Zero()
        {
            var turnOffInstruction = new Instruction("turn off 499,499 through 500,500");
            _houseOwner.SetupLights(turnOffInstruction);
            _houseOwner.SetupLights(turnOffInstruction);
            _houseOwner.House.TotalBrighness().Should().Be(0);
        }

        [Test]
        public void TurnOn_Instruction_Should_Increase_Brightness()
        {
            var turnOnInstruction = new Instruction("turn on 499,499 through 500,500");
            _houseOwner.SetupLights(turnOnInstruction);
            _houseOwner.SetupLights(turnOnInstruction);
            _houseOwner.House.TotalBrighness().Should().Be(8);
        }

        [Test]
        public void Toggle_Instruction_Should_Increase_Brightness_By_Two()
        {
            var toggleInstruction = new Instruction("toggle 499,499 through 500,500");
            _houseOwner.SetupLights(toggleInstruction);
            _houseOwner.SetupLights(toggleInstruction);
            _houseOwner.House.TotalBrighness().Should().Be(16);
        }

        [Test]
        [TestCase("turn on 0,0 through 0,0", 1)]
        [TestCase("toggle 0,0 through 999,999", 2000000)]
        public void Should_Calculate_Total_Brightness(string instructions, int expectedBrightness)
        {
            _houseOwner.SetupLights(new Instruction(instructions));
            _houseOwner.House.TotalBrighness().Should().Be(expectedBrightness);
        }
    }
}
