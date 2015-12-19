namespace Brannstrom.AdventOfCode.Day18
{
    public class Light
    {
        public bool IsOn { get; private set; }
        public bool IsLocked { get; private set; }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void Lock()
        {
            IsLocked = true;
            TurnOn();
        }

        public Light Animate(int amountOfNeighbours)
        {
            var light = new Light();

            if (IsLocked)
                light.Lock();

            else if (ShouldBeOn(amountOfNeighbours))
                light.TurnOn();

            return light;
        }

        private bool ShouldBeOn(int amountOfNeighbours)
        {
            if (IsOn && (amountOfNeighbours == 2 || amountOfNeighbours == 3))
                return true;

            return !IsOn && amountOfNeighbours == 3;
        }
    }
}
