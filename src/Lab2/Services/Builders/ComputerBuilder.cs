using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class ComputerBuilder : IBuilder<Computer>
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private Cooler? _cooler;
    private List<Ram>? _rams;
    private GraphicsCard? _graphicsCard;
    private Ssd? _ssd;
    private Hdd? _hdd;
    private PcCase? _pcCase;
    private PowerSupply? _powerSupply;

    public ComputerBuilder()
    {
    }

    public ComputerBuilder(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        _motherboard = computer.Motherboard;
        _cpu = computer.Cpu;
        _cooler = computer.Cooler;
        _rams = computer.Rams.ToList();
        _graphicsCard = computer.GraphicsCard;
        _ssd = computer.Ssd;
        _hdd = computer.Hdd;
        _pcCase = computer.PcCase;
        _powerSupply = computer.PowerSupply;
    }

    public ComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public ComputerBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;

        return this;
    }

    public ComputerBuilder WithCooler(Cooler cooler)
    {
        _cooler = cooler;

        return this;
    }

    public ComputerBuilder WithRam(Ram ram)
    {
        _rams ??= new List<Ram>();

        _rams.Add(ram);

        return this;
    }

    public ComputerBuilder WithRams(IEnumerable<Ram> rams)
    {
        _rams = rams.ToList();

        return this;
    }

    public ComputerBuilder WithGraphicsCard(GraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;

        return this;
    }

    public ComputerBuilder WithSsd(Ssd ssd)
    {
        _ssd = ssd;

        return this;
    }

    public ComputerBuilder WithHdd(Hdd hdd)
    {
        _hdd = hdd;

        return this;
    }

    public ComputerBuilder WithCase(PcCase pcCase)
    {
        _pcCase = pcCase;

        return this;
    }

    public ComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;

        return this;
    }

    public Computer Build()
    {
        var computer = new Computer(
            _motherboard ?? throw new ArgumentNullException(),
            _cpu ?? throw new ArgumentNullException(),
            _cooler ?? throw new ArgumentNullException(),
            _rams ?? throw new ArgumentNullException(),
            _graphicsCard,
            _ssd,
            _hdd,
            _pcCase ?? throw new ArgumentNullException(),
            _powerSupply ?? throw new ArgumentNullException());

        new ComputerValidator().Validate(computer);

        return computer;
    }
}