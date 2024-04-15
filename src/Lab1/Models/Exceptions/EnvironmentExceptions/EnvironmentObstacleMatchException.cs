using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Exceptions.EnvironmentExceptions;

public class EnvironmentObstacleMatchException : Exception
{
    public EnvironmentObstacleMatchException()
    {
    }

    public EnvironmentObstacleMatchException(string message)
        : base(message)
    {
    }

    public EnvironmentObstacleMatchException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}