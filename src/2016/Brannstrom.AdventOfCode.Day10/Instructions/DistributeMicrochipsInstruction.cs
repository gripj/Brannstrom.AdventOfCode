using System;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day10.Instructions
{
    public class DistributeMicrochipsInstruction : IApplyInstruction
    {
        public bool CanApply(string instruction) => instruction.StartsWith("bot");

        public bool Apply(BotFactory factory, string instruction)
        {
            if (!CanApply(instruction)) throw new Exception("Could not apply this instruction");

            var instructionParts = instruction.Split(' ');
            var botId = $"{instructionParts[0]} {instructionParts[1]}";
            var giver = factory.GetBot(botId);

            if (giver == null || giver.Microchips.Count() != 2)
                return false;

            var lowValueReceiver = EnsureBot(factory, $"{instructionParts[5]} {instructionParts[6]}");
            giver.GiveLowestTo(lowValueReceiver);

            var highValueReceiver = EnsureBot(factory, $"{instructionParts[10]} {instructionParts[11]}");
            giver.GiveHighestTo(highValueReceiver);

            return true;
        }

        private static Bot EnsureBot(BotFactory factory, string id)
        {
            return factory.GetBot(id) ?? factory.InitializeBot(id);
        }
    }
}
