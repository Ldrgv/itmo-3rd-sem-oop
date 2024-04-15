using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

public interface IFilesystemCommand
{
    public CommandResult Execute(ref Context? context);
}