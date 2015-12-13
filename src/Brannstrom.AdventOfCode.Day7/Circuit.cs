using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day7
{
    public class Circuit
    {
        private Dictionary<string, ushort> _signals;
        private IEnumerable<Gate.Gate> _gates;
         
        public Dictionary<string, ushort> GetSignalsForInstructions(IEnumerable<string> instructions)
        {
            _gates = instructions.ToArray().Select(Gate.Gate.Parse).ToList();
            _signals = new Dictionary<string, ushort>();

            FindSignals();

            return _signals;
        }

        public ushort GetSignalForWireA()
        {
            return GetSignalsForInstructions(ReadInstructionsFromFile())["a"];
        }

        public ushort OverrideAndGetNewValueForWireA()
        {
            var instructions = ReadInstructionsFromFile();
            _signals = GetSignalsForInstructions(ReadInstructionsFromFile());
            _gates = instructions.ToArray().Select(Gate.Gate.Parse).ToList();
            var a = _signals["a"];

            _signals = new Dictionary<string, ushort>();
            _signals["b"] = a;

            FindSignals();

            return _signals["a"];
        }

        private void FindSignals()
        {
            var wasFound = true;
            while (wasFound)
            {
                wasFound = false;

                foreach (var g in _gates.Where(g => !_signals.ContainsKey(g.Output)))
                {
                    if (g.HasValue(_signals))
                        _signals.Add(g.Output, g.Value(_signals));
                    else
                        wasFound = true;
                }
            }
        }

        private IEnumerable<string> ReadInstructionsFromFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day7.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
