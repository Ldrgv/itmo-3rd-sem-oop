using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private IDisplayDriver _driver;

    public Display(IDisplayDriver? displayDriver)
    {
        _driver = displayDriver ?? new DisplayDriver();
    }

    public void PrintColorMessage(IMessage message, Color? color = null)
    {
        if (message == null) throw new NullMessagePrintException("Display can not print null message!");

        _driver.ClearScreen();
        _driver.WriteText(_driver.SetTextColor(message.ToString(), color ?? Color.White));
    }
}