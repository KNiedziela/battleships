namespace BS.Core.Entities;

public class GameBoard
{
    public int Height { get; set; }
    public int Width { get; set; }
    public List<Ship> Ships { get; set; } = new();
    public List<ShootHistory> ShootHistory { get; set; } = new();

    public static GameBoard Create(int height, int width)
    {
        return new GameBoard
        {
            Height = height,
            Width = width
        };
    }
}