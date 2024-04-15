using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class GraphicsCardBuilder : IBuilder<GraphicsCard>
{
    private string? _name;
    private int _memorySize;
    private int _clockSpeed;
    private string? _pcieVersion;
    private double _powerConsumption;
    private int _length;
    private int _height;

    public GraphicsCardBuilder() { }

    public GraphicsCardBuilder(GraphicsCard graphicsCard)
    {
        if (graphicsCard == null) throw new ArgumentNullException(nameof(graphicsCard));

        _name = graphicsCard.Name;
        _memorySize = graphicsCard.MemorySize;
        _clockSpeed = graphicsCard.ClockSpeed;
        _pcieVersion = graphicsCard.PcieVersion;
        _powerConsumption = graphicsCard.PowerConsumption;
        _length = graphicsCard.Length;
        _height = graphicsCard.Height;
    }

    public GraphicsCardBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public GraphicsCardBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;

        return this;
    }

    public GraphicsCardBuilder WithClockSpeed(int clockSpeed)
    {
        _clockSpeed = clockSpeed;

        return this;
    }

    public GraphicsCardBuilder WithPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;

        return this;
    }

    public GraphicsCardBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;

        return this;
    }

    public GraphicsCardBuilder WithLength(int length)
    {
        _length = length;

        return this;
    }

    public GraphicsCardBuilder WithHeight(int height)
    {
        _height = height;

        return this;
    }

    public GraphicsCard Build()
    {
        var graphicsCard = new GraphicsCard(
            _name ?? throw new ArgumentNullException(),
            _memorySize,
            _clockSpeed,
            _pcieVersion ?? throw new ArgumentNullException(),
            _powerConsumption,
            _length,
            _height);

        new GraphicsCardValidator().Validate(graphicsCard);

        return graphicsCard;
    }
}