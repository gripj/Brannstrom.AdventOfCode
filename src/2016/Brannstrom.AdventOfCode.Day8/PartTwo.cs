using System;
using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day8.Instructions;

namespace Brannstrom.AdventOfCode.Day8
{
    public class PartTwo
    {
        private static void Main()
        {
            var instructionExecutors = new List<IInstruction>()
            {
                new TurnOnTopLeftPixelsInstruction(),
                new RotateRowInstruction(),
                new RotateColumnInstruction()
            };

            var screen = new Screen(instructionExecutors);

            var instructions = new InputReader().ReadFile();

            foreach (var instruction in instructions)
                screen.ExecuteInstruction(instruction);

            for (var y = 0; y < screen.Pixels.GetLength(1); y++)
            {
                Console.WriteLine();

                for (var x = 0; x < screen.Pixels.GetLength(0); x++)
                    Console.Write(screen.Pixels[x, y].IsOn ? "x" : " ");
            }

            Console.ReadKey();
        }
    }
}
