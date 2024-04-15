namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GraphicsCard : IName, IPowerable
{
    internal GraphicsCard(
        string name,
        int memorySize,
        int clockSpeed,
        string pcieVersion,
        double powerConsumption,
        int length,
        int height)
    {
        Name = name;
        MemorySize = memorySize;
        ClockSpeed = clockSpeed;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
        Length = length;
        Height = height;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public int ClockSpeed { get; }
    public string PcieVersion { get; }
    public double PowerConsumption { get; }
    public int Length { get; }
    public int Height { get; }
}