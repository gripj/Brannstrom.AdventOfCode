using System.Linq;

namespace Brannstrom.AdventOfCode.Day16.DanceMoves
{
    public class SwapMove : IDanceMove
    {
        public bool CanHandleInstruction(string instruction) => instruction[0] == 'p';

        public string Move(string instruction, string danceLine)
        {
            var parts = instruction.Substring(1).Split('/').ToList();

            var firstIndex = danceLine.IndexOf(parts[0]);
            var secondIndex = danceLine.IndexOf(parts[1]);

            var array = danceLine.ToCharArray();
            array[secondIndex] = danceLine[firstIndex];
            array[firstIndex] = danceLine[secondIndex];

            return new string(array);
        }
    }
}
