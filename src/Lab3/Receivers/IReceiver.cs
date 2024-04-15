using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers;

public interface IReceiver
{
    public void ReceiveMessage(IMessage message);
}