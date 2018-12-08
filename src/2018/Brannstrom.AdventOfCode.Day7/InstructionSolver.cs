using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day7
{
  public static class InstructionSolver
  {
    public static string CalculateOrder(IEnumerable<string> instructions)
    {
      var steps = instructions.ToSteps().ToList();

      var path = steps
        .Select(x => x.First)
        .Except(steps
          .Select(x => x.Then))
        .OrderBy(x => x)
        .First()
        .ToString();

      var distinct = steps
        .Select(x => new List<char> { x.First, x.Then })
        .SelectMany(x => x)
        .Distinct()
        .Except(path.ToCharArray())
        .ToList();

      return Enumerable.Range(0, distinct.Count)
        .Aggregate(path, (a, b) => a + distinct
                                     .Except(a.ToCharArray())
                                     .Where(x => !steps.Where(y => y.Then == x).Select(y => y.First).Except(a.ToCharArray()).Any())
                                     .OrderBy(y => y)
                                     .FirstOrDefault());
    }

    public static int CalculateCompletionTime(IEnumerable<string> instructions, int numberOfWorkers, int secondsBase)
    {
      var steps = instructions.ToSteps().ToList();
      const int countOffset = 'A' - 1;

      var workers = steps
        .Select(x => x.First)
        .Except(steps
          .Select(x => x.Then))
        .OrderBy(x => x)
        .Take(numberOfWorkers)
        .Select(x => (Step: x, Seconds: 0))
        .ToList();

      var distinct = steps
        .Select(x => new List<char> { x.First, x.Then })
        .SelectMany(x => x)
        .Distinct()
        .ToList();

      var completed = new List<char>();
      var minutes = 0;

      while (completed.Count < distinct.Count)
      {
        workers = workers.Select(x => (x.Step, x.Seconds + 1)).ToList();
        var finished = workers.Where(x => x.Seconds >= x.Step - countOffset + secondsBase).ToList();
        completed.AddRange(finished.Select(x => x.Step));
        workers = workers.Except(finished).ToList();

        var newTasks = distinct
          .Except(completed)
          .Except(workers.Select(x => x.Step))
          .Where(x => !steps.Where(y => y.Then == x).Select(y => y.First).Except(completed).Any())
          .OrderBy(y => y)
          .Take(numberOfWorkers - workers.Count)
          .Select(x => (Step: x, Seconds: 0));

        workers.AddRange(newTasks);
        minutes++;
      }

      return minutes;
    }

    private static IEnumerable<(char First, char Then)> ToSteps(this IEnumerable<string> instructions)
    {
      return instructions.Select(x => (x[5], x[36]));
    }
  }
}
