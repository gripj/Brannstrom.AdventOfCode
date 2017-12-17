namespace Brannstrom.AdventOfCode.Day16.DanceMoves
{
    public class SpinMove : IDanceMove
    {
        public bool CanHandleInstruction(string instruction) => instruction[0] == 's';

        public string Move(string instruction, string danceLine)
        {
            var beginning = danceLine.Substring(danceLine.Length - int.Parse(instruction.Substring(1)));
            var end = danceLine.Substring(0, danceLine.Length - int.Parse(instruction.Substring(1)));
            return beginning + end;
        }
    }
}
