using Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem;

public interface IFilesystem
{
    public bool IsDirectoryExists(string path);
    public bool IsFileExists(string path);
    public string GetDirectoryTree(string path, int depth, OutputFormatInfo outputFormatInfo);
    public string GetFileContent(string path);
    public CommandResult MoveFile(string sourcePath, string destinationPath);
    public CommandResult CopyFile(string sourcePath, string destinationPath);
    public CommandResult DeleteFile(string path);
    public CommandResult RenameFile(string path, string newName);
}