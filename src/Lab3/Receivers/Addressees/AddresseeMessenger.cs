using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees;

public class AddresseeMessenger : IReceiver
{
    private IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void ReceiveMessage(IMessage message)
    {
        _messenger.PrintMessage(message);
    }
}