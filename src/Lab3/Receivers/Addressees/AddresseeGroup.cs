using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees;

public class AddresseeGroup : IReceiver
{
    private readonly List<IReceiver> _addressees;

    public AddresseeGroup(IEnumerable<IReceiver> addressees)
    {
        _addressees = addressees.ToList() ?? throw new ArgumentNullException(nameof(addressees));
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IReceiver addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}