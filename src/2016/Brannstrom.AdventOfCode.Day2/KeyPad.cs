using System;
using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day2.InputCalculators;

namespace Brannstrom.AdventOfCode.Day2
{
    public class KeyPad
    {
        private readonly IEnumerable<ICalculateInput> _inputCalculators;

        private string[,] _keys;
        private string _currentKey;

        public KeyPad(IEnumerable<ICalculateInput> inputCalculators)
        {
            _inputCalculators = inputCalculators;
            _currentKey = "5";
            UseStandardKeyLayout();
        }

        public void UseStandardKeyLayout()
        {
            string[,] keys =  {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

            _keys = keys;
        }

        public void UseAdvancedKeyLayout()
        {
            string[,] keys =  {
                { "", "", "1", "", "" },
                { "", "2", "3", "4", "" },
                { "5", "6", "7", "8", "9" },
                { "", "A", "B", "C", "" },
                { "", "", "D", "", "" }
            };

            _keys = keys;
        }

        public string[,] GetLayout() => _keys;

        public void SetStartingKey(string startingKey)
        {
            _currentKey = startingKey;
        }

        public string GetNextKeyFromInstructions(string instructions)
        {
            foreach (var instruction in instructions.ToCharArray())
                _currentKey = _inputCalculators.First(x => x.CanHandle(instruction)).CalculateNextKey(_keys, _currentKey);

            return _currentKey;
        }

        public string GetCodeFromInstructions(IEnumerable<string> listOfInstructions)
        {
            return listOfInstructions.Aggregate("", (current, instruction) => current + GetNextKeyFromInstructions(instruction));
        }
    }
}
