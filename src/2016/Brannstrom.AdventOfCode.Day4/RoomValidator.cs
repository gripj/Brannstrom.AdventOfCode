using System.Linq;

namespace Brannstrom.AdventOfCode.Day4
{
    public class RoomDecrypter
    {
        public bool ValidateEncryptedRoom(EncryptedRoom encryptedRoom)
        {
            return encryptedRoom.Checksum == GetActualChecksum(encryptedRoom.EncryptedName);
        }

        private static string GetActualChecksum(string encryptedName)
        {
            var checksumArray = encryptedName
                                    .Replace("-", "")
                                    .ToCharArray()
                                    .GroupBy(x => x)
                                    .ToDictionary(g => g.Key, g => g.Count())
                                    .OrderByDescending(x => x.Value)
                                    .ThenBy(x => x.Key)
                                    .Take(5)
                                    .Select(w => w.Key)
                                    .ToArray();

            return new string(checksumArray);
        }

        public string DecryptName(EncryptedRoom encryptedRoom)
        {
            var descryptedName = "";

            foreach (var c in encryptedRoom.EncryptedName.ToCharArray())
                if (c != '-')                
                    descryptedName += MoveCharacter(c, encryptedRoom.SectorId);                
                else
                    descryptedName += " ";

            return descryptedName;
        }

        private static char MoveCharacter(char c, int sectorId)
        {
            var moveBy = sectorId % 26;

            var movedC = c + moveBy;
            if (movedC > 'z')
                movedC = movedC - 26;

            return (char)movedC;
        }
    }
}
