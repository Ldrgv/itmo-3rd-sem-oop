using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;

public static class DeflectorCreator
{
    public static Deflector DeflectorClass1 => new Deflector(15);

    public static Deflector DeflectorClass2 => new Deflector(50);

    public static Deflector DeflectorClass3 => new Deflector(100);
}