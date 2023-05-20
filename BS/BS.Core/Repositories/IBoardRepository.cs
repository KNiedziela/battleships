using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Repositories;

public interface IBoardRepository
{
    Result AddGameBoard(GameBoard board);
    Result<GameBoard> GetGameBoard();
}