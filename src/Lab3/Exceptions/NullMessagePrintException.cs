using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NullMessagePrintException : Exception
{
    public NullMessagePrintException()
    {
    }

    public NullMessagePrintException(string message)
        : base(message)
    {
    }

    public NullMessagePrintException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}