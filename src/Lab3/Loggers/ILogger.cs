namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public interface ILogger
{
    void Log(LogLevel logLevel, string message);
}