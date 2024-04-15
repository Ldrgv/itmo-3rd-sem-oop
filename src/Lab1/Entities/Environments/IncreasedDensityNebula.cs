using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class IncreasedDensityNebula : EnvironmentBase
{
    public IncreasedDensityNebula() { }

    public IncreasedDensityNebula(IEnumerable<ObstacleBase> obstacles)
        : base(obstacles)
    {
    }

    public override Result PassDistance(int distance, Spaceship spaceship)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        if (spaceship is null) throw new ArgumentNullException(nameof(spaceship));

        if (spaceship.JumpEngine is null)
        {
            return new Result(Status.NoRequiredEngine);
        }

        if (spaceship.JumpEngine.MaxDistance < distance)
        {
            return new Result(Status.ShipLost);
        }

        Result fuelResult = spaceship.JumpEngine.BurnFuelByDistance(distance);
        if (fuelResult is not FuelSuccessResult fuelSuccessResult)
        {
            return new Result(Status.NoEnoughFuel);
        }

        double time = spaceship.JumpEngine.GetTimeByDistance(distance);

        return new DistanceSuccessResult(time, fuelSuccessResult.Fuel);
    }

    public override bool IsMatchObstacle(ObstacleBase obstacle)
    {
        return obstacle is AntimatterFlare;
    }

    public override SpaceshipOption GetBestSpaceship(SpaceshipOption? bestOption, SpaceshipOption anotherOption)
    {
        if (anotherOption == null) throw new ArgumentNullException(nameof(anotherOption));

        if (bestOption == null || (
            bestOption.Spaceship.JumpEngine is not null &&
            anotherOption.Spaceship.JumpEngine is not null &&
            anotherOption.Spaceship.JumpEngine.MaxDistance > bestOption.Spaceship.JumpEngine.MaxDistance))
        {
            return anotherOption;
        }

        return bestOption;
    }
}