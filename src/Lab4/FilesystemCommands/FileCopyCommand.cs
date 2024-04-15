using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class FileCopyCommand : IFilesystemCommand
{
    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        DestinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return context.FileCopy(SourcePath, DestinationPath);
    }
}