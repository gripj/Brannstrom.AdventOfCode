﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day11
{
    public class InputReader
    {
        public IEnumerable<string> ReadFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day11.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
