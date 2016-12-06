using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartTwo
    {
        private SignalDecrypter _signalDecrypter;
        private InputReader _inputReader;

        [SetUp]
        public void SetUp()
        {
            _signalDecrypter = new SignalDecrypter();
            _inputReader = new InputReader();
        }

        [Test]
        public void Should_Decrypt_Example_Signals()
        {
            _signalDecrypter
                .DecryptSignalsIntoMessageUsingLeastLikelyMethod(_inputReader.GetExampleSignals())
                .Should()
                .Be("advent");
        }

        [Test]
        public void Should_Decrypt_Signal()
        {
            _signalDecrypter
                .DecryptSignalsIntoMessageUsingLeastLikelyMethod(_inputReader.ReadFile())
                .Should()
                .Be("owlaxqvq");
        }
    }
}
