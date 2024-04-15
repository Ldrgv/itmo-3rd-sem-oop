using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cooler : IName
{
    internal Cooler(string name, int height, int width, int lenght, int tdp, IEnumerable<string> compatibleSockets)
    {
        Name = name;
        Height = height;
        Width = width;
        Lenght = lenght;
        Tdp = tdp;
        CompatibleSockets = compatibleSockets.ToList().AsReadOnly();
    }

    public string Name { get; }
    public int Height { get; }
    public int Width { get; }
    public int Lenght { get; }
    public int Tdp { get; }
    public IReadOnlyList<string> CompatibleSockets { get; }
}