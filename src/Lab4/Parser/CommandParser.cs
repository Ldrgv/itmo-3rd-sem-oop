using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class CommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (!words.Any())
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "No any command given");
        }

        return words[0] switch
        {
            "connect" => new ConnectCommandParser().Parse(words.Skip(1)),
            "disconnect" => new DisconnectCommandParser().Parse(words.Skip(1)),
            "tree" => new TreeCommandParser().Parse(words.Skip(1)),
            "file" => new FileCommandParser().Parse(words.Skip(1)),
            _ => new ParseResult(ParseResultStatus.Fail, $"No command named {words[0]}"),
        };
    }
}