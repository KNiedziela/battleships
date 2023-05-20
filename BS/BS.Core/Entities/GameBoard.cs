using BS.Core.Entities.Ships;
using BS.Core.Helpers;
using FluentResults;

namespace BS.Core.Entities;

public class GameBoard
{
    public int Height { get; set; }
    public int Width { get; set; }
    public List<Ship> Ships { get; set; } = new();
    public List<ShotHistory> ShotsHistory { get; set; } = new();

    public bool AllShipsDefeated() => Ships.All(s => s.IsAlive == false);
    public List<Ship> GetAliveShips() => Ships.Where(s => s.IsAlive).ToList();

    public static GameBoard Create(int height, int width)
    {
        return new GameBoard
        {
            Height = height,
            Width = width
        };
    }

    public void PlaceShip(Ship ship)
    {
        var shipPosition = GetShipPosition(ship, Height, Width);
        ship.StartCoordinates = shipPosition.Item1;
        ship.EndCoordinates = shipPosition.Item2;

        Ships.Add(ship);
    }

    public void AddShot(Coordinates coords, bool isHit) => ShotsHistory.Add(ShotHistory.Create(coords, isHit));

    public Tuple<Coordinates, Coordinates> GetShipPosition(Ship ship, int boardHeight, int boardWidth)
    {
        var startCoords = ShipCoordinatesRandpomizationHelper.GetRandomBoardCoordinate(boardHeight, boardWidth);
        var isHorizontal = ShipCoordinatesRandpomizationHelper.GetRandomOrientation();
        var endCoords = startCoords.GetShipEndCoordinates(isHorizontal, ship.Length);

        if (!endCoords.IsOutsideOfBoard(boardHeight, boardWidth) && CanPlaceShipAtPosition(startCoords, endCoords))
        {
            return new Tuple<Coordinates, Coordinates>(startCoords, endCoords);
        }

        return GetShipPosition(ship, boardHeight, boardWidth);
    }

    private bool CanPlaceShipAtPosition(Coordinates startCoords, Coordinates endCoords)
    {
        return Ships.All(existingShip => !ShipCoordinatesExtensions.CheckIfShipsOverlap(existingShip.StartCoordinates, existingShip.EndCoordinates, startCoords, endCoords));
    }

    public bool CheckIfShotWasAlreadyTaken(Coordinates coordinates)
    {
        return ShotsHistory.Any(s => s.Coordinates.X.Equals(coordinates.X) && s.Coordinates.Y.Equals(coordinates.Y));
    }
}