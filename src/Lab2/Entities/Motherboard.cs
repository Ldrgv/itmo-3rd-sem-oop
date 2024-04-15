using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : IName
{
    internal Motherboard(
        string name,
        string formFactor,
        string cpuSocket,
        int ddrStandard,
        RamFormFactor ramFormFactor,
        int ramCount,
        int maxRamSize,
        IEnumerable<int> operatingRamFrequencies,
        string pcieVersion,
        int pcieCount,
        int sataCount,
        Bios bios)
    {
        Name = name;
        CpuSocket = cpuSocket;
        PcieCount = pcieCount;
        PcieVersion = pcieVersion;
        SataCount = sataCount;
        RamFormFactor = ramFormFactor;
        DdrStandard = ddrStandard;
        MaxRamSize = maxRamSize;
        RamOperatingFrequencies = operatingRamFrequencies.ToList().AsReadOnly();
        RamCount = ramCount;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Name { get; }
    public string CpuSocket { get; }
    public int PcieCount { get; }
    public string PcieVersion { get; }
    public int SataCount { get; }
    public RamFormFactor RamFormFactor { get; }
    public int DdrStandard { get; }
    public int MaxRamSize { get; }
    public IReadOnlyList<int> RamOperatingFrequencies { get; }
    public int RamCount { get; }
    public string FormFactor { get; }
    public Bios Bios { get; }
}