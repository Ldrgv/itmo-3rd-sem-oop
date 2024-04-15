using Core.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Defaults;

public class Consts
{
    public Consts()
    {
        Account = new Account(123, "123", 0);
    }

    public Account Account { get; }
}