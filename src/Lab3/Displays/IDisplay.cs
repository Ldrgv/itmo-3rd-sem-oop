using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    public void PrintColorMessage(IMessage message, Color? color = null);
}