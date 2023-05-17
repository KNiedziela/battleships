namespace BS.Core.Entities;

public struct Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Coordinates Create(int x, int y) => new() { X = x, Y = y };
}