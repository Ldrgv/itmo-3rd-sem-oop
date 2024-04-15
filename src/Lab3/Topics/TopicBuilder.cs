using System;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class TopicBuilder
{
    private string? _name;
    private IReceiver? _receiver;

    public TopicBuilder WithName(string name)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));

        return this;
    }

    public TopicBuilder WithAddresseeBuilder(IAddresseeBuilder addresseeBuilder)
    {
        if (addresseeBuilder == null) throw new ArgumentNullException(nameof(addresseeBuilder));

        _receiver = addresseeBuilder.Build();

        return this;
    }

    public Topic Build()
    {
        return new Topic(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _receiver ?? throw new ArgumentNullException(nameof(_receiver)));
    }
}