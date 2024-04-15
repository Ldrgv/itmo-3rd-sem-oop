using System;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

public class ParseResultSuccess : ParseResult
{
    public ParseResultSuccess(IFilesystemCommand command)
        : base(ParseResultStatus.Success, string.Empty)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        Command = new ContextNotNullCommandProxy(command);
    }

    public IFilesystemCommand Command { get; }
}