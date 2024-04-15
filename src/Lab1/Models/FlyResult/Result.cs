namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

public class Result
{
    public Result(Status status)
    {
        Status = status;
    }

    public Status Status { get; }
}