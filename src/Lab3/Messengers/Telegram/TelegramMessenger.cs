using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Telegram;

public class TelegramMessenger : ITelegramMessenger
{
    public void ShowMessage(IMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        Console.WriteLine(message.ToString());
    }
}