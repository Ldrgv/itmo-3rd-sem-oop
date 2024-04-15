using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public interface IPassable : IAttacking
{
    public Result PassDistance(Spaceship spaceship);
}