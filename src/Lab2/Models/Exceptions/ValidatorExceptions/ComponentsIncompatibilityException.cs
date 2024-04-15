using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

public class ComponentsIncompatibilityException : Exception
{
    public ComponentsIncompatibilityException()
    {
    }

    public ComponentsIncompatibilityException(string message)
        : base(message)
    {
    }

    public ComponentsIncompatibilityException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}