using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class ContextNotNullCommandProxy : IFilesystemCommand
{
    public ContextNotNullCommandProxy(IFilesystemCommand command)
    {
        Command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public IFilesystemCommand Command { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null && Command is not ConnectCommand)
        {
            return new CommandResult(CommandResultStatus.Error, "No filesystem connected");
        }

        return Command.Execute(ref context);
    }
}