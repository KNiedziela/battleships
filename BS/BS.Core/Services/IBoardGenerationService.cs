using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Services;

public interface IBoardGenerationService
{
    public Result<GameBoard> InitializeBoard(int size);
}