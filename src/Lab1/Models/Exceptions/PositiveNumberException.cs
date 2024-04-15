using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Exceptions;

public class PositiveNumberException : Exception
{
    public PositiveNumberException()
    {
    }

    public PositiveNumberException(string message)
        : base(message)
    {
    }

    public PositiveNumberException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}