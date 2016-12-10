using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day8.Instructions
{
    public class RotateRowInstruction : IInstruction
    {
        public void Execute(string instruction, Pixel[,] view)
        {
            var specifiedPixels = instruction
                        .Replace("rotate row y=", "")
                        .Split(new string[] { " by " }, StringSplitOptions.None);

            var specifiedRow = int.Parse(specifiedPixels[0]);
            var shiftDistance = int.Parse(specifiedPixels[1]);

            for (var d = 0; d < shiftDistance; d++)
            {
                var pixelsToTurnOn = GetNextIterationOfLitPixels(view, specifiedRow).ToList();
                DrawNextIteration(view, pixelsToTurnOn, specifiedRow);
            }
        }

        public bool CanHandle(string instruction) => instruction.Contains("row");

        private static IEnumerable<string> GetNextIterationOfLitPixels(Pixel[,] view, int specifiedRow)
        {
            for (var x = 0; x < view.GetLength(0); x++)
                if (view[x, specifiedRow].IsOn)
                    yield return (x == view.GetLength(0) - 1 ? 0 : x + 1) + "," + specifiedRow;
        }

        private static void DrawNextIteration(Pixel[,] view, IEnumerable<string> pixelsToTurnOn, int specifiedRow)
        {
            for (var x = 0; x < view.GetLength(0); x++)
                if (pixelsToTurnOn.Contains(x + "," + specifiedRow))
                    view[x, specifiedRow].TurnOn();
                else
                    view[x, specifiedRow].TurnOff();
        }
    }
}
