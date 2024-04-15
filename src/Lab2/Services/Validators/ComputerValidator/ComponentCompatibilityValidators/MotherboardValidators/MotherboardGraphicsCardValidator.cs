using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.MotherboardValidators;

public class MotherboardGraphicsCardValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        Motherboard motherboard = computer.Motherboard;
        GraphicsCard? graphicsCard = computer.GraphicsCard;

        if (graphicsCard == null || motherboard.PcieVersion == graphicsCard.PcieVersion)
        {
            return new CompatibilityResult(CompatibilityStatus.Compatible);
        }

        throw new ComponentsIncompatibilityException(
            $"Motherboard PCI-E version is {motherboard.PcieVersion}, " +
            $"but Graphics card is {graphicsCard.PcieVersion}, so it will work slower, than could.");
    }
}