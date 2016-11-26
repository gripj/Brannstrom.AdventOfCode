using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Brannstrom.AdventOfCode.Day12
{
    public class JsonAnalyzer
    {
        public int GetSumOfAllNumbers(string input)
        {
            var sum = GetJsonNumbers(input)
                .Select(x => x.Value<int>())
                .Sum();

            return sum;
        }

        private static IEnumerable<JToken> GetJsonNumbers(string input)
        {
            return Parse(input).Descendants().Where(x => x.Type == JTokenType.Integer);
        }

        private static JContainer Parse(string input)
        {
            return IsObject(input) ? 
                (JContainer)JObject.Parse(input) :
                (JContainer)JArray.Parse(input);
        }

        private static bool IsObject(string input) => input.StartsWith("{");

        public int GetSumOfAllNonRedNumbers(string input)
        {
            var nonRedSum = GetJsonNumbers(input)
                .Select(GetNonRedValueOfIntegerNode)
                .Sum();

            return nonRedSum;
        }

        private static int GetNonRedValueOfIntegerNode(JToken node)
        {
            return NodeHasRedValues(node) ? 0 : node.Value<int>();
        }

        private static bool NodeHasRedValues(JToken node)
        {
            var objectAncestors = node.Ancestors()
            .Where(x => x.Type == JTokenType.Object);

            return objectAncestors.Where(ContainsRedValues).Any();
        }

        private static bool ContainsRedValues(JToken j)
        {
            var propertyValues = 
                j.Select(x => x as JProperty)
                .Select(x => x.Value).ToList();

            var containsRedValues = 
                propertyValues
                .Where(x => x.Type == JTokenType.String)
                .Any(x => x.Value<string>() == "red");

            return containsRedValues;
        }
    }
}
