namespace Brannstrom.AdventOfCode.Day5.Instructions
{
    public class StrangeJumpInstruction : JumpInstruction
    {
        public StrangeJumpInstruction(int offset) : base(offset) { }

        protected override void ModifyOffset() => Offset++;
    }
}
