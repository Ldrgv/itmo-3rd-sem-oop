using System;
using Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details.OutputWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.PathBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab4.App;

public class Context
{
    public Context(string address, IFilesystem filesystem, IPathBuilder pathBuilder, IOutputWriter outputWriter)
    {
        Path = address ?? throw new ArgumentNullException(nameof(address));
        Filesystem = filesystem ?? throw new ArgumentNullException(nameof(filesystem));
        PathBuilder = pathBuilder ?? throw new ArgumentNullException(nameof(pathBuilder));
        OutputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));

        OutputFormatInfo = ConfigLoader.LoadOutputFormatInfo();
    }

    public string Path { get; private set; }
    public IFilesystem Filesystem { get; }
    public IPathBuilder PathBuilder { get;  }
    public IOutputWriter OutputWriter { get; }

    public OutputFormatInfo OutputFormatInfo { get; }

    public CommandResult Connect()
    {
        return !Filesystem.IsDirectoryExists(Path)
            ? new CommandResult(CommandResultStatus.Error, "Directory does not exist")
            : new CommandResult(CommandResultStatus.Success);
    }

    public CommandResult TreeGoto(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));

        path = PathBuilder.Build(Path, path);

        if (!Filesystem.IsDirectoryExists(path))
        {
            return new CommandResult(CommandResultStatus.Error, "Directory does not exist");
        }

        Path = path;

        return new CommandResult(CommandResultStatus.Success);
    }

    public CommandResult TreeList(int depth = 1)
    {
        OutputWriter.Write(Filesystem.GetDirectoryTree(Path, depth, OutputFormatInfo));

        return new CommandResult(CommandResultStatus.Success);
    }

    public CommandResult FileShow(string path)
    {
        path = PathBuilder.Build(Path, path);

        if (!Filesystem.IsFileExists(path))
        {
            return new CommandResult(CommandResultStatus.Error, "File does not exist");
        }

        OutputWriter.Write(Filesystem.GetFileContent(path));

        return new CommandResult(CommandResultStatus.Success);
    }

    public CommandResult FileMove(string sourcePath, string destinationPath)
    {
        sourcePath = PathBuilder.Build(Path, sourcePath);
        destinationPath = PathBuilder.Build(Path, destinationPath);

        return Filesystem.MoveFile(sourcePath, destinationPath);
    }

    public CommandResult FileCopy(string sourcePath, string destinationPath)
    {
        sourcePath = PathBuilder.Build(Path, sourcePath);
        destinationPath = PathBuilder.Build(Path, destinationPath);

        return Filesystem.CopyFile(sourcePath, destinationPath);
    }

    public CommandResult FileDelete(string path)
    {
        path = PathBuilder.Build(Path, path);

        return Filesystem.DeleteFile(path);
    }

    public CommandResult FileRename(string path, string newName)
    {
        path = PathBuilder.Build(Path, path);

        return Filesystem.RenameFile(path, newName);
    }
}