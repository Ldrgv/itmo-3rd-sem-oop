using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class FileCopyCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (words.Count != 2)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "'file copy' command should contain 2 params. file copy [SourcePath] [DestinationPath]");
        }

        return new ParseResultSuccess(new FileCopyCommand(words[0], words[1]));
    }
}