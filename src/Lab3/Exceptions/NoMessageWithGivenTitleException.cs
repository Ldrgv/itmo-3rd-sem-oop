using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NoMessageWithGivenTitleException : Exception
{
    public NoMessageWithGivenTitleException()
    {
    }

    public NoMessageWithGivenTitleException(string message)
        : base(message)
    {
    }

    public NoMessageWithGivenTitleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}