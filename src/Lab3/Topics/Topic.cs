using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public Topic(Topic other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        Name = other.Name;
        Addressee = other.Addressee;
    }

    internal Topic(string name, IReceiver addresseeProxy)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Addressee = addresseeProxy ?? throw new ArgumentNullException(nameof(addresseeProxy));
    }

    public string Name { get; }
    public IReceiver Addressee { get; }

    public void SendMessage(IMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        Addressee.ReceiveMessage(message);
    }
}