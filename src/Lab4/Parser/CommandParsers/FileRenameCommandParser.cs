using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class FileRenameCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (words.Count != 2)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "'file rename' command should contain 2 params: file path and its new name");
        }

        return new ParseResultSuccess(new FileRenameCommand(words[0], words[1]));
    }
}