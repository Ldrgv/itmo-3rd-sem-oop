using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Console;

public class LogStamp
{
    private readonly LogLevel _level;
    private readonly string _message;
    private readonly DateTime _dateTime;

    public LogStamp(LogLevel level, string message, DateTime dateTime)
    {
        _level = level;
        _message = message;
        _dateTime = dateTime;
    }

    public override string ToString()
    {
        return $"{_level.ToString()}:{_dateTime.ToString(CultureInfo.InvariantCulture)}:{_message}";
    }
}