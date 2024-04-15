using System;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngineOmega : JumpEngineBase
{
    public JumpEngineOmega(double fuelAmount, int maxDistance, double speed)
        : base(fuelAmount, maxDistance, speed)
    {
    }

    protected override double GetFuelAmountByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return distance * Math.Log(distance);
    }
}