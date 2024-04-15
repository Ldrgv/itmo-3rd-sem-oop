using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class SsdBuilder : IBuilder<Ssd>
{
    private string? _name;
    private DriveConnectivityTechnology? _connectivityTechnology;
    private int _memorySize;
    private int _speed;
    private double _powerConsumption;

    public SsdBuilder() { }

    public SsdBuilder(Ssd ssd)
    {
        if (ssd == null) throw new ArgumentNullException(nameof(ssd));

        _name = ssd.Name;
        _connectivityTechnology = ssd.ConnectivityTechnology;
        _memorySize = ssd.MemorySize;
        _speed = ssd.Speed;
        _powerConsumption = ssd.PowerConsumption;
    }

    public SsdBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public SsdBuilder WithConnectivityTechnology(DriveConnectivityTechnology connectivityTechnology)
    {
        _connectivityTechnology = connectivityTechnology;

        return this;
    }

    public SsdBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;

        return this;
    }

    public SsdBuilder WithSpeed(int speed)
    {
        _speed = speed;

        return this;
    }

    public SsdBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;

        return this;
    }

    public Ssd Build()
    {
        var ssd = new Ssd(
            _name ?? throw new ArgumentNullException(),
            _connectivityTechnology ?? throw new ArgumentNullException(),
            _memorySize,
            _speed,
            _powerConsumption);

        new SsdValidator().Validate(ssd);

        return ssd;
    }
}