using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;

public class AddresseeMessengerBuilder : IAddresseeBuilder
{
    private IMessenger? _messenger;

    public AddresseeMessengerBuilder WithMessenger(IMessenger messenger)
    {
        _messenger = messenger;

        return this;
    }

    public IReceiver Build()
    {
        return new AddresseeMessenger(_messenger ?? throw new ArgumentNullException(nameof(_messenger)));
    }
}