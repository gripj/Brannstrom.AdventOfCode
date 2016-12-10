namespace Brannstrom.AdventOfCode.Day8
{
    public class Pixel
    {
        public bool IsOn { get; private set; }

        public Pixel()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
    }
}
