using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route : IPassable
{
    public Route(IEnumerable<Segment> segments)
    {
        Segments = segments.ToList();
    }

    public Route(int distance, EnvironmentBase environment)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        Segments = new List<Segment> { new Segment(distance, environment) };
    }

    public IReadOnlyList<Segment> Segments { get; }

    public Result MakeDamage(Spaceship spaceship)
    {
        return Segments
            .Select(segment => segment.MakeDamage(spaceship))
            .FirstOrDefault(result => result.Status is not Status.Success) ?? new Result(Status.Success);
    }

    public Result PassDistance(Spaceship spaceship)
    {
        double time = 0;
        var fuelConsumptions = new List<Fuel>();

        foreach (Result result in Segments.Select(segment => segment.PassDistance(spaceship)))
        {
            if (result is not DistanceSuccessResult distanceSuccess)
            {
                return result;
            }

            time += distanceSuccess.TravelTime;
            fuelConsumptions.AddRange(distanceSuccess.FuelConsumptions);
        }

        return new DistanceSuccessResult(time, fuelConsumptions);
    }
}