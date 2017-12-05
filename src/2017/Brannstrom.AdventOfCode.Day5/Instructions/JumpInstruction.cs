namespace Brannstrom.AdventOfCode.Day5.Instructions
{
    public abstract class JumpInstruction
    {
        protected int Offset { get; set; }

        protected JumpInstruction(int offset)
        {
            Offset = offset;
        }

        public int Jump()
        {
            var offset = Offset;
            ModifyOffset();
            return offset;
        }

        protected abstract void ModifyOffset();
    }
}
