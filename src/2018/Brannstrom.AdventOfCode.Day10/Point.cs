using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day10
{
  public class Point
  {
    public int X { get; }
    public int Y { get; }
    public (int X, int Y) V { get; }

    public Point((int x, int y) point, (int x, int y) velocity)
    {
      X = point.x;
      Y = point.y;
      V = velocity;
    }

    public static Point Parse(string input)
    {
      var parts = Regex.Replace(input, @"\s+", "").Split('<');
      var coordinateParts = parts[1].Split(',');
      var velocityParts = parts[2].Split(',');
      var pX = int.Parse(coordinateParts[0]);
      var pY = int.Parse(coordinateParts[1].Split('>')[0]);
      var vX = int.Parse(velocityParts[0]);
      var vY = int.Parse(velocityParts[1].TrimEnd('>'));

      return new Point((pX, pY), (vX, vY));
    }

    public Point Next() => new Point((X + V.X, Y + V.Y), V);
  }
}
