using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day3
{
  public class Claim
  {
    public int Id { get; }
    public List<(int x, int y)> FabricSquares { get;  } = new List<(int x, int y)>();

    public Claim(int clamId, (int x, int y)startsAt, int width, int height)
    {
      Id = clamId;

      for (var x = startsAt.x; x < startsAt.x + width; x++)
        for (var y = startsAt.y; y < startsAt.y + height; y++)
          FabricSquares.Add((x, y));
    }

    public static Claim Parse(string fromInput)
    {
      var inputParts = fromInput.Substring(1).Split(' ');

      var coordinates = inputParts[2].Split(',', ':');
      var x = int.Parse(coordinates[0]);
      var y = int.Parse(coordinates[1]);

      var dimensions = inputParts[3].Split('x');
      var width = int.Parse(dimensions[0]);
      var height = int.Parse(dimensions[1]);

      return new Claim(int.Parse(inputParts[0]), (x + 1, y + 1), width, height);
    }
  }
}
