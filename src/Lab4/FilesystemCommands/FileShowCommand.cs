using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public class FileShowCommand : IFilesystemCommand
{
    public FileShowCommand(string path, FileShowMode mode = FileShowMode.Console)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        ShowMode = mode;
    }

    public string Path { get; }
    public FileShowMode ShowMode { get; }

    public CommandResult Execute(ref Context? context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        return ShowMode switch
        {
            FileShowMode.Console => context.FileShow(Path),
            _ => new CommandResult(CommandResultStatus.Error, $"Output mode {ShowMode} is not supported yet"),
        };
    }
}