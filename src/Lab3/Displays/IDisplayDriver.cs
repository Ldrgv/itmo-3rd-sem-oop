using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public void ClearScreen();
    public string SetTextColor(string text, Color color);
    public void WriteText(string text);
}