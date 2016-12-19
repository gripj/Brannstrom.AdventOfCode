using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Brannstrom.AdventOfCode.Day17
{
    public class PathSolver
    {
        private readonly List<Room> _unvisitedRooms;
        private readonly MD5 _md5;

        public PathSolver()
        {
            _unvisitedRooms = new List<Room>();
            _md5 = MD5.Create();
        }

        public string FindShortestPath(string passcode)
        {
            var paths = FindPaths(passcode, PathType.Shortest);
            return paths.Count > 0 ? paths.First() : "";
        }

        public string FindLongestPath(string passcode)
        {
            var paths = FindPaths(passcode, PathType.All);
            return paths.Count > 0 ? paths.OrderByDescending(p => p.Length).First() : "";
        }

        private enum PathType { Shortest, All };
        private List<string> FindPaths(string passcode, PathType pathType)
        {
            var paths = new List<string>();

            _unvisitedRooms.Add(new Room(0, 0));

            while (_unvisitedRooms.Count > 0)
            {
                var room = _unvisitedRooms.First();
                _unvisitedRooms.RemoveAt(0);

                if (room.X == 3 && room.Y == 3)
                {
                    paths.Add(room.Path);
                    if (pathType == PathType.Shortest) { break; }
                }
                else
                {
                    foreach (var r in GetOpenSurroundingRooms(passcode, room).Where(r => !_unvisitedRooms.Contains(r)))
                        _unvisitedRooms.Add(r);
                }
            }

            return paths;
        }

        private IEnumerable<Room> GetOpenSurroundingRooms(string passcode, Room room)
        {
            var bytes = _md5.ComputeHash(Encoding.ASCII.GetBytes(passcode + room.Path));
            var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            var rooms = new List<Room>();

            if (RoomAboveIsOpen(room, hash))
                rooms.Add(new Room(room.X, room.Y - 1, room.Path + "U"));

            if (RemoveBelowIsOpen(room, hash))
                rooms.Add(new Room(room.X, room.Y + 1, room.Path + "D"));

            if (RoomToTheLeftIsOpen(room, hash))
                rooms.Add(new Room(room.X - 1, room.Y, room.Path + "L"));

            if (RoomToTheRightIsOpen(room, hash))
                rooms.Add(new Room(room.X + 1, room.Y, room.Path + "R"));

            return rooms;
        }

        private static bool RoomAboveIsOpen(Room r, string hash) => r.Y > 0 && r.Y <= 3 && OpenDoorChars.Contains(hash[0]);
        private static bool RemoveBelowIsOpen(Room r, string hash) => r.Y >= 0 && r.Y < 3 && OpenDoorChars.Contains(hash[1]);
        private static bool RoomToTheLeftIsOpen(Room r, string hash) => r.X > 0 && r.X <= 3 && OpenDoorChars.Contains(hash[2]);
        private static bool RoomToTheRightIsOpen(Room r, string hash) => r.X >= 0 && r.X < 3 && OpenDoorChars.Contains(hash[3]);

        private static readonly char[] OpenDoorChars = { 'b', 'c', 'd', 'e', 'f' };
    }
}
