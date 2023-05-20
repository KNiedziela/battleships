namespace BS.Core.Entities.Ships;

public abstract class Ship
{
    public ShipType ShipType { get; set; }
    public Coordinates StartCoordinates { get; set; }
    public Coordinates EndCoordinates { get; set; }
    public int HitPoints { get; set; }
    public bool IsAlive => HitPoints > 0;
    public int Length => HitPoints;
}