using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Get_Common_Letters_In_Example()
    {
      var boxIds = new List<string>()
      {
        "abcde",
        "fghij",
        "klmno",
        "pqrst",
        "fguij",
        "axcye",
        "wvxyz"
      };

      CommonLettersCalculator.Calculate(boxIds).Should().Be("fgij");
    }

    [Test]
    public void Should_Get_Common_Letters()
    {
      CommonLettersCalculator.Calculate(InputReader.Read().ToList()).Should().Be("qysdtrkloagnfozuwujmhrbvx");
    }
  }
}
