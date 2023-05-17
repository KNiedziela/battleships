namespace BS.Core.Entities;

public class Ship
{
    public ShipType ShipType { get; set; }
    public Coordinates StartCoordinates { get; set; }
    public Coordinates EndCoordinates { get; set; }
    public bool IsAlive { get; set; }
    public List<Coordinates> TakenHits { get; set; } = new();
}