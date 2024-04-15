using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Implementation.TreeList;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models.LocalFilesystem;

public class Directory : IDirectory
{
    private OutputFormatInfo _outputFormatInfo;

    public Directory(string path, OutputFormatInfo outputFormatInfo)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        _outputFormatInfo = outputFormatInfo ?? throw new ArgumentNullException(nameof(outputFormatInfo));
    }

    public string Path { get; }
    public string Name => System.IO.Path.GetFileName(Path);
    public string Icon => _outputFormatInfo.DirectoryIcon;

    public string AcceptVisitor(DirectoryTreeVisitor visitor, int depth, int currentDepth)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));

        return visitor.VisitDirectory(this, depth, currentDepth);
    }

    public IReadOnlyList<IFilesystemModel> GetContents()
    {
        var contents = new List<IFilesystemModel>();

        foreach (string directoryPath in System.IO.Directory.GetDirectories(Path))
        {
            contents.Add(new Directory(directoryPath, _outputFormatInfo));
        }

        foreach (string filePath in System.IO.Directory.GetFiles(Path))
        {
            contents.Add(new File(filePath, _outputFormatInfo.FileIcon));
        }

        return contents.AsReadOnly();
    }
}