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

        public Light Animate(int amountOfNeighbors)
        {
            var light = new Light();

            if (IsLocked)
                light.Lock();

            else if (ShouldBeOn(amountOfNeighbors))
                light.TurnOn();

            return light;
        }

        private bool ShouldBeOn(int amountOfNeighbors)
        {
            if (IsOn && (amountOfNeighbors == 2 || amountOfNeighbors == 3))
                return true;

            return !IsOn && amountOfNeighbors == 3;
        }
    }
}
