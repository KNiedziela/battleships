using BS.Core.Entities;
using FluentResults;

namespace BS.Core.Helpers;

public static class CoordinatesParser
{
    public static Result<Coordinates> ParseCoordinates(string coordinates)
    {
        if (string.IsNullOrEmpty(coordinates) || !char.IsLetter(coordinates.First()) || !coordinates.Skip(1).All(char.IsDigit))
        {
            return Result.Fail(
                $"{coordinates} are invalid coordinates, use correct ones, starting with a letter and ending with digits e.g. A5");
        }

        var x = char.ToUpper(coordinates.First()) - 'A' + 1;
        if (!int.TryParse(coordinates.Substring(1), out int y))
        {
            return Result.Fail(
                $"{coordinates} has an invalid number.");
        }

        return Result.Ok(Coordinates.Create(x, y));
    }
}