using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartOne
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
                .DecryptSignalsIntoMessage(_inputReader.GetExampleSignals())
                .Should()
                .Be("easter");
        }

        [Test]
        public void Should_Read_Input()
        {
            _inputReader
                .ReadFile()
                .Count()
                .Should()
                .BeGreaterThan(0);
        }

        [Test]
        public void Should_Decrypt_Signal()
        {
            _signalDecrypter
                .DecryptSignalsIntoMessage(_inputReader.ReadFile())
                .Should()
                .Be("agmwzecr");
        }
    }
}
