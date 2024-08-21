namespace Parking.Domain.Entities;

public class Space
{
    public Vehicle? Vehicle { get; set; }
    public int InitialValue {  get; set; }
    public int ValuePerHour { get; set; }

    public int AmountToPaid(int busyHours) 
    {
        return InitialValue + (busyHours * ValuePerHour);
    }
}
