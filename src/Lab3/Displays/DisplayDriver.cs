using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    public void ClearScreen()
    {
        Console.Clear();
    }

    public string SetTextColor(string text, Color color)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(text);
    }

    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}