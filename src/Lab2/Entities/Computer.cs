using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    internal Computer(
        Motherboard motherboard,
        Cpu cpu,
        Cooler cooler,
        IEnumerable<Ram> rams,
        GraphicsCard? graphicsCard,
        Ssd? ssd,
        Hdd? hdd,
        PcCase pcCase,
        PowerSupply powerSupply)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Cooler = cooler;
        Rams = rams.ToList();
        GraphicsCard = graphicsCard;
        Ssd = ssd;
        Hdd = hdd;
        PcCase = pcCase;
        PowerSupply = powerSupply;
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public Cooler Cooler { get; }
    public IReadOnlyList<Ram> Rams { get; }
    public GraphicsCard? GraphicsCard { get; }
    public Ssd? Ssd { get; }
    public Hdd? Hdd { get; }
    public PcCase PcCase { get; }
    public PowerSupply PowerSupply { get; }

    public double PowerConsumtion
    {
        get
        {
            double powerConsumption =
                Cpu.PowerConsumption +
                GraphicsCard?.PowerConsumption ?? 0 +
                Ssd?.PowerConsumption ?? 0 +
                Hdd?.PowerConsumption ?? 0;

            foreach (Ram ram in Rams)
            {
                powerConsumption += ram.PowerConsumption;
            }

            return powerConsumption;
        }
    }
}