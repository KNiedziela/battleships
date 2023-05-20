using BS.Core.Entities.Ships;
using FluentResults;

namespace BS.Core.Services;

public interface IShipFactory
{
    Ship CreateShip(ShipType type);
}