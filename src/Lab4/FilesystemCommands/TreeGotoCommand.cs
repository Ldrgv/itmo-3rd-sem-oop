using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class TreeGotoCommand : IFilesystemCommand
{
    public TreeGotoCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return context.TreeGoto(Path);
    }
}