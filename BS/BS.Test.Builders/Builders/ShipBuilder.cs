using BS.Core.Entities;
using BS.Core.Entities.Ships;
using BS.Core.Helpers;

namespace BS.Common.Builders.Builders;

public static class ShipBuilder
{
    public static Destroyer BuildDestroyer()
    {
        return Destroyer.Create();
    }
    public static Battleship BuildBattleship()
    {
        return Battleship.Create();
    }

    public static Ship WithCoordinates(this Ship entity, Coordinates coordinates, bool isHorizontal)
    {
        entity.StartCoordinates = coordinates;
        entity.EndCoordinates = coordinates.GetShipEndCoordinates(isHorizontal, entity.Length);

        return entity;
    }
    public static Ship WithHitPoints(this Ship entity, int amount)
    {
        entity.HitPoints = amount;

        return entity;
    }

}