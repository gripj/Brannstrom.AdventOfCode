using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day4
{
  public class Guard
  {
    public int Id { get; }
    public List<Event> Events { get; }
    public int Minutes { get; }

    public Guard(int id, List<Event> events)
    {
      Id = id;
      Events = events;
      Minutes = CountMinutes(events);
    }

    private static int CountMinutes(IEnumerable<Event> events)
    {
      return events.Select((x, i) => {
        if (i % 2 == 0) return -x.Timestamp.Minute;
        return x.Timestamp.Minute;
      }).Sum();
    }
  }
}
