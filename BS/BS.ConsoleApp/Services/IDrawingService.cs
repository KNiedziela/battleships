using BS.Core.Entities;

namespace BS.ConsoleApp.Services;

public interface IDrawingService
{
    void DrawBoard(int boardSize, List<ShotHistory> shotHistory);
}