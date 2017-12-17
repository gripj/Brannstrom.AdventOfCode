using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day16.DanceMoves;

namespace Brannstrom.AdventOfCode.Day16
{
    public class Dance
    {
        public string Programs { get; private set; }

        private readonly IEnumerable<IDanceMove> _moves;
        private readonly IEnumerable<string> _instructions;
        private readonly int _amountOfRepitions;

        public Dance(string programs, IEnumerable<string> instructions, int amountOfRepititions = 1)
        {
            Programs = programs;
            _moves = new List<IDanceMove>()
            {
                new SpinMove(),
                new ExchangeMove(),
                new SwapMove()
            };
            _instructions = instructions;
            _amountOfRepitions = amountOfRepititions;
            Perform();
        }

        private void Perform()
        {
            var cycleSize = CalculateCycleSize();

            for (var i = 0; i < _amountOfRepitions % cycleSize; i++)
                PerformDanceInstructions();
        }

        private int CalculateCycleSize()
        {
            var startingLineup = Programs;
            for (var i = 0; ; i++)
            {
                PerformDanceInstructions();

                if (startingLineup == Programs)
                    return i + 1;
            }
        }

        private void PerformDanceInstructions()
        {
            foreach (var instruction in _instructions)
                Programs = _moves.Single(x => x.CanHandleInstruction(instruction)).Move(instruction, Programs);
        }
    }
}
