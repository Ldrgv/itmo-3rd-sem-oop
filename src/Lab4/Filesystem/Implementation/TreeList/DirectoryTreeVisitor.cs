using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.App.OutputFormatting;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Filesystem.Implementation.TreeList;

public class DirectoryTreeVisitor
{
    private OutputFormatInfo _outputFormatInfo;

    public DirectoryTreeVisitor(OutputFormatInfo outputFormatInfo)
    {
        _outputFormatInfo = outputFormatInfo ?? throw new ArgumentNullException(nameof(outputFormatInfo));
    }

    public string VisitDirectory(IDirectory directory, int depth, int currentDepth = 0)
    {
        if (directory == null) throw new ArgumentNullException(nameof(directory));

        var resultStringBuilder = new StringBuilder(VisitSimple(directory, currentDepth));

        if (depth == currentDepth)
        {
            return resultStringBuilder.ToString();
        }

        foreach (IFilesystemModel model in directory.GetContents())
        {
            resultStringBuilder.Append(model.AcceptVisitor(this, depth, currentDepth + 1));
        }

        return resultStringBuilder.ToString();
    }

    public string VisitSimple(IFilesystemModel model, int currentDepth)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        return new StringBuilder()
            .Append(string.Join(string.Empty, Enumerable.Repeat(_outputFormatInfo.Tab, currentDepth)))
            .AppendLine(CultureInfo.InvariantCulture, $"{model.Icon} {model.Name}")
            .ToString();
    }
}