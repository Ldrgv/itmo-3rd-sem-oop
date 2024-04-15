using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcCase : IName
{
    internal PcCase(
        string name,
        int length,
        int width,
        int height,
        IEnumerable<string> formFactors,
        int graphicsCardMaxLength)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Length = length;
        Width = width;
        Height = height;
        CompatibleMotherboardFormFactors = formFactors.ToList();
        GraphicsCardMaxLength = graphicsCardMaxLength;
    }

    public string Name { get; }

    public int Length { get; }
    public int Width { get; }
    public int Height { get; }

    public IReadOnlyList<string> CompatibleMotherboardFormFactors { get; }

    public int GraphicsCardMaxLength { get; }
}