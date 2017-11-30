namespace Brannstrom.AdventOfCode.Day23.ToggleInstructions
{
    public class ToggleOneArgumentInstruction : IToggleInstruction
    {
        public bool CanHandle(string instruction) => instruction.Contains("inc") || 
                                                     instruction.Contains("dec") ||
                                                     instruction.Contains("tgl");

        public string ToggleInstruction(string instruction)
        {
            return instruction.Contains("inc") ? 
                instruction.Replace("inc", "dec") : 
                instruction.Replace("dec", "inc").Replace("tgl", "inc");
        }
    }
}
