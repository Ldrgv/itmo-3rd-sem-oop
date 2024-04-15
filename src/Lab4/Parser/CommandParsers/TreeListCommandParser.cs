using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.CommandParsers;

public class TreeListCommandParser : IParser
{
    public ParseResult Parse(IEnumerable<string> line)
    {
        List<string> words = line.ToList() ?? throw new ArgumentNullException(nameof(line));

        if (!words.Any())
        {
            return new ParseResultSuccess(new TreeListCommand());
        }

        if (words.Count != 2 || words[0] != "-d")
        {
            return new ParseResult(ParseResultStatus.Fail, "Syntax for 'tree list' command is: tree list {-d Depth}");
        }

        try
        {
            return new ParseResultSuccess(new TreeListCommand(int.Parse(words[1], CultureInfo.InvariantCulture)));
        }
        catch (FormatException)
        {
            return new ParseResult(ParseResultStatus.Fail, "Argument for '-d' flag should be integer");
        }
    }
}