using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees;

public class AddresseeDisplay : IReceiver
{
    private IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.PrintColorMessage(message);
    }
}