using System;
using System.Numerics;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class Guard
{
    public static void ArgumentIsPositive<T>(T value, string name)
        where T : INumber<T>
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        if (T.Sign(value) < 0)
        {
            throw new PositiveNumberException($"{name} should be positive!");
        }
    }
}