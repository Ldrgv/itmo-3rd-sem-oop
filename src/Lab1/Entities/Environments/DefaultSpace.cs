using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class DefaultSpace : EnvironmentBase
{
    public DefaultSpace() { }

    public DefaultSpace(IEnumerable<ObstacleBase> obstacles)
        : base(obstacles)
    {
    }

    public override Result PassDistance(int distance, Spaceship spaceship)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        if (spaceship == null) throw new ArgumentNullException(nameof(spaceship));

        if (spaceship.ImpulseEngine is null)
        {
            return new Result(Status.NoRequiredEngine);
        }

        Result fuelResult = spaceship.ImpulseEngine.BurnFuelByDistance(distance);
        if (fuelResult is not FuelSuccessResult fuelSuccessResult)
        {
            return new Result(Status.NoEnoughFuel);
        }

        double time = spaceship.ImpulseEngine.GetTimeByDistance(distance);

        return new DistanceSuccessResult(time, fuelSuccessResult.Fuel);
    }

    public override bool IsMatchObstacle(ObstacleBase obstacle)
    {
        return obstacle is Meteor or Asteroid;
    }

    public override SpaceshipOption GetBestSpaceship(SpaceshipOption? bestOption, SpaceshipOption anotherOption)
    {
        if (anotherOption == null) throw new ArgumentNullException(nameof(anotherOption));

        if (bestOption is null ||
            anotherOption.FlyCost < bestOption.FlyCost)
        {
            return anotherOption;
        }

        return bestOption;
    }
}