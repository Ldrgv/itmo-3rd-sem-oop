using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands.Details;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class ConnectCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));
        if (words.Count != 3 || words[1] != "-m")
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "You should provide the connect command with following syntax: connect [Address] [-m Mode]");
        }

        ConnectMode connectMode = words[2] switch
        {
            "local" => ConnectMode.Local,
            _ => ConnectMode.None,
        };

        if (connectMode == ConnectMode.None)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                $"Connect mode named {words[2]} is not supported yet");
        }

        return new ParseResultSuccess(new ConnectCommand(words[0], connectMode));
    }
}