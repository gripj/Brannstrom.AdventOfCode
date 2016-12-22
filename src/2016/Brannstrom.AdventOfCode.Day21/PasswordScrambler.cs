using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day21.Operations;

namespace Brannstrom.AdventOfCode.Day21
{
    public class PasswordScrambler
    {
        private readonly IEnumerable<IScrambleOperation> _scrambleOperations;

        public PasswordScrambler(IEnumerable<IScrambleOperation> scrambleOperations)
        {
            _scrambleOperations = scrambleOperations;
        }

        public string ScramblePassword(string password, IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
                password = _scrambleOperations.First(x => x.CanHandle(instruction)).Scramble(password, instruction);

            return password;
        }

        public string UnscramblePassword(string password, IEnumerable<string> instructions)
        {
            instructions = instructions.Reverse();

            foreach (var instruction in instructions)
                password = _scrambleOperations.First(x => x.CanHandle(instruction)).Unscramble(password, instruction);

            return password;
        }
    }
}
