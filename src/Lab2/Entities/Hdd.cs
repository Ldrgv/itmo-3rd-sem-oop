namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IName, IPowerable
{
    internal Hdd(
        string name,
        int memorySize,
        int rpm,
        double powerConsumption)
    {
        Name = name;
        MemorySize = memorySize;
        Rpm = rpm;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public int Rpm { get; }
    public double PowerConsumption { get; }
}