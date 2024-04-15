using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Fuel
{
    public Fuel(FuelType type, double amount)
    {
        Guard.ArgumentIsPositive(amount, nameof(amount));

        Type = type;
        Amount = amount;
    }

    public FuelType Type { get; }
    public double Amount { get; }
}