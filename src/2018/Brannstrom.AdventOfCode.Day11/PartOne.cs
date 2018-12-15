using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    [TestCase(3, 5, 8, 4)]
    [TestCase(122, 79, 57, -5)]
    [TestCase(217, 196, 39, 0)]
    [TestCase(101, 153, 71, 4)]
    public void FuelCell_Should_Calculate_Power_Level(int x, int y, int serialNumber, int powerLevel)
    {
      FuelCell.CalculatePowerLevel(x, y, serialNumber).Should().Be(powerLevel);
    }

    [Test]
    [TestCase(18, "33,45")]
    [TestCase(42, "21,61")]
    public void Should_Get_Top_Left_Fuel_Cell_Of_Square_With_Largest_Power_In_Examples(int serialNumber, string expectedCoordinates)
    {
      var coordinates = PowerGrid.FindTopLeftFuelCellInSquareWithLargestTotalPower(serialNumber);
      coordinates.Should().Be(expectedCoordinates);
    }

    [Test]
    public void Should_Get_Top_Left_Fuel_Cell_Of_Square_With_Largest_Power()
    {
      var coordinates = PowerGrid.FindTopLeftFuelCellInSquareWithLargestTotalPower(7139);
      coordinates.Should().Be("20,62");
    }
  }
}
