using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day8.Instructions
{
    public class RotateColumnInstruction : IInstruction
    {
        public void Execute(string instruction, Pixel[,] view)
        {
            var specifiedPixels = instruction
                        .Replace("rotate column x=", "")
                        .Split(new string[] { " by " }, StringSplitOptions.None);

            var specifiedColumn = int.Parse(specifiedPixels[0]);
            var shiftDistance = int.Parse(specifiedPixels[1]);

            for (var d = 0; d < shiftDistance; d++)
            {
                var pixelsToTurnOn = GetNextIterationOfLitPixels(view, specifiedColumn).ToList();
                DrawNextIteration(view, pixelsToTurnOn, specifiedColumn);
            }
        }

        public bool CanHandle(string instruction) => instruction.Contains("column");

        private static IEnumerable<string> GetNextIterationOfLitPixels(Pixel[,] view, int specifiedColumn)
        {
            for (var y = 0; y < view.GetLength(1); y++)
                if (view[specifiedColumn, y].IsOn)
                    yield return specifiedColumn + "," + (y == view.GetLength(1) - 1 ? 0 : y + 1);
        }

        private static void DrawNextIteration(Pixel[,] view, IEnumerable<string> pixelsToTurnOn, int specifiedColumn)
        {
            for (var y = 0; y < view.GetLength(1); y++)
                if (pixelsToTurnOn.Contains(specifiedColumn + "," + y))
                    view[specifiedColumn, y].TurnOn();
                else
                    view[specifiedColumn, y].TurnOff();
        }
    }
}
