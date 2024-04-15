using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class FileDeleteCommand : IFilesystemCommand
{
    public FileDeleteCommand(string path)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public string Path { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return context.FileDelete(Path);
    }
}