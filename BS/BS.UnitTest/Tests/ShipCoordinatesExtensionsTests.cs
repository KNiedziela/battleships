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
        public string GetShipEndCoordinates_ShouldReturnCorrectCoordinates(int startX, int startY, bool isHorizontal,
            int shipLength)
        {
            // Arrange
            var startCoordinates = Coordinates.Create(startX, startY);

            // Act
            var endCoordinates = startCoordinates.GetShipEndCoordinates(isHorizontal, shipLength);

            // Assert
            return $"{endCoordinates.X},{endCoordinates.Y}";
        }

        [TestCase(10, 10, 1, 1, ExpectedResult = false)]
        [TestCase(10, 10, 10, 10, ExpectedResult = false)]
        [TestCase(10, 10, 11, 10, ExpectedResult = true)]
        [TestCase(10, 10, 10, 11, ExpectedResult = true)]
        [TestCase(10, 10, 0, 0, ExpectedResult = true)]
        public bool IsOutsideOfBoard_ReturnsExpectedResult(int boardHeight, int boardWidth, int x, int y)
        {
            // Arrange
            var endCoordinates = Coordinates.Create(x, y);

            // Act
            var isOutside = endCoordinates.IsOutsideOfBoard(boardHeight, boardWidth);

            // Assert
            return isOutside;
        }

        [TestCase(1, 1, 3, 1, 1, 2, 3, 2, ExpectedResult = false)]
        [TestCase(3, 3, 5, 3, 3, 3, 3, 7, ExpectedResult = true)]
        [TestCase(5, 1, 5, 10, 1, 5, 10, 5, ExpectedResult = true)]
        [TestCase(1, 9, 10, 9, 1, 1, 10, 1, ExpectedResult = false)]
        public bool CheckIfShipsOverlap_ReturnsExpectedResult(
            int existingStartX, int existingStartY, int existingEndX, int existingEndY,
            int startCoordsX, int startCoordsY, int endCoordsX, int endCoordsY)
        {
            // Arrange
            var existingStartCoords = Coordinates.Create(existingStartX, existingStartY);
            var existingEndCoords = Coordinates.Create(existingEndX, existingEndY);
            var startCoords = Coordinates.Create(startCoordsX, startCoordsY);
            var endCoords = Coordinates.Create(endCoordsX, endCoordsY);

            // Act
            var isOverlap =
                ShipCoordinatesExtensions.CheckIfShipsOverlap(existingStartCoords, existingEndCoords, startCoords,
                    endCoords);

            // Assert
            return isOverlap;
        }
    }
}