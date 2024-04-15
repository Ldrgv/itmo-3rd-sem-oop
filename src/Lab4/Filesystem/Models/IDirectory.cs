using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models;

public interface IDirectory : IFilesystemModel
{
    public IReadOnlyList<IFilesystemModel> GetContents();
}