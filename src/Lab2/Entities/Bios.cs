using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios
{
    private readonly List<string> _compatibleCpuNames;

    internal Bios(string type, string version, IEnumerable<string> compatibleCpuNames)
    {
        Type = type;
        Version = version;
        _compatibleCpuNames = compatibleCpuNames.ToList().ConvertAll(name => name.ToUpperInvariant());
    }

    public string Type { get; }
    public string Version { get; }
    public IReadOnlyCollection<string> CompatibleCpuNames => _compatibleCpuNames.AsReadOnly();
}