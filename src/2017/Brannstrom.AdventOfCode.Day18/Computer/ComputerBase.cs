using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day18.Computer
{
    public abstract class ComputerBase<TState>
    {
        private readonly Dictionary<string, long> _registers = new Dictionary<string, long>();

        protected bool IsExecuting;
        protected int InstructionPosition;

        protected long this[string register]
        {
            get
            {
                return long.TryParse(register, out var n) ? n
                    : _registers.ContainsKey(register) ? _registers[register]
                    : 0;
            }
            set
            {
                _registers[register] = value;
            }
        }

        public IEnumerable<TState> Execute(IEnumerable<string> input)
        {
            var instructions = input.ToArray();

            while (InstructionPosition >= 0 && InstructionPosition < instructions.Length)
            {
                IsExecuting = true;
                var parts = instructions[InstructionPosition].Split(' ');
                switch (parts[0])
                {
                    case "snd": Snd(parts[1]); break;
                    case "rcv": Rcv(parts[1]); break;
                    case "set": Set(parts[1], parts[2]); break;
                    case "add": Add(parts[1], parts[2]); break;
                    case "mul": Mul(parts[1], parts[2]); break;
                    case "mod": Mod(parts[1], parts[2]); break;
                    case "jgz": Jgz(parts[1], parts[2]); break;
                }
                yield return State();
            }

            IsExecuting = false;
            yield return State();
        }

        protected void Set(string registerA, string registerB)
        {
            this[registerA] = this[registerB];
            InstructionPosition++;
        }

        protected void Add(string registerA, string registerB)
        {
            this[registerA] += this[registerB];
            InstructionPosition++;
        }

        protected void Mul(string registerA, string registerB)
        {
            this[registerA] *= this[registerB];
            InstructionPosition++;
        }

        protected void Mod(string registerA, string registerB)
        {
            this[registerA] %= this[registerB];
            InstructionPosition++;
        }

        protected void Jgz(string registerA, string registerB)
        {
            InstructionPosition += this[registerA] > 0 ? (int)this[registerB] : 1;
        }

        protected abstract TState State();

        protected abstract void Snd(string reg);

        protected abstract void Rcv(string reg);
    }
}