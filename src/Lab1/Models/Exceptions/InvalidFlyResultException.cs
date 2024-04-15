using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Exceptions;

public class InvalidFlyResultException : Exception
{
    public InvalidFlyResultException()
    {
    }

    public InvalidFlyResultException(string message)
        : base(message)
    {
    }

    public InvalidFlyResultException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}