using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day25
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Diagnostic_Checksum_In_Example()
        {
            new TuringMachine().CalculateDiagnosticChecksum().Should().Be(3554);
        }
    }
}
