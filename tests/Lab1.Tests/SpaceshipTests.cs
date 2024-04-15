using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;
using Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceshipTests
{
    private readonly SpaceshipRepository _spaceships;
    private readonly Dictionary<string, EnvironmentBase> _environments;

    public SpaceshipTests()
    {
        _spaceships = new SpaceshipRepository();
        _environments = new Dictionary<string, EnvironmentBase>
        {
            { "DefaultSpace", new DefaultSpace() },
            { "IncreasedDensityNebula", new IncreasedDensityNebula() },
            { "NitrineParticleNebula", new NitrineParticleNebula() },
        };
    }

    [Theory]
    [InlineData("WalkShuttle", 10000, Status.NoRequiredEngine)]
    [InlineData("Augur", 10000, Status.ShipLost)]
    public void MidWayIncreasedDensityNebula(string shipName, int distance, Status expectedStatus)
    {
        Spaceship ship = _spaceships.GetByName(shipName);

        var route = new Route(
            new[] { new Segment(distance, new IncreasedDensityNebula()) });

        Assert.Equal(expectedStatus, ship.Fly(route).Status);
    }

    [Theory]
    [InlineData(0, Status.CrewDied)]
    [InlineData(1, Status.Success)]
    public void AntimatterFlareSubspaceChannel(int photonDeflectorCharge, Status expectedStatus)
    {
        Spaceship vaclas = _spaceships.GetByName("Vaclas");

        Assert.NotNull(vaclas.Deflector);
        Assert.NotNull(vaclas.JumpEngine);

        vaclas.SetPhotonDeflector(new Deflector(photonDeflectorCharge));

        var environment = new IncreasedDensityNebula();
        environment.AddObstacle(new AntimatterFlare());

        const int distance = 1;

        var route = new Route(
            new[] { new Segment(distance, environment) });

        Result result = vaclas.Fly(route);

        Assert.Equal(expectedStatus, result.Status);
    }

    [Theory]
    [InlineData("Vaclas", 50, 0, Status.ShipDestroyed)]
    [InlineData("Augur", 100, 0, Status.Success)]
    [InlineData("Meridian", 50, 50, Status.Success)]
    public void CosmoWhaleNitrineParticleNebula(
        string shipName, int deflectorHpBefore, int deflectorHpAfter, Status expectedStatus)
    {
        Spaceship ship = _spaceships.GetByName(shipName);

        Assert.NotNull(ship.Deflector);
        ship.SetNewDeflector(new Deflector(deflectorHpBefore));

        int distance = 1;
        EnvironmentBase environment = new NitrineParticleNebula();
        var cosmoWhale = new CosmoWhale(100);

        environment.AddObstacle(cosmoWhale);

        var route = new Route(new[] { new Segment(distance, environment) });

        Assert.Equal(expectedStatus, ship.Fly(route).Status);
        Assert.Equal(deflectorHpAfter, ship.Deflector.HitPoints);
    }

    [Theory]
    [InlineData(
        "WalkShuttle",
        "Vaclas",
        10,
        "DefaultSpace",
        "WalkShuttle")]
    [InlineData(
        "Augur",
        "Stella",
        20,
        "IncreasedDensityNebula",
        "Stella")]
    [InlineData(
        "WalkShuttle",
        "Vaclas",
        10,
        "NitrineParticleNebula",
        "Vaclas")]
    public void SpaceshipElector(
        string shipName1,
        string shipName2,
        int distance,
        string environmentType,
        string expectedShipName)
    {
        Spaceship ship1 = _spaceships.GetByName(shipName1);
        Spaceship ship2 = _spaceships.GetByName(shipName2);
        EnvironmentBase environment = _environments[environmentType];

        Spaceship? result = Services.SpaceshipElector.FindBestShip(
            new[] { ship1, ship2 }, new Segment(distance, environment));

        Assert.Equal(expectedShipName, result?.Name);
    }

    [Fact]
    public void SimpleDamage()
    {
        Spaceship spaceship = _spaceships.GetByName("Vaclas");
        const int hitPoints = 100;
        spaceship.SetNewDeflector(new Deflector(hitPoints));

        EnvironmentBase environment = _environments["DefaultSpace"];
        const int obstacleDamage = 10;
        environment.AddObstacle(new Asteroid(obstacleDamage));

        const int distance = 1;

        spaceship.Fly(new Segment(distance, environment));

        Assert.NotNull(spaceship.Deflector);
        Assert.Equal(hitPoints - obstacleDamage, spaceship.Deflector.HitPoints);
    }
}