namespace Brannstrom.AdventOfCode.Day8.Instructions
{
    public class TurnOnTopLeftPixelsInstruction : IInstruction
    {
        public void Execute(string instruction, Pixel[,] view)
        {
            var specifiedPixels = instruction.Remove(0, 4).Split('x');
            var xAxis = int.Parse(specifiedPixels[0]);
            var yAxis = int.Parse(specifiedPixels[1]);

            for (var x = 0; x < xAxis; x++)
                for (var y = 0; y < yAxis; y++)
                    view[x,y].TurnOn();
        }

        public bool CanHandle(string instruction) => instruction.Contains("rect");
    }
}
