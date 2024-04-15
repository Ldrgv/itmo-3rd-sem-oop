using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    public void PrintMessage(IMessage message);
}