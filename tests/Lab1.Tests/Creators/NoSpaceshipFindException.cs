using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;

public class NoSpaceshipFindException : Exception
{
    public NoSpaceshipFindException()
    {
    }

    public NoSpaceshipFindException(string message)
        : base(message)
    {
    }

    public NoSpaceshipFindException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}