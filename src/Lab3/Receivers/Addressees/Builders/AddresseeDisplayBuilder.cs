using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;

public class AddresseeDisplayBuilder : IAddresseeBuilder
{
    private IDisplay? _display;
    private Importance? _importanceFilter;

    public AddresseeDisplayBuilder WithDisplay(IDisplay display)
    {
        _display = display;

        return this;
    }

    public AddresseeDisplayBuilder WithImportanceFilter(Importance importance)
    {
        _importanceFilter = importance;

        return this;
    }

    public IReceiver Build()
    {
        IReceiver addressee = new AddresseeDisplay(_display ?? throw new ArgumentNullException(nameof(_display)));
        if (_importanceFilter is not null)
        {
            addressee = new AddresseeImportanceFilterProxy(addressee, _importanceFilter.Value);
        }

        return addressee;
    }
}