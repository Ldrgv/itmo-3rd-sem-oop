namespace Common.Exceptions;

public class NonNegativeIntegerException : Exception
{
    public NonNegativeIntegerException()
    {
    }

    public NonNegativeIntegerException(string message)
        : base(message)
    {
    }

    public NonNegativeIntegerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}