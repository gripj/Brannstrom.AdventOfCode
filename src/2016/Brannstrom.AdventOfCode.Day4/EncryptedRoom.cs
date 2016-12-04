namespace Brannstrom.AdventOfCode.Day4
{
    public class EncryptedRoom
    {
        public string EncryptedName { get; }
        public int SectorId { get; }
        public string Checksum { get; }

        public EncryptedRoom(string encryptedName, int sectorId, string checksum)
        {
            EncryptedName = encryptedName;
            SectorId = sectorId;
            Checksum = checksum;
        }

        public static EncryptedRoom Parse(string input)
        {
            var encryptedName = input.Substring(0, input.LastIndexOf("-"));
            var sectorId = int.Parse(input.Split('[')[0].Substring(input.LastIndexOf("-") + 1));
            var checksum = input.Split('[', ']')[1];

            return new EncryptedRoom(encryptedName, sectorId, checksum);
        }
    }
}
