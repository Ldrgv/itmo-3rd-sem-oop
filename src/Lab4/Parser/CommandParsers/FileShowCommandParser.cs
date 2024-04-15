using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class FileShowCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (words.Count != 1 && words.Count != 3)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "'file show' command should contain at least one parameter");
        }

        if (words.Count == 1)
        {
            return new ParseResultSuccess(new FileShowCommand(words[0]));
        }

        if (words[1] != "-m")
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                "'file show' command has only -m flag for additional parameters");
        }

        FileShowMode showMode = words[2] switch
        {
            "console" => FileShowMode.Console,
            _ => FileShowMode.None,
        };

        if (showMode == FileShowMode.None)
        {
            return new ParseResult(
                ParseResultStatus.Fail,
                $"Output mode {words[2]} is not supported ");
        }

        return new ParseResultSuccess(new FileShowCommand(words[0], showMode));
    }
}