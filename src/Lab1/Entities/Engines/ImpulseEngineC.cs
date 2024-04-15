using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineC : ImpulseEngineBase
{
    private readonly int _speed;

    public ImpulseEngineC(
        FuelType fuelType,
        int onStartFuelAmount,
        double fuelAmount,
        double fuelConsumption,
        int speed)
        : base(fuelType, onStartFuelAmount, fuelAmount, fuelConsumption)
    {
        _speed = speed;
    }

    public override double GetTimeByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return distance / _speed;
    }

    protected override double GetFuelAmountByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, nameof(distance));

        return OnStartFuelAmount + (distance / DistancePerFuel * FuelConsumption);
    }
}