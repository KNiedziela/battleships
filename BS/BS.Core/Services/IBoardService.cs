using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Services;

public interface IBoardService
{
    public Result<GameBoard> InitializeBoard(int size);
}