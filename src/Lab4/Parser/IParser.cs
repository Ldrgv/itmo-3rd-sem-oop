using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IParser
{
    public ParseResult Parse(IEnumerable<string> line);
}