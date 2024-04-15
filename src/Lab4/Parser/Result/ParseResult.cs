using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

public class ParseResult
{
    public ParseResult(ParseResultStatus status, string message)
    {
        Status = status;
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    public ParseResultStatus Status { get; }
    public string Message { get; }
}