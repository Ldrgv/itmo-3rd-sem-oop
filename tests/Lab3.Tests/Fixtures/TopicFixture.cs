using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Telegram;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using NSubstitute;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Fixtures;

public sealed class TopicFixture : IDisposable
{
    public TopicFixture()
    {
        const string userName = "Ldrgv";

        User = new User(userName);

        const string userTopicName = "C#";
        const Importance importanceFilter = Importance.Important;

        UserTopic = new TopicBuilder()
            .WithName(userTopicName)
            .WithAddresseeBuilder(
                new AddresseeUserBuilder()
                    .WithUser(User)
                    .WithImportanceFilter(importanceFilter))
            .Build();

        const string title = "Title";
        const string body = "Lab3";

        Message = new Message(title, body, importanceFilter);

        Messenger = Substitute.For<TelegramMessengerAdapter>(new TelegramMessenger());

        const string messengerTopicName = "Why I don't use Moq";

        MessengerTopicSubstitute = Substitute.For<Topic>(
            new TopicBuilder()
                .WithName(messengerTopicName)
                .WithAddresseeBuilder(
                    new AddresseeMessengerBuilder()
                        .WithMessenger(Messenger))
                .Build());
    }

    public User User { get; }
    public Topic UserTopic { get; }

    public Message Message { get; }

    public IMessenger Messenger { get; }
    public Topic MessengerTopicSubstitute { get; }

    public void Dispose()
    {
    }
}