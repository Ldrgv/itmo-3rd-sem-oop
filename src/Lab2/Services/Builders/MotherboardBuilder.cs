using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class MotherboardBuilder : IBuilder<Motherboard>
{
    private string? _name;
    private string? _formFactor;
    private string? _cpuSocket;
    private int _ddrStandard;
    private RamFormFactor? _ramFormFactor;
    private int _ramCount;
    private int _maxRamSize;
    private IEnumerable<int>? _operatingRamFrequencies;
    private string? _pcieVersion;
    private int _pcieCount;
    private int _sataCount;
    private Bios? _bios;

    public MotherboardBuilder()
    {
    }

    public MotherboardBuilder(Motherboard motherboard)
    {
        if (motherboard == null) throw new ArgumentNullException(nameof(motherboard));

        _name = motherboard.Name;
        _formFactor = motherboard.FormFactor;
        _cpuSocket = motherboard.CpuSocket;
        _ddrStandard = motherboard.DdrStandard;
        _ramFormFactor = motherboard.RamFormFactor;
        _ramCount = motherboard.RamCount;
        _maxRamSize = motherboard.MaxRamSize;
        _operatingRamFrequencies = motherboard.RamOperatingFrequencies;
        _pcieVersion = motherboard.PcieVersion;
        _pcieCount = motherboard.PcieCount;
        _sataCount = motherboard.SataCount;
        _bios = motherboard.Bios;
    }

    public MotherboardBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public MotherboardBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public MotherboardBuilder WithCpuSocket(string cpuSocket)
    {
        _cpuSocket = cpuSocket;

        return this;
    }

    public MotherboardBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;

        return this;
    }

    public MotherboardBuilder WithRamFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;

        return this;
    }

    public MotherboardBuilder WithRamCount(int ramCount)
    {
        _ramCount = ramCount;

        return this;
    }

    public MotherboardBuilder WithMaxRamSize(int maxRamSize)
    {
        _maxRamSize = maxRamSize;

        return this;
    }

    public MotherboardBuilder WithOperatingFrequencies(IEnumerable<int> operatingFrequencies)
    {
        _operatingRamFrequencies = operatingFrequencies.ToList();

        return this;
    }

    public MotherboardBuilder WithPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;

        return this;
    }

    public MotherboardBuilder WithPcieCount(int pcieCount)
    {
        _pcieCount = pcieCount;

        return this;
    }

    public MotherboardBuilder WithSataCount(int sataCount)
    {
        _sataCount = sataCount;

        return this;
    }

    public MotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;

        return this;
    }

    public Motherboard Build()
    {
        var motherboard = new Motherboard(
            _name ?? throw new ArgumentNullException(),
            _formFactor ?? throw new ArgumentNullException(),
            _cpuSocket ?? throw new ArgumentNullException(),
            _ddrStandard,
            _ramFormFactor ?? throw new ArgumentNullException(),
            _ramCount,
            _maxRamSize,
            _operatingRamFrequencies ?? throw new ArgumentNullException(),
            _pcieVersion ?? throw new ArgumentNullException(),
            _pcieCount,
            _sataCount,
            _bios ?? throw new ArgumentNullException());

        new MotherboardValidator().Validate(motherboard);

        return motherboard;
    }
}