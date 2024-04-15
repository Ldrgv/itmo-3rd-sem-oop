using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Console;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.LoggerDecorators;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Fixtures;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public sealed class ChattingSystemTests : IClassFixture<TopicFixture>, IDisposable
{
    private TopicFixture _topicFixture;

    public ChattingSystemTests()
    {
        _topicFixture = new TopicFixture();
    }

    [Fact]
    public void UserUnreadMessageReceiveTest()
    {
        User user = _topicFixture.User;
        Topic topic = _topicFixture.UserTopic;
        Message message = _topicFixture.Message;

        topic.SendMessage(message);

        Assert.False(user.IsMessageRead(message.Title));
    }

    [Fact]
    public void UserReadMessageTest()
    {
        User user = _topicFixture.User;
        Topic topic = _topicFixture.UserTopic;
        Message message = _topicFixture.Message;

        topic.SendMessage(message);
        user.ReadMessage(message.Title);

        Assert.True(user.IsMessageRead(message.Title));
    }

    [Fact]
    public void MessageAlreadyReadExceptionTest()
    {
        User user = _topicFixture.User;
        Topic topic = _topicFixture.UserTopic;
        Message message = _topicFixture.Message;

        topic.SendMessage(message);
        user.ReadMessage(message.Title);

        Assert.Throws<MessageAlreadyReadException>(() =>
        {
            user.ReadMessage(message.Title);
        });
    }

    [Fact]
    public void ImportanceFilterOutTest()
    {
        IMessenger messenger = _topicFixture.Messenger;
        Topic messengerTopic = _topicFixture.MessengerTopicSubstitute;

        var message = new Message("LabDab", "DabLab", Importance.Unimportant);

        messengerTopic.SendMessage(message);

        messenger.DidNotReceive().PrintMessage(message);
    }

    [Fact]
    public void LogWritingTest()
    {
        var addresseeUser = new AddresseeUser(_topicFixture.User);
        ILogger logger = Substitute.For<ConsoleLogger>();
        var addressee = new LoggerAddresseeDecorator(logger, addresseeUser);
        var userTopic = new Topic("Topic", addressee);

        userTopic.SendMessage(_topicFixture.Message);

        logger.Received(1).Log(Arg.Any<LogLevel>(), Arg.Any<string>());
    }

    [Fact]
    public void ValidMessengerWorkTest()
    {
        IMessenger messenger = _topicFixture.Messenger;
        Message message = _topicFixture.Message;
        Topic messengerTopic = _topicFixture.MessengerTopicSubstitute;

        messengerTopic.SendMessage(message);

        messenger.Received(1).PrintMessage(message);
    }

    public void Dispose()
    {
        _topicFixture.Dispose();
    }
}