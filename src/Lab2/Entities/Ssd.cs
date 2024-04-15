using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IName, IPowerable
{
    internal Ssd(
        string name,
        DriveConnectivityTechnology connectivityTechnology,
        int memorySize,
        int speed,
        double powerConsumption)
    {
        Name = name;
        ConnectivityTechnology = connectivityTechnology;
        MemorySize = memorySize;
        Speed = speed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public DriveConnectivityTechnology ConnectivityTechnology { get; }
    public int MemorySize { get; }
    public int Speed { get; }
    public double PowerConsumption { get; }
}