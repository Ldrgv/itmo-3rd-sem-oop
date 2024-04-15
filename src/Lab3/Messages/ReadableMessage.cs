using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class ReadableMessage : Message
{
    public ReadableMessage(string title, string body, Importance importance)
        : base(title, body, importance)
    {
        IsRead = false;
    }

    public bool IsRead { get; private set; }

    public void MarkAsRead()
    {
        if (IsRead)
        {
            throw new MessageAlreadyReadException($"Message with title {Title} is already read!");
        }

        IsRead = true;
    }
}