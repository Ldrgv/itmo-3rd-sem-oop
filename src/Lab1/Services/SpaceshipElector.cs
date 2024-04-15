using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class SpaceshipElector
{
    public static Spaceship? FindBestShip(IEnumerable<Spaceship> ships, Segment route)
    {
        if (ships == null) throw new ArgumentNullException(nameof(ships));
        if (route == null) throw new ArgumentNullException(nameof(route));

        SpaceshipOption? bestShip = null;

        foreach (Spaceship ship in ships)
        {
            Result routeResult = ship.Fly(route);

            if (routeResult is not DistanceSuccessResult result) continue;

            bestShip = route.Environment.GetBestSpaceship(
                bestShip, new SpaceshipOption(ship, result.FuelCost));
        }

        return bestShip?.Spaceship;
    }
}
