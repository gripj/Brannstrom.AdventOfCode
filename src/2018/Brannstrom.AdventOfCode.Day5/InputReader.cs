using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day5
{
  public static class InputReader
  {
    public static string Read()
    {
      return ReadLines().First();
    }

    private static IEnumerable<string> ReadLines()
    {
      using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day5.input.txt"))
      using (var reader = new StreamReader(stream))
        while (reader.Peek() >= 0)
          yield return reader.ReadLine();
    }
  }
}
