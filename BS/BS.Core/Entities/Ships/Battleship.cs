using BS.Core.Helpers;

namespace BS.Core.Entities.Ships;

public class Battleship : Ship
{
    public static Battleship Create()
    {
        var ship = new Battleship
        {
            HitPoints = 5,
            ShipType = ShipType.Battleship,
        };

        return ship;
    }
}