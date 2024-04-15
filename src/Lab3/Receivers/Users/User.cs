using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Users;

public class User : IReceiver
{
    private readonly List<ReadableMessage> _messages;

    public User(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _messages = new List<ReadableMessage>();
    }

    public string Name { get; }

    public void ReceiveMessage(IMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        _messages.Add(new ReadableMessage(message.Title, message.Body, message.Importance));
    }

    public void ReadMessage(string title)
    {
        if (title == null) throw new ArgumentNullException(nameof(title));

        foreach (ReadableMessage message in _messages)
        {
            if (message.Title == title)
            {
                message.MarkAsRead();

                return;
            }
        }
    }

    public bool IsMessageRead(string title)
    {
        if (title == null) throw new ArgumentNullException(nameof(title));

        ReadableMessage? message = _messages.FirstOrDefault(message => message.Title.Equals(title, StringComparison.Ordinal));
        if (message == null)
        {
            throw new NoMessageWithGivenTitleException($"Title={title}");
        }

        return message.IsRead;
    }
}