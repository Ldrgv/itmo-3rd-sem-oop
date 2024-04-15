using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class JumpEngineBase : EngineBase
{
    private readonly double _speed;

    protected JumpEngineBase(double fuelAmount, int maxDistance, double speed)
        : base(FuelType.GravitonMatter, fuelAmount)
    {
        Guard.ArgumentIsPositive(maxDistance, nameof(maxDistance));
        Guard.ArgumentIsPositive(speed, nameof(speed));

        MaxDistance = maxDistance;
        _speed = speed;
    }

    public int MaxDistance { get; }

    public override double GetTimeByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return distance / _speed;
    }
}