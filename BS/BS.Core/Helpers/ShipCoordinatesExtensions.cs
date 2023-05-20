using BS.Core.Entities;
using GeometRi;

namespace BS.Core.Helpers;

public static class ShipCoordinatesExtensions
{
    public static Coordinates GetShipEndCoordinates(this Coordinates startCoordinates, bool isHorizontal, int shipLength)
    {
        if (isHorizontal)
        {
            return startCoordinates with { X = startCoordinates.X + shipLength };
        }

        return startCoordinates with { Y = startCoordinates.Y + shipLength };
    }
    public static bool IsOutsideOfBoard(this Coordinates endCoordinates, int boardHeight, int boardWidth)
    {
        if (endCoordinates.X < 1 || endCoordinates.Y < 1)
        {
            return true;
        }
        return endCoordinates.X > boardHeight || endCoordinates.Y > boardWidth;
    }
    public static bool CheckIfShipsOverlap(Coordinates existingStartCoords, Coordinates existingEndCoords, Coordinates startCoords, Coordinates endCoords)
    {
        var existing = new Line3d(existingStartCoords.ToPoint3D(), existingEndCoords.ToPoint3D());
        var candidate = new Line3d(startCoords.ToPoint3D(), endCoords.ToPoint3D());
        var isIntersecting = existing.IntersectionWith(candidate) is not null;

        return isIntersecting;
    }

    public static bool CheckIfShipsOverlap(Coordinates existingStartCoords, Coordinates existingEndCoords,
        Coordinates coord) =>
        CheckIfShipsOverlap(existingStartCoords, existingEndCoords, coord, coord
             );


    public static Point3d ToPoint3D(this Coordinates coord) => new(coord.X, coord.Y, 0);
}