using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Proxies;

public class AddresseeImportanceFilterProxy : IReceiver
{
    private IReceiver _addressee;
    private Importance _importanceFilter;

    public AddresseeImportanceFilterProxy(IReceiver addressee, Importance importanceFilter)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _importanceFilter = importanceFilter;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        if (message.Importance >= _importanceFilter)
        {
            _addressee.ReceiveMessage(message);
        }
    }

    public void SetImportanceFilter(Importance importanceFilter)
    {
        _importanceFilter = importanceFilter;
    }
}