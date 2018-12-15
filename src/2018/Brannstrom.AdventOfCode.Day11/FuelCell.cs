namespace Brannstrom.AdventOfCode.Day11
{
  public static class FuelCell
  {
    public static int CalculatePowerLevel(int x, int y, int serialNumber)
    {
      var rackId = x + 10;
      var beginningPowerLevel = rackId * y;
      var increasedBySerialNumber = beginningPowerLevel + serialNumber;
      var multipliedByRackId = increasedBySerialNumber * rackId;
      var hundredth = int.Parse(multipliedByRackId.ToString().Substring(multipliedByRackId.ToString().Length - 3)[0]
        .ToString());
      return hundredth - 5;
    }
  }
}
