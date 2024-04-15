namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models;

public interface IFile : IFilesystemModel
{
    public string GetContent();
}