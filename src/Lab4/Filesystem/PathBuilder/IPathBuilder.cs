namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.PathBuilder;

public interface IPathBuilder
{
    public string Build(string contextPath, string path);
}