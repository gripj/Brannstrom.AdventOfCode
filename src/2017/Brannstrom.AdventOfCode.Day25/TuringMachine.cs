using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day25
{
    public class TuringMachine
    {
        private Dictionary<int, int> _tape;
        private State _state;
        private int _position;

        public bool IsPosition0 => ReadValue(_position) == 0;

        public int CalculateDiagnosticChecksum()
        {
            _tape = new Dictionary<int, int>();
            _state = State.A;
            _position = 0;

            for (var i = 0; i < 12683008; i++)
            {
                switch (_state)
                {
                    case State.A:
                        if (IsPosition0)
                            Execute(1, Move.Right, State.B);
                        else
                            Execute(0, Move.Left, State.B);
                        break;
                    case State.B:
                        if (IsPosition0)
                            Execute(1, Move.Left, State.C);
                        else
                            Execute(0, Move.Right, State.E);
                        break;
                    case State.C:
                        if (IsPosition0)
                            Execute(1, Move.Right, State.E);
                        else
                            Execute(0, Move.Left, State.D);
                        break;
                    case State.D:
                        Execute(1, Move.Left, State.A);
                        break;
                    case State.E:
                        Execute(0, Move.Right, IsPosition0 ? State.A : State.F);
                        break;
                    case State.F:
                        Execute(1, Move.Right, IsPosition0 ? State.E : State.A);
                        break;
                }
            }

            return _tape.Select(kvp => kvp.Value).Sum();
        }

        private void Execute(int value, Move direction, State nextState)
        {
            WriteValue(_position, value);
            _position = direction == Move.Right ? _position + 1 : _position - 1;
            _state = nextState;
        }

        private int ReadValue(int p)
        {
            return _tape.ContainsKey(p) ? _tape[p] : 0;
        }

        private void WriteValue(int position, int value)
        {
            _tape[position] = value;
        }

        private enum State { A, B, C, D, E, F }
        private enum Move { Left, Right }
    }
}
