using BS.Core.Models;
using FluentResults;

namespace BS.Core.Services;

public interface IGameService
{
    public Result StartGame();
    public Result TakeShot(TakeShootInputModel inputModel);
}