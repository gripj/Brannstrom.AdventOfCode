using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
    public class FireWall
    {
        public Dictionary<int, Layer> Layers = new Dictionary<int, Layer>();

        public FireWall(IEnumerable<string> description)
        {
            var layers = description.Select(ToLayer).ToList();
            for (var i = 0; i <= layers.Max(x => x.Depth); i++)
                Layers.Add(i, layers.FirstOrDefault(x => x.Depth == i));
        }

        private static Layer ToLayer(string layer)
        {
            var parts = layer.Replace(" ", "").Split(':').Select(int.Parse).ToList();
            return new Layer(parts[0], parts[1]);
        }

        public void MovePacket(Packet packet)
        {
            for (var i = 0; i < Layers.Count; i++)
            {
                packet.Move(Layers.ContainsKey(i) ? Layers[i] : null);

                foreach (var layer in Layers.Values.Where(x => x != null))
                    layer.PassTime();
            }
        }
    }
}

