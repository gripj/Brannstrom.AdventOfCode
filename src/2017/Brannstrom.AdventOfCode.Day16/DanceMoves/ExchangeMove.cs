using System.Linq;

namespace Brannstrom.AdventOfCode.Day16.DanceMoves
{
    public class ExchangeMove : IDanceMove
    {
        public bool CanHandleInstruction(string instruction) => instruction[0] == 'x';

        public string Move(string instruction, string danceLine)
        {
            var parts = instruction.Substring(1).Split('/').Select(int.Parse).ToList();

            var array = danceLine.ToCharArray();
            array[parts[1]] = danceLine[parts[0]];
            array[parts[0]] = danceLine[parts[1]];

            return new string(array);
        }
    }
}
