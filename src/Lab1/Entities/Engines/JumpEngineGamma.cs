using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineGamma : JumpEngineBase
{
    public JumpEngineGamma(double fuelAmount, int maxDistance, double speed)
        : base(fuelAmount, maxDistance, speed)
    {
    }

    protected override double GetFuelAmountByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return distance * distance;
    }
}