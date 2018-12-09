using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day9
{
  public static class MarbleGame
  {
    public static long CalculateHighScore(int amountOfPlayers, int highestMarbleNumber)
    {
      var circle = new LinkedList<int>();
      var currentMarble = circle.AddFirst(0);
      var nextMarbleNumber = 0;
      var currentPlayer = 0;
      var scores = new long[amountOfPlayers];

      while (nextMarbleNumber++ < highestMarbleNumber)
      {
        if (nextMarbleNumber % 23 == 0)
        {
          var toRemove = GetSeventhMarbleCounterClockWise(currentMarble, circle);

          currentMarble = toRemove.Next ?? circle.First;
          scores[currentPlayer] += nextMarbleNumber + toRemove.Value;
          circle.Remove(toRemove);
        }
        else
        {
          var next = currentMarble.Next ?? circle.First;
          currentMarble = circle.AddAfter(next, nextMarbleNumber);
        }

        currentPlayer = (currentPlayer + 1) % amountOfPlayers;
      }

      return scores.Max();
    }

    private static LinkedListNode<int> GetSeventhMarbleCounterClockWise(this LinkedListNode<int> marble, LinkedList<int> circle)
    {
      var marbleToRemove = marble;

      for (var i = 0; i < 7; i++)
        marbleToRemove = marbleToRemove.Previous ?? circle.Last;

      return marbleToRemove;
    }
  }
}
