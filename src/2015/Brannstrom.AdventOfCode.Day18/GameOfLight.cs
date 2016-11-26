using System.Linq;

namespace Brannstrom.AdventOfCode.Day18
{
    public class GameOfLight
    {
        public GameOfLight(LightGrid lightGrid)
        {
            LightGrid = lightGrid;
        }

        public LightGrid LightGrid { get; }

        public LightGrid AnimateLights(int amountOfFrames)
        {
            var frames = Enumerable.Range(1, amountOfFrames);

            return frames.Aggregate(LightGrid, (current, frame) => current.Animate());
        }

        public int GetNumberOfLitLights(LightGrid lightGrid)
        {
            return lightGrid.Lights.Cast<Light>().Count(light => light.IsOn);
        }
    }
}
