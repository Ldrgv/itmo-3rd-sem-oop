using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlare : ObstacleBase
{
    public AntimatterFlare()
        : base(1)
    {
    }

    public AntimatterFlare(int damage)
        : base(damage)
    {
    }

    public override Result MakeDamage(Spaceship spaceship)
    {
        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship));

        if (spaceship.PhotonDeflector is null ||
            spaceship.PhotonDeflector.TakeDamage(Damage) > 0)
        {
            return new Result(Status.CrewDied);
        }

        return new Result(Status.Success);
    }
}