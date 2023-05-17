using BS.Core.Helpers;

namespace BS.Core.Entities.Ships;

public class Battleship : Ship
{
    private const int ShipLength = 5;

    public static Battleship Create(Coordinates startCoordinates, bool isHorizontal)
    {
        var ship = new Battleship
        {
            HitPoints = ShipLength,
            ShipType = ShipType.Battleship,
            StartCoordinates = startCoordinates,
            EndCoordinates = startCoordinates.GetShipEndCoordinates(isHorizontal, ShipLength)
        };

        return ship;
    }
}