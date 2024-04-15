using System;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Implementation.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models.LocalFilesystem;

public class File : IFile
{
    public File(string path, string icon)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        Icon = icon ?? throw new ArgumentNullException(nameof(icon));
    }

    public string Path { get; }
    public string Name => System.IO.Path.GetFileName(Path);
    public string Icon { get; }

    public string AcceptVisitor(DirectoryTreeVisitor visitor, int depth, int currentDepth)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));

        return visitor.VisitSimple(this, currentDepth);
    }

    public string GetContent()
    {
        return System.IO.File.ReadAllText(Path);
    }
}