using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuBuilder : IBuilder<Cpu>
{
    private string? _name;
    private string? _socket;
    private int _coreCount;
    private double _clockSpeed;
    private string? _integratedGraphics;
    private int _maxRamSpeed;
    private int _tdp;
    private double _powerConsumption;

    public CpuBuilder()
    {
    }

    public CpuBuilder(Cpu cpu)
    {
        if (cpu == null) throw new ArgumentNullException(nameof(cpu));

        _name = cpu.Name;
        _socket = cpu.Socket;
        _coreCount = cpu.CoreCount;
        _clockSpeed = cpu.ClockSpeed;
        _integratedGraphics = cpu.IntegratedGraphics;
        _maxRamSpeed = cpu.MaxRamSpeed;
        _tdp = cpu.Tdp;
        _powerConsumption = cpu.PowerConsumption;
    }

    public CpuBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public CpuBuilder WithSocket(string socket)
    {
        _socket = socket;

        return this;
    }

    public CpuBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;

        return this;
    }

    public CpuBuilder WithClockSpeed(double clockSpeed)
    {
        _clockSpeed = clockSpeed;

        return this;
    }

    public CpuBuilder WithIntegratedGraphics(string integratedGraphics)
    {
        _integratedGraphics = integratedGraphics;

        return this;
    }

    public CpuBuilder WithMaxRamSpeed(int maxRamSpeed)
    {
        _maxRamSpeed = maxRamSpeed;

        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;

        return this;
    }

    public CpuBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;

        return this;
    }

    public Cpu Build()
    {
        var cpu = new Cpu(
            _name ?? throw new ArgumentNullException(),
            _socket ?? throw new ArgumentNullException(),
            _coreCount,
            _clockSpeed,
            _integratedGraphics,
            _maxRamSpeed,
            _tdp,
            _powerConsumption);

        new CpuValidator().Validate(cpu);

        return cpu;
    }
}