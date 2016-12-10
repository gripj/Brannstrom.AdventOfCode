using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day8.Instructions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Pixels_Should_Be_Off_By_Default()
        {
            new Pixel().IsOn.Should().BeFalse();
        }

        [Test]
        public void Should_Be_Able_To_Toggle_Pixel_On()
        {
            var pixel = new Pixel();
            pixel.TurnOn();
            pixel.IsOn.Should().BeTrue();
        }

        [Test]
        public void Should_Be_Able_To_Toggle_Pixel_Off()
        {
            var pixel = new Pixel();
            pixel.TurnOn();
            pixel.TurnOff();
            pixel.IsOn.Should().BeFalse();
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void TurnOnTopLeftPixelsInstruction_Should_Turn_On_Top_Left_Pixels(int x, int y)
        {
            var screen = new Screen(new List<IInstruction>() { new TurnOnTopLeftPixelsInstruction()});

            screen.ExecuteInstruction("rect 3x2");

            screen.SpecifiedPixelIsOn(x, y).Should().BeTrue();
            screen.GetAmountOfLitPixels().Should().Be(6);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        public void Rotate_Column_Should_Rotate_Column(int x, int y)
        {
            var screen = new Screen(new List<IInstruction>()
            {
                new TurnOnTopLeftPixelsInstruction(),
                new RotateColumnInstruction()
            });

            screen.ExecuteInstruction("rect 3x2");
            screen.ExecuteInstruction("rotate column x=1 by 1");

            screen.SpecifiedPixelIsOn(x, y).Should().BeTrue();
            screen.GetAmountOfLitPixels().Should().Be(6);
        }

        [Test]
        [TestCase(4, 0)]
        [TestCase(6, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        public void RotateRowInstruction_Should_Rotate_Row(int x, int y)
        {
            var screen = new Screen(new List<IInstruction>()
            {
                new TurnOnTopLeftPixelsInstruction(),
                new RotateColumnInstruction(),
                new RotateRowInstruction()
            });

            screen.ExecuteInstruction("rect 3x2");
            screen.ExecuteInstruction("rotate column x=1 by 1");
            screen.ExecuteInstruction("rotate row y=0 by 4");

            screen.SpecifiedPixelIsOn(x, y).Should().BeTrue();
            screen.GetAmountOfLitPixels().Should().Be(6);
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(4, 0)]
        [TestCase(6, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        public void Example_Instructions_Should_Get_Expected_Result(int x, int y)
        {
            var instructionExecutors = new List<IInstruction>()
            {
                new TurnOnTopLeftPixelsInstruction(),
                new RotateRowInstruction(),
                new RotateColumnInstruction()
            };

            var screen = new Screen(instructionExecutors);
            screen.UseSmallPixelLayout();

            var instructions = new List<string>()
            {
                "rect 3x2",
                "rotate column x=1 by 1",
                "rotate row y=0 by 4",
                "rotate column x=1 by 1"
            };

            foreach (var instruction in instructions)
                screen.ExecuteInstruction(instruction);

            screen.SpecifiedPixelIsOn(x, y).Should().BeTrue();
            screen.GetAmountOfLitPixels().Should().Be(6);
        }

        [Test]
        public void Should_Calculate_Number_Of_Lit_Pixels()
        {
            var instructionExecutors = new List<IInstruction>()
            {
                new TurnOnTopLeftPixelsInstruction(),
                new RotateRowInstruction(),
                new RotateColumnInstruction()
            };

            var screen = new Screen(instructionExecutors);

            var instructions = new InputReader().ReadFile();

            foreach (var instruction in instructions)
                screen.ExecuteInstruction(instruction);

            screen.GetAmountOfLitPixels().Should().Be(110);
        }
    }
}
