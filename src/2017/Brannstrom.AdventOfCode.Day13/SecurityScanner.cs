namespace Brannstrom.AdventOfCode.Day13
{
    public class SecurityScanner
    {
        public int CurrentPosition { get; private set; }
        private int _range { get; }
        private Direction _direction { get; set; }

        public SecurityScanner(int range)
        {
            _range = range;
            _direction = Direction.Down;
            CurrentPosition = 1;
        }

        public void Move()
        {
            if (_direction == Direction.Down)
                CurrentPosition = CurrentPosition + 1;
            else
                CurrentPosition = CurrentPosition - 1;

            if (CurrentPosition == 1 || CurrentPosition == _range)
                SwitchDirection();
        }

        private void SwitchDirection()
        {
            if (_direction == Direction.Down)
                _direction = Direction.Up;
            else
                _direction = Direction.Down;
        }

        private enum Direction
        {
            Up, Down
        }
    }
}
