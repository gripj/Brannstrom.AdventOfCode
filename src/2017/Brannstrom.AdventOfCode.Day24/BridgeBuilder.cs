using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day24
{
    public class BridgeBuilder
    {
        public int GetStrengthOfStrongestBridge(IEnumerable<string> componentInformation)
        {
            var components = Parse(componentInformation);

            Func<(int length, int strength), (int length, int strength), int> compare = (a, b) =>
                a.strength - b.strength;

            return Build(0, components, compare).Strength;
        }

        public int GetStrengthOfLongestBridge(IEnumerable<string> componentInformation)
        {
            var components = Parse(componentInformation);

            Func<(int length, int strength), (int length, int strength), int> compare = (a, b) =>
                a.CompareTo(b);

            return Build(0, components, compare).Strength;
        }

        private (int Length, int Strength) Build(int portIn, HashSet<Component> components, Func<(int length, int strength), (int length, int strength), int> compare)
        {
            var strongestBridge = (0, 0);

            foreach (var component in components.ToList())
            {
                var portOut =
                    portIn == component.PortA ? component.PortB :
                    portIn == component.PortB ? component.PortA :
                    -1;

                if (portOut != -1)
                {
                    components.Remove(component);
                    var current = Build(portOut, components, compare);
                    (current.Length, current.Strength) = (current.Length + 1, current.Strength + component.PortA + component.PortB);
                    strongestBridge = compare(current, strongestBridge) > 0 ? current : strongestBridge;
                    components.Add(component);
                }
            }

            return strongestBridge;
        }

        private static HashSet<Component> Parse(IEnumerable<string> componentInformation)
        {
            var components = new HashSet<Component>();

            foreach (var spec in componentInformation)
            {
                var parts = spec.Split('/');
                var portA = int.Parse(parts[0]);
                var portB = int.Parse(parts[1]);
                components.Add(new Component(portA, portB));
            }

            return components;
        }
    }
}
