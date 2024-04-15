using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Segment : IPassable
{
    public Segment(int distance, EnvironmentBase environment)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        Distance = distance;
        Environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    public int Distance { get; }
    public EnvironmentBase Environment { get; }

    public Result MakeDamage(Spaceship spaceship)
    {
        return Environment.Obstacles
            .Select(obstacle => obstacle.MakeDamage(spaceship))
            .FirstOrDefault(result => result is not DistanceSuccessResult) ?? new Result(Status.Success);
    }

    public Result PassDistance(Spaceship spaceship)
    {
        return Environment.PassDistance(Distance, spaceship);
    }
}