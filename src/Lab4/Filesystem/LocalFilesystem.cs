using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Implementation.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem;

public class LocalFilesystem : IFilesystem
{
    public bool IsDirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public bool IsFileExists(string path)
    {
        return File.Exists(path);
    }

    public string GetDirectoryTree(string path, int depth, OutputFormatInfo outputFormatInfo)
    {
        return new DirectoryTreeVisitor(outputFormatInfo)
            .VisitDirectory(new Models.LocalFilesystem.Directory(path, outputFormatInfo), depth);
    }

    public string GetFileContent(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (IOException)
        {
            return string.Empty;
        }
    }

    public CommandResult MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Move(sourcePath, $"{destinationPath}/{Path.GetFileName(sourcePath)}");

            return new CommandResult(CommandResultStatus.Success);
        }
        catch (IOException exception)
        {
            return new CommandResult(CommandResultStatus.Error, exception.Message);
        }
    }

    public CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, $"{destinationPath}/{Path.GetFileName(sourcePath)}");

            return new CommandResult(CommandResultStatus.Success);
        }
        catch (IOException exception)
        {
            return new CommandResult(CommandResultStatus.Error, exception.Message);
        }
    }

    public CommandResult DeleteFile(string path)
    {
        try
        {
            File.Delete(path);

            return new CommandResult(CommandResultStatus.Success);
        }
        catch (IOException exception)
        {
            return new CommandResult(CommandResultStatus.Error, exception.Message);
        }
    }

    public CommandResult RenameFile(string path, string newName)
    {
        try
        {
            File.Move(path, $"{Path.GetDirectoryName(path)}/{newName}");

            return new CommandResult(CommandResultStatus.Success);
        }
        catch (IOException exception)
        {
            return new CommandResult(CommandResultStatus.Error, exception.Message);
        }
    }
}