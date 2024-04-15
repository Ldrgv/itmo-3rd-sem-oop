using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class TreeListCommand : IFilesystemCommand
{
    public TreeListCommand(int depth = 1)
    {
        if (depth <= 0)
        {
            throw new ArgumentException("depth in 'tree list' command should be positive");
        }

        Depth = depth;
    }

    public int Depth { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return context.TreeList(Depth);
    }
}