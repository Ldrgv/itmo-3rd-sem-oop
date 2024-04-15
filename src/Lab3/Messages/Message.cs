namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    public Message(string title, string body, Importance importance)
    {
        Title = title;
        Body = body;
        Importance = importance;
    }

    public string Title { get; }
    public string Body { get; }
    public Importance Importance { get; }

    public override string ToString()
    {
        return $"{Title}\n\n{Body}";
    }
}