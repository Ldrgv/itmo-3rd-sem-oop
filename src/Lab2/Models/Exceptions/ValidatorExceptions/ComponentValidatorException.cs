using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

public class ComponentValidatorException : Exception
{
    public ComponentValidatorException()
    {
    }

    public ComponentValidatorException(string message)
        : base(message)
    {
    }

    public ComponentValidatorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}