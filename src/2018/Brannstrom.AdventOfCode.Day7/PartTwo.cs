using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Should_Calculate_Completion_Time_In_Example()
    {
      var instructions = new List<string>()
      {
        "Step C must be finished before step A can begin.",
        "Step C must be finished before step F can begin.",
        "Step A must be finished before step B can begin.",
        "Step A must be finished before step D can begin.",
        "Step B must be finished before step E can begin.",
        "Step D must be finished before step E can begin.",
        "Step F must be finished before step E can begin."
      };

      InstructionSolver.CalculateCompletionTime(instructions, 2, 0).Should().Be(15);
    }

    [Test]
    public void Should_Calculate_Completion_Time()
    {
      InstructionSolver.CalculateCompletionTime(InputReader.Read(), 5, 60).Should().Be(982);
    }
  }
}
