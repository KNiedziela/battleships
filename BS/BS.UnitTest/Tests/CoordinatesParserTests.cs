using BS.Core.Helpers;

namespace BS.UnitTest.Tests
{
    public class CoordinatesParserTests
    {
        [TestCase("A1", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("F10", ExpectedResult = true)]
        [TestCase("F10A", ExpectedResult = false)]
        [TestCase("10A", ExpectedResult = false)]
        public bool CoordinatesParser_ShouldParseCorrectly(string coordinates)
        {
            // Act
            var result = CoordinatesParser.ParseCoordinates(coordinates);

            // Assert
            return result.IsSuccess;
        }

        [TestCase("A1", ExpectedResult = "1,1")]
        [TestCase("A2", ExpectedResult = "2,1")]
        [TestCase("C2", ExpectedResult = "2,3")]
        public string CoordinatesParser_ShouldReturnCorrectCoordinates(string coordinates)
        {
            // Act
            var result = CoordinatesParser.ParseCoordinates(coordinates);

            // Assert
            return $"{result.Value.X},{result.Value.Y}";
        }
    }
}