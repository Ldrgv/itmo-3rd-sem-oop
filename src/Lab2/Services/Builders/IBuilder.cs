namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public interface IBuilder<out T>
{
    public T Build();
}