using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
  public static class RailTrack
  {
    public static string FindLocationOfFirstCrash(IEnumerable<string> input)
    {
      var (mat, carts) = Parse(input);
      while (true)
      {
        var newState = Step(mat, carts);
        if (newState.crashed.Any())
          return newState.crashed[0].ToPosition();
      }
    }

    public static string FindLocationOfLastCart(IEnumerable<string> input)
    {
      var (mat, carts) = Parse(input);
      while (carts.Count > 1)
      {
        var newState = Step(mat, carts);
        carts = newState.carts;
      }
      return carts[0].ToPosition();
    }

    private static (List<Cart> crashed, List<Cart> carts) Step(IReadOnlyList<string> map, List<Cart> carts)
    {
      var crashed = new List<Cart>();

      foreach (var cart in carts.OrderBy(cartT => cartT.Pos))
      {
        cart.Pos = (x: cart.Pos.x + cart.dX, y: cart.Pos.y + cart.dY);

        foreach (var cart2 in carts.ToArray())
        {
          if (cart != cart2 && cart.Pos.x == cart2.Pos.x && cart.Pos.y == cart2.Pos.y)
          {
            crashed.Add(cart);
            crashed.Add(cart2);
          }
        }
        switch (map[cart.Pos.x][cart.Pos.y])
        {
          case '+':
            cart.Turn();
            break;
          case '/':
            if (cart.dY == 1 || cart.dY == -1)
              cart.Rotate(Dir.Left);
            else if (cart.dX == 1 || cart.dX == -1)
              cart.Rotate(Dir.Right);
            break;
          case '\\':
            if (cart.dY == 1 || cart.dY == -1)
              cart.Rotate(Dir.Right);
            else if (cart.dX == -1 || cart.dX == 1)
              cart.Rotate(Dir.Left);
            break;
        }
      }
      return (crashed, carts.Where(cart => !crashed.Contains(cart)).ToList());
    }

    private static (string[] map, List<Cart> carts) Parse(IEnumerable<string> input)
    {
      var map = input.ToArray();
      var carts = new List<Cart>();

      for (var x = 0; x < map.Length; x++)
        for (var y = 0; y < map[0].Length; y++)
          switch (map[x][y])
          {
            case '^':
              carts.Add(new Cart((x: x, y: y), -1, 0));
              break;
            case 'v':
              carts.Add(new Cart((x: x, y: y), 1, 0));
              break;
            case '<':
              carts.Add(new Cart((x: x, y: y), 0, -1));
              break;
            case '>':
              carts.Add(new Cart((x: x, y: y), 0, 1));
              break;
          }

      return (map, carts);
    }

    private static string ToPosition(this Cart cart) => $"{cart.Pos.y},{cart.Pos.x}";
  }
}
