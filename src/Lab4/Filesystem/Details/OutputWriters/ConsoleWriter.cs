using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details.OutputWriters;

public class ConsoleWriter : IOutputWriter
{
    public void Write(string info)
    {
        Console.WriteLine(info);
    }
}