using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day18.Computer
{
    public class ComputerV2 : ComputerBase<(bool IsActive, int TimesSent)>
    {
        private int _timesSent;

        private readonly Queue<long> _inQueue;
        private readonly Queue<long> _outQueue;

        public ComputerV2(long p, Queue<long> inQueue, Queue<long> outQueue)
        {
            this["p"] = p;
            _inQueue = inQueue;
            _outQueue = outQueue;
        }

        protected override (bool IsActive, int TimesSent) State()
        {
            return (IsActive: IsExecuting, TimesSent: _timesSent);
        }

        protected override void Snd(string reg)
        {
            _outQueue.Enqueue(this[reg]);
            _timesSent++;
            InstructionPosition++;
        }

        protected override void Rcv(string reg)
        {
            if (_inQueue.Any())
            {
                this[reg] = _inQueue.Dequeue();
                InstructionPosition++;
            }
            else
                IsExecuting = false;
        }
    }
}
