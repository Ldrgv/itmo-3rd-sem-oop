using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineBase : IEngine
{
    protected EngineBase(FuelType fuelType, double fuelAmount)
    {
        Guard.ArgumentIsPositive(fuelAmount, "Fuel amount");

        FuelType = fuelType;
        FuelAmount = fuelAmount;
    }

    public FuelType FuelType { get; }
    public double FuelAmount { get; private set; }

    public abstract double GetTimeByDistance(double distance);

    public Result BurnFuelByDistance(double distance)
    {
        Guard.ArgumentIsPositive(distance, "Distance");

        double fuelAmount = GetFuelAmountByDistance(distance);
        if (fuelAmount > FuelAmount)
        {
            return new Result(Status.NoEnoughFuel);
        }

        FuelAmount -= fuelAmount;

        return new FuelSuccessResult(FuelType, fuelAmount);
    }

    protected abstract double GetFuelAmountByDistance(double distance);
}