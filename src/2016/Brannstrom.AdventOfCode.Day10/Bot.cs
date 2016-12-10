using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day10
{
    public class Bot
    {
        private readonly List<int> _microchips = new List<int>();

        public string Id { get; }
        public IEnumerable<int> Microchips => _microchips;

        public event EventHandler<MicrochipReceivedEvent> MicrochipReceived;

        public Bot(string id, params int[] microchips)
        {
            Id = id;

            foreach (var m in microchips)
                _microchips.Add(m);
        }

        public void Receive(int microchip)
        {
            _microchips.Add(microchip);

            MicrochipReceived?.Invoke(this, new MicrochipReceivedEvent
            {
                BotId = Id,
                MicroshipReceived = microchip,
                CurrentMicroships = _microchips
            });
        }

        public void GiveLowestTo(Bot receiver)
        {
            var lowest = Microchips.OrderBy(x => x).First();
            receiver.Receive(lowest);
            _microchips.Remove(lowest);
        }

        public void GiveHighestTo(Bot receiver)
        {
            var highest = Microchips.OrderByDescending(x => x).First();
            receiver.Receive(highest);
            _microchips.Remove(highest);
        }
    }
}
