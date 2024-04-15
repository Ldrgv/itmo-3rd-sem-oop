using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

public class Info
{
    private List<Fuel> _fuelConsumptions;

    public Info()
    {
        _fuelConsumptions = new List<Fuel>();
    }

    public Info(double travelTime, IEnumerable<Fuel> fuelConsumptions)
    {
        Guard.ArgumentIsPositive(travelTime, nameof(travelTime));

        TravelTime = travelTime;
        _fuelConsumptions = fuelConsumptions.ToList();
        FuelCost = _fuelConsumptions.Sum(new FuelExchangeService().GetPrice);
    }

    public double TravelTime { get; }
    public double FuelCost { get; }
    public IReadOnlyList<Fuel> FuelConsumptions => _fuelConsumptions;
}