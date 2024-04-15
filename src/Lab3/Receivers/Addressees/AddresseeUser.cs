using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Receivers.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Receivers.Addressees;

public class AddresseeUser : IReceiver
{
    private User _user;

    public AddresseeUser(User user)
    {
        _user = user;
    }

    public void ReceiveMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }
}