using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Repositories;

public class BoardRepository : IBoardRepository
{
    private static GameBoard? _gameBoard;
    public Result AddGameBoard(GameBoard board)
    {
        _gameBoard = board;
        return Result.Ok();
    }

    public Result<GameBoard> GetGameBoard()
    {
        if (_gameBoard is null)
        {
            return Result.Fail("No game board initialized");
        }

        return _gameBoard;
    }
}