using Common.Exceptions;

namespace Common.Guards;

public static class Guard
{
    public static void IsNonNegativeInteger(int number)
    {
        if (number < 0)
        {
            throw new NonNegativeIntegerException();
        }
    }
}