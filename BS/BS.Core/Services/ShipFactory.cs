using BS.Core.Entities;
using BS.Core.Entities.Ships;
using FluentResults;

namespace BS.Core.Services;

public class ShipFactory : IShipFactory
{
    public Ship CreateShip(ShipType type)
    {
        switch (type)
        {
            case ShipType.Battleship:
                return Battleship.Create();
            case ShipType.Destroyer:
                return Destroyer.Create();
            default:
                throw new ArgumentException($"Ship type: {type} not supported");
        }
    }
}