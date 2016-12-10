using System;
using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day10
{
    public class MicrochipReceivedEvent : EventArgs
    {
        public string BotId { get; set; }
        public int MicroshipReceived { get; set; }
        public IEnumerable<int> CurrentMicroships { get; set; }
    }
}
