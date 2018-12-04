using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day3
{
  public static class ClaimEvaluation
  {
    public static IEnumerable<KeyValuePair<string, List<int>>> GetOverlappingFabricSquares(this IEnumerable<Claim> claims)
    {
      var fabricSquares = new Dictionary<string, List<int>>();

      foreach (var claim in claims)
      {
        foreach (var (x, y) in claim.FabricSquares)
        {
          var key = x + "," + y;

          if (!fabricSquares.ContainsKey(key))
            fabricSquares.Add(key, new List<int>() { claim.Id });
          else
            fabricSquares[key].Add(claim.Id);
        }
      }

      return fabricSquares.Where(x => x.Value.Count > 1);
    }
  }
}
