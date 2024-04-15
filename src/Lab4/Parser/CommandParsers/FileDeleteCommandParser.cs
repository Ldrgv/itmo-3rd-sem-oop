using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class FileDeleteCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (words.Count != 1)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "'file delete' command should contain only the path to the file to be deleted");
        }

        return new ParseResultSuccess(new FileDeleteCommand(words[0]));
    }
}