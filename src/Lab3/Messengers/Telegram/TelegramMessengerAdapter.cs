using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Telegram;

public class TelegramMessengerAdapter : IMessenger
{
    private ITelegramMessenger _telegramMessenger;

    public TelegramMessengerAdapter(ITelegramMessenger telegramMessenger)
    {
        _telegramMessenger = telegramMessenger;
    }

    public void PrintMessage(IMessage message)
    {
        _telegramMessenger.ShowMessage(message);
    }
}