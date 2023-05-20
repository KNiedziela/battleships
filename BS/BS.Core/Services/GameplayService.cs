using BS.Core.Entities.Ships;
using BS.Core.Models;
using BS.Core.Repositories;
using FluentResults;

namespace BS.Core.Services;

public class GameplayService : IGameplayService
{
    private readonly IBoardGenerationService _boardGenerationService;
    private readonly IBoardRepository _boardRepository;
    private readonly IShipFactory _shipFactory;

    public GameplayService(IBoardGenerationService boardGenerationService, IBoardRepository boardRepository, IShipFactory shipFactory)
    {
        _boardGenerationService = boardGenerationService;
        _boardRepository = boardRepository;
        _shipFactory = shipFactory;
    }

    public Result StartGame(Dictionary<ShipType, int> ships)
    {
        var newBoardResult = _boardGenerationService.InitializeBoard(10);
        if (newBoardResult.IsFailed)
        {
            return Result.Fail(newBoardResult.Errors);
        }

        var board = newBoardResult.Value;

        var builtShips = ships.SelectMany(pair => BuildShips(pair.Key, pair.Value)).ToList();
        builtShips.ForEach(board.PlaceShip);

        var addingResult = _boardRepository.AddGameBoard(newBoardResult.Value);
        if (addingResult.IsFailed)
        {
            return Result.Fail(addingResult.Errors);
        }

        return Result.Ok();
    }

    private IEnumerable<Ship> BuildShips(ShipType type, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var ship = _shipFactory.CreateShip(type);
            yield return ship;
        }
    }

    public Result TakeShot(TakeShootInputModel inputModel)
    {
        // TODO implement parsing

        var boardResult = _boardRepository.GetGameBoard();
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors);
        }
        var board = boardResult.Value;

        // TODO implement take shot

        return Result.Ok();
    }

    public Result<List<Ship>> GetAliveShips()
    {
        var boardResult = _boardRepository.GetGameBoard();
        if (boardResult.IsFailed)
        {
            return Result.Fail(boardResult.Errors);
        }
        var board = boardResult.Value;
        var shipsAlive = board.Ships.Where(s => s.IsAlive).ToList();

        return Result.Ok(shipsAlive);
    }
}