using System;
using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        Context? context = null;
        while (true)
        {
            string? line = Console.ReadLine();
            if (line == null)
            {
                break;
            }

            ParseResult parseResult = new CommandParser().Parse(line.Split(' '));
            if (parseResult is ParseResultSuccess parseResultSuccess)
            {
                CommandResult commandResult = parseResultSuccess.Command.Execute(ref context);
                if (commandResult.Status != CommandResultStatus.Success)
                {
                    Console.WriteLine($"An error occurred during command executing: {commandResult.Message}");
                    continue;
                }

                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine(parseResult.Message);
            }
        }
    }
}