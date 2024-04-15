using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IEngine
{
    public FuelType FuelType { get; }
    public double FuelAmount { get; }

    public double GetTimeByDistance(double distance);
    public Result BurnFuelByDistance(double distance);
}