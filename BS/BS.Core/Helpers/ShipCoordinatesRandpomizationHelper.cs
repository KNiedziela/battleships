using BS.Core.Entities;

namespace BS.Core.Helpers;

public class ShipCoordinatesRandpomizationHelper
{
    private static readonly Random Random = new Random();

    public static bool GetRandomOrientation()
    {
        return Random.Next(2) == 0;
    }
    public static Coordinates GetRandomBoardCoordinate(int height, int width)
    {
        var x = Random.Next(1, width + 1);
        var y = Random.Next(1, height + 1);

        return Coordinates.Create(x, y);
    }
}