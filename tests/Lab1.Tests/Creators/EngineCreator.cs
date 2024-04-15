using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Creators;

public static class EngineCreator
{
    private const int StartFuelAmount = 100;

    public static ImpulseEngineC ImpulseEngineC => new ImpulseEngineC(
        FuelType.ActivePlasma, 5, StartFuelAmount, 2, 5);

    public static ImpulseEngineE ImpulseEngineE => new ImpulseEngineE(
        FuelType.ActivePlasma, 10, StartFuelAmount, 5);

    public static JumpEngineAlpha JumpEngineAlpha => new JumpEngineAlpha(
        StartFuelAmount, 20, 10);

    public static JumpEngineOmega JumpEngineOmega => new JumpEngineOmega(
        StartFuelAmount, 35, 15);

    public static JumpEngineGamma JumpEngineGamma => new JumpEngineGamma(
        StartFuelAmount, 50, 20);
}