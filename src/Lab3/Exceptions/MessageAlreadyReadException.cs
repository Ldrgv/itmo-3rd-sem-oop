using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageAlreadyReadException : Exception
{
    public MessageAlreadyReadException()
    {
    }

    public MessageAlreadyReadException(string message)
        : base(message)
    {
    }

    public MessageAlreadyReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}