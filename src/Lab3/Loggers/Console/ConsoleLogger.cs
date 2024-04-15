using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Console;

public class ConsoleLogger : ILogger
{
    private List<LogStamp> _logs;

    public ConsoleLogger()
    {
        _logs = new List<LogStamp>();
    }

    public void Log(LogLevel logLevel, string message)
    {
        var logStamp = new LogStamp(logLevel, message, DateTime.Now);

        _logs.Add(logStamp);

        System.Console.WriteLine(logStamp.ToString());
    }
}