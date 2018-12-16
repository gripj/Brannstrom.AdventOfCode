namespace Brannstrom.AdventOfCode.Day13
{
  public class Cart
  {
    public (int x, int y) Pos { get; set; }
    public int dX { get; set; }
    public int dY { get; set; }
    private Dir _nextTurn = Dir.Left;

    public Cart((int x, int y) position, int deltaX, int deltaY)
    {
      Pos = position;
      dX = deltaX;
      dY = deltaY;
    }

    public void Rotate(Dir dir)
    {
      switch (dir)
      {
        case Dir.Left:
          (dX, dY) = (-dY, dX);
          break;
        case Dir.Right:
          (dX, dY) = (dY, -dX);
          break;
      }
    }

    public void Turn()
    {
      Rotate(_nextTurn);
      _nextTurn = (Dir)(((int)_nextTurn + 1) % 3);
    }
  }

  public enum Dir { Left, Forward, Right }
}