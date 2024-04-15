using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class HddBuilder : IBuilder<Hdd>
{
    private string? _name;
    private int _memorySize;
    private int _rpm;
    private double _powerConsumption;

    public HddBuilder() { }

    public HddBuilder(Hdd hdd)
    {
        if (hdd == null) throw new ArgumentNullException(nameof(hdd));

        _name = hdd.Name;
        _memorySize = hdd.MemorySize;
        _rpm = hdd.Rpm;
        _powerConsumption = hdd.PowerConsumption;
    }

    public HddBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public HddBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;

        return this;
    }

    public HddBuilder WithRpm(int rpm)
    {
        _rpm = rpm;

        return this;
    }

    public HddBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;

        return this;
    }

    public Hdd Build()
    {
        var hdd = new Hdd(
            _name ?? throw new ArgumentNullException(),
            _memorySize,
            _rpm,
            _powerConsumption);

        new HddValidator().Validate(hdd);

        return hdd;
    }
}