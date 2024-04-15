using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;

public class SpaceshipRepository
{
    private List<Spaceship> _spaceships;

    public SpaceshipRepository()
    {
        _spaceships = new List<Spaceship>
        {
            new Spaceship(
                "WalkShuttle",
                HullCreator.HullClass1,
                null,
                EngineCreator.ImpulseEngineC,
                null),

            new Spaceship(
                "Vaclas",
                HullCreator.HullClass2,
                DeflectorCreator.DeflectorClass1,
                EngineCreator.ImpulseEngineE,
                EngineCreator.JumpEngineGamma),

            new Spaceship(
                "Meridian",
                HullCreator.HullClass2,
                DeflectorCreator.DeflectorClass2,
                EngineCreator.ImpulseEngineE,
                null,
                new AntiNitrineEmitter(1),
                null),

            new Spaceship(
                "Stella",
                HullCreator.HullClass1,
                DeflectorCreator.DeflectorClass1,
                EngineCreator.ImpulseEngineC,
                EngineCreator.JumpEngineOmega),

            new Spaceship(
                "Augur",
                HullCreator.HullClass3,
                DeflectorCreator.DeflectorClass3,
                EngineCreator.ImpulseEngineE,
                EngineCreator.JumpEngineAlpha),
        };
    }

    public Spaceship GetByName(string name)
    {
        Spaceship result = _spaceships.FirstOrDefault(spaceship => spaceship.Name == name) ?? throw new NoSpaceshipFindException();

        return result;
    }
}