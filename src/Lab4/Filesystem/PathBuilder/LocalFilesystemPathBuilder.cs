using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.PathBuilder;

public class LocalFilesystemPathBuilder : IPathBuilder
{
    public string Build(string contextPath, string path)
    {
        if (contextPath == null) throw new ArgumentNullException(nameof(contextPath));
        if (path == null) throw new ArgumentNullException(nameof(path));

        return path.StartsWith('/') ? path : $"{contextPath}/{path}";
    }
}