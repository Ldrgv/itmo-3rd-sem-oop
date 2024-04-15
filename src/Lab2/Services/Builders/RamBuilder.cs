using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class RamBuilder : IBuilder<Ram>
{
    private string? _name;
    private int _memorySize;
    private int _ddrStandard;
    private RamFormFactor? _formFactor;
    private double _powerConsumption;
    private Jedec? _jedec;

    public RamBuilder() { }

    public RamBuilder(Ram ram)
    {
        if (ram == null) throw new ArgumentNullException(nameof(ram));

        _name = ram.Name;
        _memorySize = ram.MemorySize;
        _ddrStandard = ram.DdrStandard;
        _formFactor = ram.FormFactor;
        _powerConsumption = ram.PowerConsumption;
        _jedec = ram.Jedec;
    }

    public RamBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public RamBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;

        return this;
    }

    public RamBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;

        return this;
    }

    public RamBuilder WithFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public RamBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;

        return this;
    }

    public RamBuilder WithJedec(Jedec jedec)
    {
        _jedec = jedec;

        return this;
    }

    public Ram Build()
    {
        var ram = new Ram(
            _name ?? throw new ArgumentNullException(),
            _memorySize,
            _ddrStandard,
            _formFactor ?? throw new ArgumentNullException(),
            _powerConsumption,
            _jedec ?? throw new ArgumentNullException());

        new RamValidator().Validate(ram);

        return ram;
    }
}