using System;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.LoggerDecorators;

public class LoggerAddresseeDecorator : IReceiver
{
    private ILogger _logger;
    private IReceiver _receiver;

    public LoggerAddresseeDecorator(ILogger logger, IReceiver receiver)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        _logger.Log(LogLevel.Info, $"Received new message with title {message.Title}.");

        _receiver.ReceiveMessage(message);
    }
}