using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;

namespace Brannstrom.AdventOfCode.Day6
{
  public static class CoordinateCalculator
  {
    public static int FindLargestArea(IEnumerable<string> input)
    {
      var coords = input.ToCoordinates();
      var minX = coords.Min(c => c.x);
      var maxX = coords.Max(c => c.x);
      var minY = coords.Min(c => c.y);
      var maxY = coords.Max(c => c.y);

      var edgePoints = new HashSet<int>();
      var grid = new Dictionary<(int, int), Neighbour>();

      for (var x = minX; x <= maxX; x++)
        for (var y = minY; y <= maxY; y++)
        {
          var neighbour = FindNearestNeighbour(x, y, coords);
          grid[(x, y)] = neighbour;

          if (x == minX || x == maxX || y == minY || y == maxY)
            edgePoints.Add(neighbour.Point);
        }

      return grid.Values
        .Where(n => n.Point != -1)
        .Where(n => !edgePoints.Contains(n.Point))
        .CountBy(x => x.Point)
        .Max(g => g.Value);
    }

    public static int FindLargestRegion(IEnumerable<string> input, int maxDistance)
    {
      var coords = input.ToCoordinates();
      var minX = coords.Min(c => c.x);
      var maxX = coords.Max(c => c.x);
      var minY = coords.Min(c => c.y);
      var maxY = coords.Max(c => c.y);

      var grid = new Dictionary<(int, int), int>();

      for (var x = minX; x <= maxX; x++)
        for (var y = minY; y <= maxY; y++)
          grid[(x, y)] = FindDistanceToAll(x, y, coords);

      return grid.Values.Count(n => n < maxDistance);
    }

    private static Neighbour FindNearestNeighbour(int x, int y, IEnumerable<(int x, int y)> coords)
    {
      var nearest = coords.Select((coord, n) => new Neighbour()
        {
          Point = n,
          Distance = Math.Abs(x - coord.x) + Math.Abs(y - coord.y)
        })
        .MinBy(n => n.Distance)
        .ToArray();

      if (nearest.Length == 1) return nearest[0];
      return new Neighbour() { Point = -1, Distance = nearest[0].Distance };
    }

    private static (int x, int y)[] ToCoordinates(this IEnumerable<string> input)
    {
      return input.Select(x => x.Split(',')).Select(c => (x: int.Parse(c[0]), y: int.Parse(c[1]))).ToArray();
    }

    private static int FindDistanceToAll(int x, int y, IEnumerable<(int x, int y)> coords)
    {
      return coords.Sum(coord => Math.Abs(x - coord.x) + Math.Abs(y - coord.y));
    }

    private struct Neighbour
    {
      public int Point { get; set; }
      public int Distance { get; set; }
    }
  }
}
