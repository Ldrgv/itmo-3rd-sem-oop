using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class BiosBuilder
{
    private string? _type;
    private string? _version;
    private List<string>? _compatibleCpuNames;

    public BiosBuilder()
    {
    }

    public BiosBuilder(Bios bios)
    {
        if (bios == null) throw new ArgumentNullException(nameof(bios));

        _type = bios.Type;
        _version = bios.Version;
        _compatibleCpuNames = bios.CompatibleCpuNames.ToList();
    }

    public BiosBuilder WithType(string type)
    {
        _type = type;

        return this;
    }

    public BiosBuilder WithVersion(string version)
    {
        _version = version;

        return this;
    }

    public BiosBuilder WithCompatibleCpu(string cpuName)
    {
        _compatibleCpuNames ??= new List<string>();

        _compatibleCpuNames.Add(cpuName);

        return this;
    }

    public BiosBuilder WithCompatibleCpus(IEnumerable<string> cpuNames)
    {
        _compatibleCpuNames = cpuNames.ToList();

        return this;
    }

    public Bios Build()
    {
        var bios = new Bios(
            _type ?? throw new ArgumentNullException(),
            _version ?? throw new ArgumentNullException(),
            _compatibleCpuNames ?? throw new ArgumentNullException());

        new BiosValidator().Validate(bios);

        return bios;
    }
}