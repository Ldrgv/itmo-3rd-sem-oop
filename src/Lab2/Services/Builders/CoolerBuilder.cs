using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CoolerBuilder : IBuilder<Cooler>
{
    private string? _name;
    private int _height;
    private int _width;
    private int _length;
    private int _tdp;
    private List<string>? _compatibleSockets;

    public CoolerBuilder() { }

    public CoolerBuilder(Cooler cooler)
    {
        if (cooler == null) throw new ArgumentNullException(nameof(cooler));

        _name = cooler.Name;
        _height = cooler.Height;
        _width = cooler.Width;
        _length = cooler.Lenght;
        _tdp = cooler.Tdp;
        _compatibleSockets = cooler.CompatibleSockets.ToList();
    }

    public CoolerBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public CoolerBuilder WithHeight(int height)
    {
        _height = height;

        return this;
    }

    public CoolerBuilder WithWidth(int width)
    {
        _width = width;

        return this;
    }

    public CoolerBuilder WithLength(int length)
    {
        _length = length;

        return this;
    }

    public CoolerBuilder WithTdp(int tdp)
    {
        _tdp = tdp;

        return this;
    }

    public CoolerBuilder WithCompatibleSocket(string compatibleSocket)
    {
        _compatibleSockets ??= new List<string>();

        _compatibleSockets.Add(compatibleSocket);

        return this;
    }

    public CoolerBuilder WithCompatibleSockets(IEnumerable<string> compatibleSockets)
    {
        _compatibleSockets = compatibleSockets.ToList();

        return this;
    }

    public Cooler Build()
    {
        var cooler = new Cooler(
            _name ?? throw new ArgumentNullException(),
            _height,
            _width,
            _length,
            _tdp,
            _compatibleSockets ?? throw new ArgumentNullException());

        new CoolerValidator().Validate(cooler);

        return cooler;
    }
}