namespace Parking.Domain.Entities;

public class Vehicle
{
    public string? Plate {  get; private set; }

    public Vehicle(string plate)
    {
        Plate = plate;
    }
}
