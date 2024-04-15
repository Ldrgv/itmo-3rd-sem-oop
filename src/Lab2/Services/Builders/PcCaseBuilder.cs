using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class PcCaseBuilder : IBuilder<PcCase>
{
    private string? _name;
    private int _length;
    private int _width;
    private int _height;
    private List<string>? _compatibleMotherboardFormFactors;
    private int _graphicsCardMaxLength;

    public PcCaseBuilder() { }

    public PcCaseBuilder(PcCase pcCase)
    {
        if (pcCase == null) throw new ArgumentNullException(nameof(pcCase));

        _name = pcCase.Name;
        _length = pcCase.Length;
        _width = pcCase.Width;
        _height = pcCase.Height;
        _compatibleMotherboardFormFactors = pcCase.CompatibleMotherboardFormFactors.ToList();
        _graphicsCardMaxLength = pcCase.GraphicsCardMaxLength;
    }

    public PcCaseBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public PcCaseBuilder WithLength(int length)
    {
        _length = length;

        return this;
    }

    public PcCaseBuilder WithWidth(int width)
    {
        _width = width;

        return this;
    }

    public PcCaseBuilder WithHeight(int height)
    {
        _height = height;

        return this;
    }

    public PcCaseBuilder WithCompatibleMotherboardFormFactor(string motherboardFormFactor)
    {
        _compatibleMotherboardFormFactors ??= new List<string>();

        _compatibleMotherboardFormFactors.Add(motherboardFormFactor);

        return this;
    }

    public PcCaseBuilder WithCompatibleMotherboardFormFactors(IEnumerable<string> motherboardFormFactors)
    {
        _compatibleMotherboardFormFactors = motherboardFormFactors.ToList();

        return this;
    }

    public PcCaseBuilder WithGraphicsCardMaxLength(int graphicsCardMaxLength)
    {
        _graphicsCardMaxLength = graphicsCardMaxLength;

        return this;
    }

    public PcCase Build()
    {
        var pcCase = new PcCase(
            _name ?? throw new ArgumentNullException(),
            _length,
            _width,
            _height,
            _compatibleMotherboardFormFactors ?? throw new ArgumentNullException(),
            _graphicsCardMaxLength);

        new PcCaseValidator().Validate(pcCase);

        return pcCase;
    }
}