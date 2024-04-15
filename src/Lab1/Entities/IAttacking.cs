using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface IAttacking
{
    public Result MakeDamage(Spaceship spaceship);
}