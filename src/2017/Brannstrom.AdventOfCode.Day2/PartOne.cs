using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        private ChecksumCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new ChecksumCalculator();
        }

        [Test]
        [TestCase("5 1 9 5", 8)]
        [TestCase("7 5 3", 4)]
        [TestCase("2 4 6 8", 6)]
        public void Should_Calculate_Checksum_For_Single_Row(string row, int expectedChecksum)
        {
            _calculator
                .CalculateForDifference(new [] {
                    row.ToNumbersArray()
                })
                .Should()
                .Be(expectedChecksum);
        }

        [Test]
        public void Should_Calculate_Checksum_For_Example_Spreadsheet()
        {
            _calculator
                .CalculateForDifference(new List<int[]>()
                {
                    "5 1 9 5".ToNumbersArray(),
                    "7 5 3".ToNumbersArray(),
                    "2 4 6 8".ToNumbersArray()
                }.ToArray())
                .Should()
                .Be(18);
        }

        [Test]
        public void Should_Calculate_Checksum_Of_Spreadsheet()
        {
            _calculator
                .CalculateForDifference(SpreadsheetReader.ReadSpreadsheet())
                .Should()
                .Be(36766);
        }
    }
}
