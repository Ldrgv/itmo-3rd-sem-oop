using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

public class FuelSuccessResult : Result
{
    public FuelSuccessResult(FuelType fuelType, double fuelAmount)
        : base(Status.Success)
    {
        Guard.ArgumentIsPositive(fuelAmount, nameof(fuelAmount));

        Fuel = new Fuel(fuelType, fuelAmount);
    }

    public Fuel Fuel { get; }
}