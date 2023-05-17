using BS.Core.Entities;

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

}