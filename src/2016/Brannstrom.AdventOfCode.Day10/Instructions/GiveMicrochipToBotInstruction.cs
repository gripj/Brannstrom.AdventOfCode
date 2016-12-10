using System;

namespace Brannstrom.AdventOfCode.Day10.Instructions
{
    public class GiveMicrochipToBotInstruction : IApplyInstruction
    {
        public bool CanApply(string instruction) => instruction.StartsWith("value");

        public bool Apply(BotFactory factory, string instruction)
        {
            if (!CanApply(instruction)) throw new Exception("Could not apply this instruction");

            var instructionParts = instruction.Split(' ');

            var microchip = int.Parse(instructionParts[1]);
            var botId = $"{instructionParts[4]} {instructionParts[5]}";

            factory.InitializeBot(botId, microchip);

            return true;
        }
    }
}
