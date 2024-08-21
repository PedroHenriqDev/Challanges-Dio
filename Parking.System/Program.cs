using Parking.Domain.Entities;

namespace Parking.System;

class Progam
{
    static List<Space> parking = new List<Space>();
    static bool continueProgam = true;

    public static void Main(string[] args)
    {

        Console.WriteLine("-- Welcome to Parking System --");
        PressToContinue();

        Console.Write("Enter the entrance fee at the parking lot: ");
        int initialValue = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the value per hour: ");
        int valuePerHour = Convert.ToInt32(Console.ReadLine());

        do
        {
            Console.Clear();

            Console.WriteLine("1- Register Vehicle");
            Console.WriteLine("2- List Vehicles");
            Console.WriteLine("3- Remove Vehicle");
            Console.WriteLine("4- Exit");

            int.TryParse(Console.ReadLine(), out int userChoice);

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Insert vehicle plate: ");

                    Vehicle vehicle = new Vehicle(Console.ReadLine());
                    parking.Add(new Space
                    {
                        Vehicle = vehicle,
                        InitialValue = initialValue,
                        ValuePerHour = valuePerHour
                        
                    });
                    PressToContinue();
                    break;
                case 2:
                    foreach (var space in parking)
                    {
                        Console.WriteLine($"Vehicle plate - {space.Vehicle.Plate}");
                    }
                    PressToContinue();
                    break;
                case 3:
                    Console.Write("Enter vehicle plate to remove: ");
                    string vehiclePlate = Console.ReadLine();
                    Space spaceToDelete = parking.FirstOrDefault(space => space.Vehicle.Plate == vehiclePlate);
                  
                    if(spaceToDelete is null) 
                    {
                        Console.WriteLine("Not found vehicle");
                        PressToContinue();
                        break;
                    }

                    parking.Remove(spaceToDelete);

                    Console.Write("How many hours was the vehicle in the parking space?");
                    int.TryParse(Console.ReadLine(), out int busyHours);
                    Console.WriteLine($"The amount to be paid is: {spaceToDelete.AmountToPaid(busyHours)}");
                    PressToContinue();
                    break;
                case 4:
                    continueProgam = false;
                    break;
                default:
                    Console.WriteLine("The number entered must be from 1 to 4");
                    PressToContinue();
                    break;
            }


        }
        while (continueProgam);
    }

    public static void PressToContinue() 
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}