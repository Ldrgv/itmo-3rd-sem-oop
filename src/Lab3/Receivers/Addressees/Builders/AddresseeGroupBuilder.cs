using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;

public class AddresseeGroupBuilder : IAddresseeBuilder
{
    private List<IReceiver> _addressees;

    public AddresseeGroupBuilder()
    {
        _addressees = new List<IReceiver>();
    }

    public AddresseeGroupBuilder WithAddressees(IEnumerable<IReceiver> addressees)
    {
        _addressees = addressees.ToList();

        return this;
    }

    public IReceiver Build()
    {
        return new AddresseeGroup(_addressees);
    }
}