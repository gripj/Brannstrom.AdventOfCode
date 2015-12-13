namespace Brannstrom.AdventOfCode.Day11.PasswordRequirements
{
    public interface IRequirement
    {
        bool IsValid(string password);
    }
}
