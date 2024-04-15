using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;

public static class HullCreator
{
    public static Hull HullClass1 => new Hull(1.0, 5);

    public static Hull HullClass2 => new Hull(1.5, 20);

    public static Hull HullClass3 => new Hull(2.0, 50);
}
