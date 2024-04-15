using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Models.FlyResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Spaceship
{
    public Spaceship(
        string name,
        Hull hull,
        Deflector? deflector,
        ImpulseEngineBase? impulseEngine,
        JumpEngineBase? jumpEngine,
        AntiNitrineEmitter? antiNitrineEmitter = null,
        Deflector? photonDeflector = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Hull = hull ?? throw new ArgumentNullException(nameof(hull));
        Deflector = deflector;
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        AntiNitrineEmitter = antiNitrineEmitter;
        PhotonDeflector = photonDeflector;
    }

    public string Name { get; }
    public Hull Hull { get; }
    public Deflector? Deflector { get; private set; }
    public Deflector? PhotonDeflector { get; private set; }
    public ImpulseEngineBase? ImpulseEngine { get; }
    public JumpEngineBase? JumpEngine { get; }
    public AntiNitrineEmitter? AntiNitrineEmitter { get; }

    public Result Fly(Route.Route route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        Result shipDamageResult = route.MakeDamage(this);

        return shipDamageResult.Status is not Status.Success
            ? shipDamageResult
            : route.PassDistance(this);
    }

    public Result Fly(Segment segment)
    {
        return Fly(new Route.Route(new List<Segment> { segment }));
    }

    public void SetPhotonDeflector(Deflector photonDeflector)
    {
        PhotonDeflector = photonDeflector ?? throw new ArgumentNullException(nameof(photonDeflector));
    }

    public void SetNewDeflector(Deflector deflector)
    {
        Deflector = deflector ?? throw new ArgumentNullException(nameof(deflector));
    }
}