namespace Brannstrom.AdventOfCode.Day23.ToggleInstructions
{
    public class ToggleTwoArgumentInstruction : IToggleInstruction
    {
        public bool CanHandle(string instruction) => instruction.Contains("cpy") || instruction.Contains("jnz");

        public string ToggleInstruction(string instruction)
        {
            return instruction.Contains("jnz") ? 
                instruction.Replace("jnz", "cpy") : 
                instruction.Replace("cpy", "jnz");
        }
    }
}
