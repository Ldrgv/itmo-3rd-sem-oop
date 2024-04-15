using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Telegram;

public interface ITelegramMessenger
{
    public void ShowMessage(IMessage message);
}