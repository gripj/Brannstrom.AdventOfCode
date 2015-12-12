using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartOne
    {
        private HouseOwner _houseOwner;

        [SetUp]
        public void SetUp()
        {
            _houseOwner = new HouseOwner();;
        }

        [Test]
        public void Calculate_Number_Of_Lights_Turned_On()
        {
            foreach (var instruction in _houseOwner.ReadSantasInstructions())
            {
                _houseOwner.SetupLights(instruction);
            }
            _houseOwner.House.NumberOfLightsOn().Should().Be(377891);
        }

        [Test]
        public void Should_Turn_Lights_On()
        {
            var instruction = new Instruction() { Type = InstructionType.On, FromX = 499, ToX = 500, FromY = 499, ToY = 500 };
            _houseOwner.SetupLights(instruction);
            _houseOwner.House.NumberOfLightsOn().Should().Be(4);
        }

        [Test]
        public void Should_Turn_Lights_Off()
        {
            var turnOnInstruction = new Instruction() { Type = InstructionType.On, FromX = 497, ToX = 500, FromY = 497, ToY = 500 };
            var turnOffInstruction = new Instruction() { Type = InstructionType.Off, FromX = 499, ToX = 500, FromY = 499, ToY = 500 };
            _houseOwner.SetupLights(turnOnInstruction);
            _houseOwner.SetupLights(turnOffInstruction);
            _houseOwner.House.NumberOfLightsOn().Should().Be(12);
        }

        [Test]
        public void Should_Toggle_Lights()
        {
            _houseOwner.SetupLights(new Instruction() { Type = InstructionType.Toggle, FromX = 0, ToX = 999, FromY = 0, ToY = 0 });
            _houseOwner.House.NumberOfLightsOn().Should().Be(1000);
        }

        [Test]
        [TestCase("turn on 0,0 through 999,999", 1000000)]
        [TestCase("toggle 0,0 through 999,0", 1000)]
        [TestCase("turn off 499,499 through 500,500", 0)]
        public void Should_Setup_Lights(string instructions, int expectedNumberOfLightsTurnedOn)
        {
            _houseOwner.SetupLights(new Instruction(instructions));
            _houseOwner.House.NumberOfLightsOn().Should().Be(expectedNumberOfLightsTurnedOn);
        }
    }
}
