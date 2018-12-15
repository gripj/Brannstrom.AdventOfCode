namespace Brannstrom.AdventOfCode.Day11
{
  public static class PowerGrid
  {
    public static string FindTopLeftFuelCellInSquareWithLargestTotalPower(int serialNumber, int size = 3)
    {
      var result = FindIdentifier(serialNumber, size);
      return $"{result.xMax},{result.yMax}";
    }

    public static string FindIdentifierOfSquareWithLargestTotalPower(int serialNumber, int size = 300)
    {
      var result = FindIdentifier(serialNumber, size);
      return $"{result.xMax},{result.yMax},{result.nMax}";
    }

    private static (int xMax, int yMax, int nMax) FindIdentifier(int serialNumber, int size)
    {
      var originalGrid = CreateGrid(serialNumber);

      var maxTotalPower = int.MinValue;
      var yMax = int.MinValue;
      var xMax = int.MinValue;
      var nMax = int.MinValue;

      var grid = new int[300, 300];

      for (var n = 1; n <= size; n++)
      {
        for (var row = 0; row < 300 - n; row++)
          for (var col = 0; col < 300; col++)          
            grid[row, col] += originalGrid[row + n - 1, col];


        for (var row = 0; row < 300 - n; row++)
        {
          for (var col = 0; col < 300 - n; col++)
          {
            var totalPower = 0;

            for (var i = 0; i < n; i++)
              totalPower += grid[row, col + i];

            if (totalPower > maxTotalPower)
            {
              maxTotalPower = totalPower;
              yMax = row + 1;
              xMax = col + 1;
              nMax = n;
            }
          }
        }
      }

      return (xMax, yMax, nMax);
    }

    private static int[,] CreateGrid(int serialNumber)
    {
      var grid = new int[300, 300];

      for (var row = 0; row < 300; row++)
      {
        for (var col = 0; col < 300; col++)
        {
          var x = col + 1;
          var y = row + 1;

          grid[row, col] = FuelCell.CalculatePowerLevel(x, y, serialNumber);
        }
      }

      return grid;
    }
  }
}
