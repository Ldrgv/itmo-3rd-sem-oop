namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage
{
    public string Title { get; }
    public string Body { get; }
    public Importance Importance { get; }

    public string ToString();
}