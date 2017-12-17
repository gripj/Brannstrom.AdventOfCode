using System.Collections.Generic;
using System.IO;
using Brannstrom.AdventOfCode.Day16.DanceMoves;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void SpinMove_Should_Spin_Program_Line()
        {
            new SpinMove().Move("s3", "abcde").Should().Be("cdeab");
        }

        [Test]
        public void ExchangeMove_Should_Exchange_Indicated_Programs()
        {
            new ExchangeMove().Move("x3/4", "eabcd").Should().Be("eabdc");
        }

        [Test]
        public void SwapMove_Should_Swap_Indicated_Programs()
        {
            new SwapMove().Move("pe/b", "eabdc").Should().Be("baedc");
        }

        [Test]
        public void Dance_Should_Produce_Expected_Order_In_Example()
        {
            new Dance("abcde", new List<string>() { "s1", "x3/4", "pe/b" })
                .Programs
                .Should()
                .Be("baedc");
        }

        [Test]
        public void Dance_Should_Produce_Correct_Order_Of_Programs()
        {
            new Dance("abcdefghijklmnop", File.ReadAllText("input.txt").Split(','))
                .Programs
                .Should()
                .Be("kpbodeajhlicngmf");
        }
    }
}
