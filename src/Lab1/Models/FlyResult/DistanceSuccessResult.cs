using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

public class DistanceSuccessResult : Result
{
    public DistanceSuccessResult(double time, Fuel fuel)
        : base(Status.Success)
    {
        Guard.ArgumentIsPositive(time, nameof(time));

        TravelTime = time;
        FuelConsumptions = new List<Fuel> { fuel };
    }

    public DistanceSuccessResult(double time, IEnumerable<Fuel> fuelConsumptions)
        : base(Status.Success)
    {
        Guard.ArgumentIsPositive(time, nameof(time));

        TravelTime = time;
        FuelConsumptions = fuelConsumptions.ToList();
    }

    public double TravelTime { get; }
    public IReadOnlyList<Fuel> FuelConsumptions { get; }

    public double FuelCost => FuelConsumptions.Sum(new FuelExchangeService().GetPrice);
}