using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day10.Instructions;

namespace Brannstrom.AdventOfCode.Day10
{
    public class BotFactory
    {
        private readonly List<Bot> _bots = new List<Bot>();
        private readonly List<MicrochipTransaction> _transactions = new List<MicrochipTransaction>();

        private readonly List<IApplyInstruction> _botInstructions = new List<IApplyInstruction>()
        {
            new DistributeMicrochipsInstruction(),
            new GiveMicrochipToBotInstruction()
        };

        public IEnumerable<MicrochipTransaction> MicroshipTransactions => _transactions;
        public IEnumerable<Bot> Bots => _bots;

        public BotFactory(){}

        public BotFactory(IEnumerable<Bot> botsToStartOutWith)
        {
            _bots.AddRange(botsToStartOutWith);
        }

        public void ApplyInstructions(IEnumerable<string> instructions)
        {
            var remainingInstructions = new List<string>(instructions);

            while (remainingInstructions.Count > 0)
                remainingInstructions = Apply(remainingInstructions).ToList();
        }

        private IEnumerable<string> Apply(IEnumerable<string> instructions)
        {
            var unappliedInstructions = new List<string>();

            foreach (var instruction in instructions)
            {
                var wasApplied = _botInstructions
                                        .First(x => x.CanApply(instruction))
                                        .Apply(this, instruction);
 
                if (!wasApplied)
                    unappliedInstructions.Add(instruction);
            }

            return unappliedInstructions;
        }

        public Bot GetBot(string id) => _bots.FirstOrDefault(x => x.Id == id);

        public Bot InitializeBot(string id, params int[] microchips)
        {
            var bot = GetBot(id);

            if (bot == null)
            {
                bot = new Bot(id);
                _bots.Add(bot);

                bot.MicrochipReceived += (x, e) => _transactions.Add(new MicrochipTransaction(e.BotId, e.CurrentMicroships));
            }

            foreach (var microchip in microchips)
                bot.Receive(microchip);

            return bot;
        }

        public class MicrochipTransaction
        {
            public string BotId { get; }
            public List<int> Microchips { get; }

            public MicrochipTransaction(string botId, IEnumerable<int> microchips)
            {
                BotId = botId;
                Microchips = new List<int>(microchips);
            }
        }
    }
}
