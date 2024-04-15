using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IName, IPowerable
{
    internal Ram(
        string name,
        int memorySize,
        int ddrStandard,
        RamFormFactor formFactor,
        double powerConsumption,
        Jedec jedec)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        MemorySize = memorySize;
        Jedec = jedec ?? throw new ArgumentNullException(nameof(jedec));
        FormFactor = formFactor;
        DdrStandard = ddrStandard;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public Jedec Jedec { get; }
    public RamFormFactor FormFactor { get; }
    public int DdrStandard { get; }
    public double PowerConsumption { get; }
}