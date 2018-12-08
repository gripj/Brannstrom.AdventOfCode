using System;

namespace Brannstrom.AdventOfCode.Day4
{
  public class Event
  {
    public DateTime Timestamp { get; }
    public string Message { get; }
    public int Number { get; }

    public Event(DateTime timestamp, string observation, int number)
    {
      Timestamp = timestamp;
      Message = observation;
      Number = number;
    }
  }
}
