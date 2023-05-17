using BS.Core.Entities;
using BS.Core.Helpers;

namespace BS.UnitTest.Tests
{
    public class ShipCoordinatesExtensionsTests
    {
        [TestCase(0, 0, true, 3, ExpectedResult = "3,0")]
        [TestCase(0, 0, false, 3, ExpectedResult = "0,3")]
        [TestCase(5, 2, true, 2, ExpectedResult = "7,2")]
        [TestCase(5, 2, false, 2, ExpectedResult = "5,4")]
        public string GetShipEndCoordinates_ShouldReturnCorrectCoordinates(int startX, int startY, bool isHorizontal, int shipLength)
        {
            // Arrange
            var startCoordinates = Coordinates.Create(startX, startY);

            // Act
            var endCoordinates = startCoordinates.GetShipEndCoordinates(isHorizontal, shipLength);

            // Assert
            return $"{endCoordinates.X},{endCoordinates.Y}";
        }
    }
}