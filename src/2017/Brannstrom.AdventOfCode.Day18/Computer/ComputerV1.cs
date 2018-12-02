namespace Brannstrom.AdventOfCode.Day18.Computer
{
    public class ComputerV1 : ComputerBase<long?>
    {
        private long? _playedFrequency;
        private long? _receivedFrequency;

        protected override long? State() => _receivedFrequency;

        protected override void Snd(string reg)
        {
            _playedFrequency = this[reg];
            InstructionPosition++;
        }

        protected override void Rcv(string reg)
        {
            if (this[reg] != 0)
                _receivedFrequency = _playedFrequency;

            InstructionPosition++;
        }
    }
}
