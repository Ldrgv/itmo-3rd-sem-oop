using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class TreeGotoCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (words.Count != 1)
        {
            return new ParseResult(ParseResultStatus.Fail, "'tree goto' command should contain path");
        }

        return new ParseResultSuccess(new TreeGotoCommand(words[0]));
    }
}