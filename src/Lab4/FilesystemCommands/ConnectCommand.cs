using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details.OutputWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.PathBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands.Details;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class ConnectCommand : IFilesystemCommand
{
    public ConnectCommand(string address, ConnectMode mode)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Mode = mode;
    }

    public string Address { get; }
    public ConnectMode Mode { get; }

    public CommandResult Execute(ref Context? context)
    {
        switch (Mode)
        {
            case ConnectMode.Local:
                context = new Context(Address, new LocalFilesystem(), new LocalFilesystemPathBuilder(), new ConsoleWriter());
                return context.Connect();
        }

        return new CommandResult(CommandResultStatus.Error, $"No connect mode named {Mode}");
    }
}