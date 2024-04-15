using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NitrineParticleNebula : EnvironmentBase
{
    public NitrineParticleNebula() { }

    public NitrineParticleNebula(IEnumerable<ObstacleBase> obstacles)
        : base(obstacles)
    {
    }

    public override Result PassDistance(int distance, Spaceship spaceship)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship));

        if (spaceship.ImpulseEngine is not ImpulseEngineE)
        {
            return new Result(Status.NoRequiredEngine);
        }

        Result fuelResult = spaceship.ImpulseEngine.BurnFuelByDistance(distance);
        if (fuelResult is not FuelSuccessResult fuelSuccessResult)
        {
            return fuelResult;
        }

        double time = spaceship.ImpulseEngine.GetTimeByDistance(distance);

        return new DistanceSuccessResult(time, fuelSuccessResult.Fuel);
    }

    public override bool IsMatchObstacle(ObstacleBase obstacle)
    {
        return obstacle is CosmoWhale;
    }

    public override SpaceshipOption GetBestSpaceship(SpaceshipOption? bestOption, SpaceshipOption anotherOption)
    {
        if (anotherOption == null) throw new ArgumentNullException(nameof(anotherOption));

        if (bestOption == null ||
            bestOption.Spaceship.Hull.HitPoints < anotherOption.Spaceship.Hull.HitPoints)
        {
            return anotherOption;
        }

        return bestOption;
    }
}