using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    [TestFixture]
    public class PartOne
    {
        private Circuit _circuit;

        [SetUp]
        public void SetUp()
        {
            _circuit = new Circuit();
        }

        [Test]
        public void Calculate_Signal_For_Wire_A()
        {
            _circuit.GetSignalForWireA().Should().Be(46065);
        }

        [Test]
        public void Simple_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "456 -> y" });
            signals["y"].Should().Be(456);
        }

        [Test]
        public void BitwiseAnd_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "x AND y -> d", "123 -> x", "456 -> y" });
            signals["d"].Should().Be(72);
        }

        [Test]
        public void BitwiseOr_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "123 -> x", "456 -> y", "x OR y -> e" });
            signals["e"].Should().Be(507);
        }

        [Test]
        public void Leftshift_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "x LSHIFT 2 -> q", "456 -> x" });
            signals["q"].Should().Be(1824);
        }

        [Test]
        public void Rightshift_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "x RSHIFT 2 -> q", "456 -> x" });
            signals["q"].Should().Be(114);
        }

        [Test]
        public void NotOperator_Signal_Should_Provide_Value_To_Wire()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "NOT x -> h", "123 -> x" });
            signals["h"].Should().Be(65412);
        }

        [Test]
        public void Should_Provide_Value_When_Signal_Is_Passed_Through()
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "lx -> a", "123 -> lx" });
            signals["a"].Should().Be(123);
        }

        [Test]
        [TestCase("d", (ushort)72)]
        [TestCase("e", (ushort)507)]
        [TestCase("f", (ushort)492)]
        [TestCase("g", (ushort)114)]
        [TestCase("h", (ushort)65412)]
        [TestCase("i", (ushort)65079)]
        [TestCase("x", (ushort)123)]
        [TestCase("y", (ushort)456)]
        public void Should_Correctly_Resolve_Signal_Values_From_Instructions(string wireName, ushort expectedSignalValue)
        {
            var signals = _circuit.GetSignalsForInstructions(new List<string>() { "123 -> x", "456 -> y", "x AND y -> d", "x OR y -> e", "x LSHIFT 2 -> f", "y RSHIFT 2 -> g", "NOT x -> h", "NOT y -> i" });
            signals[wireName].Should().Be(expectedSignalValue);
        }
    }
}
