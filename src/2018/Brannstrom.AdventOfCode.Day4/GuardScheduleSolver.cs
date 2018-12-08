using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day4
{
  public static class GuardScheduleSolver {
    public static double SolvePartOne(IEnumerable<string> observations)
    {
      var guardWithMostMinutesAsleep = observations.ToEvents().ToGuards()
        .Select(x => new {
          Id = x.Key,
          Minutes = x.Select(y => y.Minutes).Sum(),
          Events = x.Select(y => y.Events)
        })
        .OrderByDescending(x => x.Minutes)
        .First();

      return guardWithMostMinutesAsleep.Id * guardWithMostMinutesAsleep.Events.ToMinuteMostAsleep().Minute;
    }

    public static double SolvePartTwo(IEnumerable<string> observations)
    {
      var guard = observations.ToEvents().ToGuards()
        .Select(x => new {
          Id = x.Key,
          MinuteMostAsleep = x.Select(y => y.Events).ToMinuteMostAsleep()
        })
        .OrderByDescending(x => x.MinuteMostAsleep.Times)
        .First();

      return guard.Id * guard.MinuteMostAsleep.Minute;
    }

    private static List<Event> ToEvents(this IEnumerable<string> observations)
    {
      return observations
        .Select(x => Regex.Split(x, @"[\[\]]").Where(y => !string.IsNullOrEmpty(y)))
        .Select((x, index) => new {
          Timestamp = DateTime.Parse(x.ElementAt(0)),
          Message = x.ElementAt(1)
        })
        .OrderBy(x => x.Timestamp)
        .Select((x, index) => new Event(x.Timestamp, x.Message, index + 1))
        .ToList();
    }

    private static IEnumerable<IGrouping<int, Guard>> ToGuards(this IEnumerable<Event> events)
    {
      return events
        .Where(x => x.Message.Trim().StartsWith("Guard"))
        .Select(x =>
        {
          var id = int.Parse(x.Message.Trim().Replace("Guard #", "").Replace(" begins shift", ""));
          var guardEvents = events.Skip(x.Number).TakeWhile(y => !y.Message.Trim().StartsWith("Guard")).ToList();
          return new Guard(id, guardEvents);
        })
        .GroupBy(x => x.Id);
    }


    private static (int Minute, int Times) ToMinuteMostAsleep(this IEnumerable<List<Event>> events)
    {
      return events.Select(x => x.ToMinuteRange())
        .SelectMany(x => x)
        .GroupBy(x => x)
        .Select(x => (x.Key, x.Count()))
        .OrderByDescending(x => x.Item2)
        .FirstOrDefault();
    }

    private static IList<int> ToMinuteRange(this IEnumerable<Event> events)
    {
      return events
        .Select((x, i) => (Value: x, Index: i))
        .GroupBy(x => x.Index / 2)
        .Select(x => Enumerable.Range(x.First().Value.Timestamp.Minute,
          x.Last().Value.Timestamp.Minute - x.First().Value.Timestamp.Minute))
        .SelectMany(x => x)
        .ToList();
    }
  }
}
