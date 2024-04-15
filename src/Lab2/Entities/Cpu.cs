namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IName, IPowerable
{
    internal Cpu(
        string name,
        string socket,
        int coreCount,
        double clockSpeed,
        string? integratedGraphics,
        int maxRamSpeed,
        int tdp,
        double powerConsumption)
    {
        Name = name;
        ClockSpeed = clockSpeed;
        CoreCount = coreCount;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        MaxRamSpeed = maxRamSpeed;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public double ClockSpeed { get; }
    public int CoreCount { get; }
    public string Socket { get; }
    public string? IntegratedGraphics { get; }
    public int MaxRamSpeed { get; }
    public int Tdp { get; }
    public double PowerConsumption { get; }
}