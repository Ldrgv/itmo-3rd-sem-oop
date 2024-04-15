using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineE : ImpulseEngineBase
{
    private const double LeftBorder = 0;
    private const double RightBorder = int.MaxValue;

    public ImpulseEngineE(FuelType fuelType, int onStartFuelAmount, double fuelAmount, double fuelConsumption)
        : base(fuelType, onStartFuelAmount, fuelAmount, fuelConsumption)
    {
    }

    public override double GetTimeByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        double leftBorder = LeftBorder;
        double rightBorder = RightBorder;

        const double accuracyEpsilon = 1e-6;

        while (rightBorder - leftBorder < accuracyEpsilon)
        {
            double time = (leftBorder + rightBorder) / 2;
            if (DistanceByTime(time) < distance)
            {
                leftBorder = time;
            }
            else
            {
                rightBorder = time;
            }
        }

        return rightBorder;
    }

    protected override double GetFuelAmountByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return OnStartFuelAmount + (distance / DistancePerFuel * FuelConsumption);
    }

    private static double DistanceByTime(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return Math.Exp(distance);
    }
}