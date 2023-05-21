using BS.Core.Entities;
using BS.Core.Entities.Ships;
using BS.Core.Models;
using FluentResults;

namespace BS.Core.Services;

public interface IGameplayService
{
    public Result StartGame(int boardSize, Dictionary<ShipType, int> ships);
    public Result<bool> TakeShot(TakeShootInputModel inputModel);
    public Result<List<Ship>> GetAliveShips();
    public Result<List<ShotHistory>> GetShotsHistory();
    public Result<bool> IsGameFinished();
}