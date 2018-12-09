using System;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day8
{
  public class Node
  {
    public Node[] Children { get; private set; }
    public int[] Metadata { get; private set; }

    public T Reduce<T>(T seed, Func<T, Node, T> aggregate)
    {
      return Children.Aggregate(aggregate(seed, this), (cur, child) => child.Reduce(cur, aggregate));
    }

    public int Value()
    {
      if (Children.Length == 0)
        return Metadata.Sum();

      var res = 0;

      foreach (var i in Metadata)
        if (i >= 1 && i <= Children.Length)
          res += Children[i - 1].Value();

      return res;
    }

    public static Node Parse(string input)
    {
      var nums = input.Split(new char[0]).Select(int.Parse).GetEnumerator();

      Func<int> next = () => {
        nums.MoveNext();
        return nums.Current;
      };

      Func<Node> read = null;

      read = () => {
        var node = new Node()
        {
          Children = new Node[next()],
          Metadata = new int[next()]
        };

        for (var i = 0; i < node.Children.Length; i++)
          node.Children[i] = read();

        for (var i = 0; i < node.Metadata.Length; i++)
          node.Metadata[i] = next();

        return node;
      };

      return read();
    }
  }
}
