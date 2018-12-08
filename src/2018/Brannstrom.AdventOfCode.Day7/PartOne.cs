using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Should_Calculate_Completion_Order_In_Example()
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

      InstructionSolver.CalculateOrder(instructions).Should().Be("CABDFE");
    }

    [Test]
    public virtual void Should_Calculate_Completion_Order()
    {
      InstructionSolver.CalculateOrder(InputReader.Read()).Should().Be("OKBNLPHCSVWAIRDGUZEFMXYTJQ");
    }
  }
}