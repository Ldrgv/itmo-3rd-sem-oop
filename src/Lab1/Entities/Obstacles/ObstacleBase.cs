using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class ObstacleBase : IAttacking
{
    protected ObstacleBase(int damage)
    {
        Guard.ArgumentIsPositive(damage, nameof(damage));

        Damage = damage;
    }

    public int Damage { get; }

    public abstract Result MakeDamage(Spaceship spaceship);
}