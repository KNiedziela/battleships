using BS.Core.Entities.Ships;
using BS.Core.Models;
using BS.Core.Services;
using FluentResults;

namespace BS.ConsoleApp.Services;

public class ConsoleGameService : IConsoleGameService
{
    private readonly IGameplayService _gameplayService;
    private readonly IDrawingService _drawingService;
    private readonly Dictionary<ShipType, int> _ships = new Dictionary<ShipType, int>()
    {
        { ShipType.Battleship,1},
        { ShipType.Destroyer,2},
    };
    private bool _gameFinished = false;
    private const int BoardSize = 10;

    public ConsoleGameService(IGameplayService gameplayService, IDrawingService drawingService)
    {
        _gameplayService = gameplayService;
        _drawingService = drawingService;
    }

    public void RunConsoleGameLoop()
    {
        _gameplayService.StartGame(BoardSize, _ships);
        Console.WriteLine("Battleships started!");

        while (_gameFinished is false)
        {
            var shotHistoryResult = _gameplayService.GetShotsHistory();
            HandleResultError(shotHistoryResult);
            if (shotHistoryResult.IsSuccess)
            {
                _drawingService.DrawBoard(BoardSize, shotHistoryResult.Value);
            }

            Console.WriteLine("Enter your target field");
            var command = Console.ReadLine();
            var shotResult = _gameplayService.TakeShot(new TakeShootInputModel { TargetField = command });
            HandleResultError(shotResult);
            if (shotResult.IsSuccess)
            {
                Console.WriteLine(shotResult.Value ? "Its a Hit!" : "Its a miss!");
            }

            var isFinishedResult = _gameplayService.IsGameFinished();
            HandleResultError(isFinishedResult);
            if (isFinishedResult.IsSuccess && isFinishedResult.Value)
            {
                Console.WriteLine("All ships defeated, you won!");
                _gameFinished = true;
            }
        }
    }

    private void HandleResultError<TType>(Result<TType> result)
    {
        if (result.IsFailed)
        {
            Console.WriteLine(string.Join(", ", result.Errors));
        }
    }
}