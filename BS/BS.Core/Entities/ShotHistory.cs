using BS.Core.Entities.Ships;

namespace BS.Core.Entities;

public class ShotHistory
{
    public Coordinates Coordinates { get; set; }
    public bool IsHit { get; set; }

    public static ShotHistory Create(Coordinates coords, bool isHit)
    {
        var shot = new ShotHistory
        {
            Coordinates = coords,
            IsHit = isHit,
        };

        return shot;
    }
}