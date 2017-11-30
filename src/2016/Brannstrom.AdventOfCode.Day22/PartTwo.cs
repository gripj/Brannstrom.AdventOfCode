using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Fewewst_Number_Of_Steps_To_Move_Goal_Data_In_Example()
        {
            var nodes = new List<string>()
            {
                "Filesystem            Size  Used  Avail  Use%",
                "/dev/grid/node-x0-y0   10T    8T     2T   80%",
                "/dev/grid/node-x0-y1   11T    6T     5T   54%",
                "/dev/grid/node-x0-y2   32T   28T     4T   87%",
                "/dev/grid/node-x1-y0    9T    7T     2T   77%",
                "/dev/grid/node-x1-y1    8T    0T     8T    0%",
                "/dev/grid/node-x1-y2   11T    7T     4T   63%",
                "/dev/grid/node-x2-y0   10T    6T     4T   60%",
                "/dev/grid/node-x2-y1    9T    8T     1T   88%",
                "/dev/grid/node-x2-y2    9T    6T     3T   66%"
            }
            .Where(x => x.Contains("/dev/grid"))
            .Select(Node.Parse);

            new GridComputer()
                .CalculateFewestNumberOfStepsToMoveGoalData(nodes, 3)
                .Should()
                .Be(7);
        }

        [Test]
        public void Should_Calculate_Fewest_Number_Of_Steps_To_Move_Goal_Data()
        {
            var nodes = new InputReader()
                .ReadFile()
                .Where(x => x.Contains("/dev/grid"))
                .Select(Node.Parse);

            new GridComputer()
                .CalculateFewestNumberOfStepsToMoveGoalData(nodes, 5)
                .Should()
                .Be(188);
        }
    }
}
