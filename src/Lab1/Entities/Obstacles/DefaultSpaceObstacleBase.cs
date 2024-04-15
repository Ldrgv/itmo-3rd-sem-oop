using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class DefaultSpaceObstacleBase : ObstacleBase
{
    public DefaultSpaceObstacleBase(int damage)
        : base(damage)
    {
    }

    public override Result MakeDamage(Spaceship spaceship)
    {
        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship));

        double remainingDamage = spaceship.Deflector?.TakeDamage(Damage) ?? Damage;

        return spaceship.Hull.TakeDamage(remainingDamage) > 0
            ? new Result(Status.ShipDestroyed)
            : new Result(Status.Success);
    }
}