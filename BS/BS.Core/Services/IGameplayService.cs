using BS.Core.Entities.Ships;
using BS.Core.Models;
using FluentResults;

namespace BS.Core.Services;

public interface IGameplayService
{
    public Result StartGame(Dictionary<ShipType, int> ships);
    public Result<bool> TakeShot(TakeShootInputModel inputModel);
    public Result<List<Ship>> GetAliveShips();
}