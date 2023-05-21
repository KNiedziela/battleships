using BS.Core.Entities;
using BS.Core.Entities.Ships;

namespace BS.Common.Builders.Builders;

public static class GameBoardBuilder
{
    public static GameBoard Build(int size)
    {
        return GameBoard.Create(size, size);
    }
    public static GameBoard WithShip(this GameBoard entity, Ship ship)
    {
        entity.Ships.Add(ship);

        return entity;
    }
    public static GameBoard WithShotHistoryEntry(this GameBoard entity, Coordinates coordinates, bool isHit = false)
    {
        entity.AddShot(coordinates, isHit);

        return entity;
    }
}