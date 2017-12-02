using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartTwo
    {
        private ChecksumCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ChecksumCalculator();
        }

        [Test]
        [TestCase("5 9 2 8", 4)]
        [TestCase("9 4 7 3", 3)]
        [TestCase("3 8 6 5", 2)]
        public void Should_Calculate_Checksum_For_Single_Row(string row, int expectedChecksum)
        {
            _calculator
                .CalculateForEvenlyDivisible(new [] {
                    row.ToNumbersArray()
                })
                .Should()
                .Be(expectedChecksum);
        }

        [Test]
        public void Should_Calculate_Checksum_For_Example_Spreadsheet()
        {
            _calculator
                .CalculateForEvenlyDivisible(new List<int[]>()
                {
                    "5 9 2 8".ToNumbersArray(),
                    "9 4 7 3".ToNumbersArray(),
                    "3 8 6 5".ToNumbersArray()
                }.ToArray())
                .Should()
                .Be(9);
        }

        [Test]
        public void Should_Calculate_Checksum_Of_Spreadsheet()
        {
            _calculator
                .CalculateForEvenlyDivisible(SpreadsheetReader.ReadSpreadsheet())
                .Should()
                .Be(261);
        }
    }
}
