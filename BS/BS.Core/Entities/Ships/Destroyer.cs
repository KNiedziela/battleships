using BS.Core.Helpers;

namespace BS.Core.Entities.Ships;

public class Destroyer : Ship
{
    private const int ShipLength = 4;

    public static Destroyer Create(Coordinates startCoordinates, bool isHorizontal)
    {
        var ship = new Destroyer
        {
            HitPoints = ShipLength,
            ShipType = ShipType.Destroyer,
            StartCoordinates = startCoordinates,
            EndCoordinates = startCoordinates.GetShipEndCoordinates(isHorizontal, ShipLength)
        };

        return ship;
    }
}