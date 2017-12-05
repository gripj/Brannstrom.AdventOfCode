namespace Brannstrom.AdventOfCode.Day5.Instructions
{
    public class StrangerJumpInstruction : JumpInstruction
    {
        public StrangerJumpInstruction(int offset) : base(offset) {}

        protected override void ModifyOffset()
        {
            Offset = Offset >= 3 ? Offset - 1 : Offset + 1;
        }
    }
}
