using System;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Details;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FilesystemCommands.Details;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Result;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class PaserTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PaserTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ConnectCommandTest()
    {
        string address = ":C/";
        string mode = "local";
        string line = $"connect {address} -m {mode}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        ConnectCommand command = Assert.IsType<ConnectCommand>(notNullCommandProxy.Command);

        Assert.Equal(address, command.Address);
        Assert.Equal(ConnectMode.Local, command.Mode);
    }

    [Fact]
    public void DisconnectCommandTest()
    {
        string line = "disconnect";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        Assert.IsType<DisconnectCommand>(notNullCommandProxy.Command);
    }

    [Fact]
    public void TreeGotoCommandTest()
    {
        string path = "lol";
        string line = $"tree goto {path}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        TreeGotoCommand command = Assert.IsType<TreeGotoCommand>(notNullCommandProxy.Command);

        Assert.Equal(path, command.Path);
    }

    [Theory]
    [InlineData(1, "tree list")]
    [InlineData(3, "tree list -d 3")]
    public void TreeListCommandTest(int depth, string line)
    {
        if (line == null) throw new ArgumentNullException(nameof(line));

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));
        _testOutputHelper.WriteLine(parseResult.Message);
        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        TreeListCommand command = Assert.IsType<TreeListCommand>(notNullCommandProxy.Command);

        Assert.Equal(depth, command.Depth);
    }

    [Fact]
    public void FileShowTest()
    {
        string path = ":)";
        string mode = "console";
        string line = $"file show {path} -m {mode}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        FileShowCommand command = Assert.IsType<FileShowCommand>(notNullCommandProxy.Command);

        Assert.Equal(path, command.Path);
        Assert.Equal(FileShowMode.Console, command.ShowMode);
    }

    [Fact]
    public void FileMoveCommandTest()
    {
        string sourcePath = "->";
        string destinationPath = ">.";
        string line = $"file move {sourcePath} {destinationPath}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        FileMoveCommand command = Assert.IsType<FileMoveCommand>(notNullCommandProxy.Command);

        Assert.Equal(sourcePath, command.SourcePath);
        Assert.Equal(destinationPath, command.DestinationPath);
    }

    [Fact]
    public void FileCopyCommandTest()
    {
        string sourcePath = "->";
        string destinationPath = ">.";
        string line = $"file copy {sourcePath} {destinationPath}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        FileCopyCommand command = Assert.IsType<FileCopyCommand>(notNullCommandProxy.Command);

        Assert.Equal(sourcePath, command.SourcePath);
        Assert.Equal(destinationPath, command.DestinationPath);
    }

    [Fact]
    public void FileDeleteCommandTest()
    {
        string path = "kek";
        string line = $"file delete {path}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        FileDeleteCommand command = Assert.IsType<FileDeleteCommand>(notNullCommandProxy.Command);

        Assert.Equal(path, command.Path);
    }

    [Fact]
    public void FileRenameCommandTest()
    {
        string path = "radle";
        string name = "ldrgv";
        string line = $"file rename {path} {name}";

        ParseResult parseResult = new CommandParser().Parse(line.Split(' '));

        ParseResultSuccess parseResultSuccess = Assert.IsType<ParseResultSuccess>(parseResult);
        ContextNotNullCommandProxy notNullCommandProxy = Assert.IsType<ContextNotNullCommandProxy>(parseResultSuccess.Command);
        FileRenameCommand command = Assert.IsType<FileRenameCommand>(notNullCommandProxy.Command);

        Assert.Equal(path, command.Path);
        Assert.Equal(name, command.Name);
    }
}