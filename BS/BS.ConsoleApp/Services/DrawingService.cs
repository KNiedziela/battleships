using BS.Core.Entities;
using FluentResults;

namespace BS.ConsoleApp.Services;

public class DrawingService : IDrawingService
{
    public void DrawBoard(int boardSize, List<ShotHistory> shotHistory)
    {
        Console.Write("  ");
        for (int col = 1; col <= boardSize; col++)
        {
            Console.Write($"{col} ".PadLeft(3).PadRight(3));
        }
        Console.WriteLine();


        for (int row = 0; row < boardSize; row++)
        {
            Console.Write($"{(char)('A' + row)} ".PadLeft(2));

            for (int col = 1; col <= boardSize; col++)
            {
                var history = shotHistory.FirstOrDefault(s => s.Coordinates.Equals(Coordinates.Create(col, row + 1)));
                if (history is not null)
                {
                    var content = history.IsHit ? "X" : "O";
                    Console.Write($"[{content}]");
                }
                else
                {
                    Console.Write($"[ ]");
                }
            }
            Console.WriteLine();
        }
    }
}