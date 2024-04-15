using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class FileCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (!words.Any())
        {
            return new ParseResult(ParseResultStatus.Fail, "'file' command should be provided with more arguments");
        }

        return words[0] switch
        {
            "show" => new FileShowCommandParser().Parse(words.Skip(1)),
            "move" => new FileMoveCommandParser().Parse(words.Skip(1)),
            "copy" => new FileCopyCommandParser().Parse(words.Skip(1)),
            "delete" => new FileDeleteCommandParser().Parse(words.Skip(1)),
            "rename" => new FileRenameCommandParser().Parse(words.Skip(1)),
            _ => new ParseResult(ParseResultStatus.Fail, $"No option named {words[0]} for 'file' command"),
        };
    }
}