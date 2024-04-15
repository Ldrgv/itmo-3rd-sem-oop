using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Implementation.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models;

public interface IFilesystemModel
{
    public string Path { get; }
    public string Name { get; }
    public string Icon { get; }

    public string AcceptVisitor(DirectoryTreeVisitor visitor, int depth, int currentDepth);
}