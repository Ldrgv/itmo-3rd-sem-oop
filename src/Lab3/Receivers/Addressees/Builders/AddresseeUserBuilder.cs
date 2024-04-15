using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Proxies;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;

public class AddresseeUserBuilder : IAddresseeBuilder
{
    private User? _user;
    private Importance? _importanceFilter;

    public AddresseeUserBuilder WithUser(User user)
    {
        _user = user;

        return this;
    }

    public AddresseeUserBuilder WithImportanceFilter(Importance importance)
    {
        _importanceFilter = importance;

        return this;
    }

    public IReceiver Build()
    {
        IReceiver addressee = new AddresseeUser(_user ?? throw new ArgumentNullException(nameof(_user)));
        if (_importanceFilter is not null)
        {
            addressee = new AddresseeImportanceFilterProxy(addressee, _importanceFilter.Value);
        }

        return addressee;
    }
}