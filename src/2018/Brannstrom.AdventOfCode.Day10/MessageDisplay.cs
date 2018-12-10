using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day10
{
  public class MessageDisplay
  {
    public MessageDisplay(IEnumerable<string> inputPoints)
    {  
      var points = inputPoints.Select(Point.Parse).ToList();
      var second = 0;
      var dimensions = (x: 100, y: 50);

      while (true)
      {
        points = points.Select(v => v.Next()).ToList();

        var maxX = points.Max(p => p.X);
        var minX = points.Min(p => p.X);
        var width = Math.Abs(maxX - minX);
        var maxY = points.Max(p => p.Y);
        var minY = points.Min(p => p.Y);
        var height = Math.Abs(maxY - minY);
        second++;

        if (width < dimensions.x && height < dimensions.y)
        {
          Console.WriteLine($"Second {second}");
          for (var y = minY; y <= maxY; y++)
          {
            for (var x = minX; x <= maxX; x++)
              Console.Write(points.Any(p => p.Y == y && p.X == x) ? "#" : ".");

            Console.WriteLine();
          }

          var key = Console.ReadKey();
          if (key.Key == ConsoleKey.Enter)
            break;
        }

        if (second % 1000 == 0)
          Console.WriteLine($"Second {second}");
      }
    }
  }
}
