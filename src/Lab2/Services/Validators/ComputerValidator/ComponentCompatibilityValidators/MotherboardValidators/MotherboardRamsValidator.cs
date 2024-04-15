using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.MotherboardValidators;

public class MotherboardRamsValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        Motherboard motherboard = computer.Motherboard;
        IReadOnlyList<Ram> rams = computer.Rams;

        if (rams.Count > motherboard.RamCount)
        {
            throw new ComponentsIncompatibilityException(
                $"Motherboard supports {motherboard.RamCount} RAM modules, but given {rams.Count}.");
        }

        foreach (Ram ram in rams)
        {
            if (ram.FormFactor != motherboard.RamFormFactor)
            {
                throw new ComponentsIncompatibilityException(
                    $"Motherboard supports only {motherboard.RamFormFactor} RAM form factor, " +
                    $"but given module with {ram.FormFactor}.");
            }

            if (ram.DdrStandard != motherboard.DdrStandard)
            {
                throw new ComponentsIncompatibilityException(
                    $"Motherboard supports DDR standard {motherboard.DdrStandard}, " +
                    $"but given module with {ram.DdrStandard}.");
            }

            if (!motherboard.RamOperatingFrequencies.Contains(ram.Jedec.Frequency))
            {
                throw new ComponentsIncompatibilityException(
                    $"Motherboard does not support frequency for RAM {ram.Name}.");
            }
        }

        return new CompatibilityResult(CompatibilityStatus.Compatible);
    }
}