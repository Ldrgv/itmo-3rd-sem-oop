using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;

public class OutputFormatInfo
{
    public OutputFormatInfo(string? tab, string? fileIcon, string? directoryIcon)
    {
        Tab = tab ?? throw new ArgumentNullException(nameof(tab));
        FileIcon = fileIcon ?? throw new ArgumentNullException(nameof(fileIcon));
        DirectoryIcon = directoryIcon ?? throw new ArgumentNullException(nameof(directoryIcon));
    }

    public string Tab { get; }
    public string FileIcon { get; }
    public string DirectoryIcon { get; }
}