using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class DisconnectCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        return new ParseResultSuccess(new DisconnectCommand());
    }
}