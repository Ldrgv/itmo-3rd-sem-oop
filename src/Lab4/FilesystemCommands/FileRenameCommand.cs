using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class FileRenameCommand : IFilesystemCommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Path { get; }
    public string Name { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return context.FileRename(Path, Name);
    }
}