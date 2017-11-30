using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Parse_Node()
        {
            var node = Node.Parse("/dev/grid/node-x1-y2     91T   67T    24T   73%");
            node.X.Should().Be(1);
            node.Y.Should().Be(2);
            node.Size.Should().Be(91);
            node.Used.Should().Be(67);
            node.Avail.Should().Be(24);
            node.UsePercent.Should().Be(73);
        }

        [Test]
        public void Should_Calculate_Number_Of_Viable_Node_Pairs()
        {
            var nodes = new InputReader()
                .ReadFile()
                .Where(x => x.Contains("/dev/grid"))
                .Select(Node.Parse);

            new GridComputer()
                .CountViablePairsOfNodes(nodes)
                .Should()
                .Be(937);
        }
    }
}
