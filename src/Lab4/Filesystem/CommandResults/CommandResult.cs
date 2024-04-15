using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

public class CommandResult
{
    public CommandResult(CommandResultStatus status)
    {
        Status = status;
        Message = string.Empty;
    }

    public CommandResult(CommandResultStatus status, string message)
    {
        Status = status;
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    public CommandResultStatus Status { get; }
    public string Message { get; }
}