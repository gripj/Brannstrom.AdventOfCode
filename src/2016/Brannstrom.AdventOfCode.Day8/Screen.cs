using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day8.Instructions;

namespace Brannstrom.AdventOfCode.Day8
{
    public class Screen
    {
        public Pixel[,] Pixels { get; private set; }
        private readonly IEnumerable<IInstruction> _instructionExecutors;

        public Screen(IEnumerable<IInstruction> instructionExecutors)
        {
            UseLargePixelLayout();
            _instructionExecutors = instructionExecutors;
        }

        public void UseLargePixelLayout() => CreatePixels(50, 6);
        public void UseSmallPixelLayout() => CreatePixels(7, 3);

        private void CreatePixels(int xAxis, int yAxis)
        {
            Pixels = new Pixel[xAxis, yAxis];
            for (var x = 0; x < xAxis; x++)
                for (var y = 0; y < yAxis; y++)
                    Pixels[x, y] = new Pixel();
        }

        public void ExecuteInstruction(string instruction)
        {
            _instructionExecutors.First(x => x.CanHandle(instruction)).Execute(instruction, Pixels);
        }

        public bool SpecifiedPixelIsOn(int x, int y) => Pixels[x, y].IsOn;

        public int GetAmountOfLitPixels()
        {
            var amountTurnedOn = 0;

            for (var x = 0; x < Pixels.GetLength(0); x++)
                for (var y = 0; y < Pixels.GetLength(1); y++)
                    if (Pixels[x, y].IsOn)
                        amountTurnedOn++;

            return amountTurnedOn;
        }
    }
}
