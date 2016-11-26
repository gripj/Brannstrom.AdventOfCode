using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
    [TestFixture]
    public class PartTwo
    {
        [TestCase]
        public void Should_Count_Difference()
        {
            CountDifference().Should().Be(2085);
        }

        private static int CountDifference()
        {
            var fileStrings = new Reader().ReadStringsFromFile();
            return fileStrings.Sum(c => ToLiteral(c).Length - c.Length);
        }

        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
        }
    }
}
