using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Services;

public class BoardService : IBoardService
{
    private const int MinimumBoardSize = 5;
    public Result<GameBoard> InitializeBoard(int size)
    {
        if (size < MinimumBoardSize)
        {
            return Result.Fail($"Minimum board size is: {MinimumBoardSize}");
        }
        var board = GameBoard.Create(size, size);

        return Result.Ok(board);
    }
}