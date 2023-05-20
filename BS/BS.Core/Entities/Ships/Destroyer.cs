using BS.Core.Helpers;

namespace BS.Core.Entities.Ships;

public class Destroyer : Ship
{
    public static Destroyer Create()
    {
        var ship = new Destroyer
        {
            HitPoints = 4,
            ShipType = ShipType.Destroyer,
        };

        return ship;
    }
}