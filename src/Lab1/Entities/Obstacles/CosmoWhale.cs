using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhale : ObstacleBase
{
    private const double DefaultNitrineEmitterDamage = 1;
    private int _population;

    public CosmoWhale(int damage = 50, int population = 1)
        : base(damage)
    {
        Guard.ArgumentIsPositive(population, nameof(population));

        _population = population;
    }

    public override Result MakeDamage(Spaceship spaceship)
    {
        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship));

        if (spaceship.AntiNitrineEmitter is not null &&
            spaceship.AntiNitrineEmitter.TakeDamage(DefaultNitrineEmitterDamage) == 0)
        {
            return new Result(Status.Success);
        }

        double realDamage = Damage * _population;
        double remainingDamage = spaceship.Deflector?.TakeDamage(realDamage) ?? realDamage;

        return spaceship.Hull.TakeDamage(remainingDamage) > 0
            ? new Result(Status.ShipDestroyed)
            : new Result(Status.Success);
    }
}