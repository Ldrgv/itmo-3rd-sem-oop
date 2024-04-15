using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class ImpulseEngineBase : EngineBase
{
    protected const int DistancePerFuel = 10;

    protected ImpulseEngineBase(FuelType fuelType, int onStartFuelAmount, double fuelAmount, double fuelConsumption)
        : base(fuelType, fuelAmount)
    {
        Guard.ArgumentIsPositive(onStartFuelAmount, nameof(onStartFuelAmount));
        Guard.ArgumentIsPositive(fuelAmount, nameof(fuelAmount));
        Guard.ArgumentIsPositive(fuelConsumption, nameof(fuelConsumption));

        FuelConsumption = fuelConsumption;
        OnStartFuelAmount = onStartFuelAmount;
    }

    protected double FuelConsumption { get; }
    protected double OnStartFuelAmount { get; }
}