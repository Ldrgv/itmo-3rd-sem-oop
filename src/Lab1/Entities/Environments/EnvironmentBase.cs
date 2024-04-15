using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Exceptions.EnvironmentExceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class EnvironmentBase
{
    private List<ObstacleBase> _obstacles;

    protected EnvironmentBase()
    {
        _obstacles = new List<ObstacleBase>();
    }

    protected EnvironmentBase(IEnumerable<ObstacleBase> obstacles)
    {
        if (obstacles == null) throw new ArgumentNullException(nameof(obstacles));

        _obstacles = new List<ObstacleBase>();

        foreach (ObstacleBase obstacle in obstacles)
        {
            AddObstacle(obstacle);
        }
    }

    public IReadOnlyList<ObstacleBase> Obstacles => _obstacles.AsReadOnly();

    public void AddObstacle(ObstacleBase obstacle)
    {
        if (obstacle == null) throw new ArgumentNullException(nameof(obstacle));

        if (!IsMatchObstacle(obstacle))
            throw new EnvironmentObstacleMatchException($"Can not add {nameof(obstacle)} in preferred environment.");

        _obstacles.Add(obstacle);
    }

    public abstract Result PassDistance(int distance, Spaceship spaceship);

    public abstract bool IsMatchObstacle(ObstacleBase obstacle);

    public abstract SpaceshipOption GetBestSpaceship(SpaceshipOption? bestOption, SpaceshipOption anotherOption);
}