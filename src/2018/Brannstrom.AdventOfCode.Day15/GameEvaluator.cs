using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day15
{
    public class GameEvaluator
    {
        public int CalculateOutcome(IEnumerable<string> input)
        {
            return Calculate(input, 3, 3).outcome;
        }

        public int CalculateOutcomeForElvesWithIncreasingPower(IEnumerable<string> input)
        {
            var elfAp = 3;
            while (true)
            {
                var (noElfDied, outcome) = Calculate(input, 3, elfAp);
                if (noElfDied)
                    return outcome;

                elfAp++;
            }
        }

        private static (bool noElfDied, int outcome) Calculate(IEnumerable<string> input, int goblinAp, int elfAp)
        {
            var game = Game.Parse(input, goblinAp, elfAp);
            var numberOfElves = game.Players.Count(player => player.IsElf);

            var rounds = 0;
            while (game.Step())
                rounds++;

            return (game.Players.Count(p => p.IsElf) == numberOfElves, (rounds - 1) * game.Players.Select(player => player.Hp).Sum());
        }
    }
}
