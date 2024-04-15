using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PcCaseValidators;

public class PcCaseMotherboardValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        PcCase pcCase = computer.PcCase;
        Motherboard motherboard = computer.Motherboard;

        if (pcCase.CompatibleMotherboardFormFactors.Contains(motherboard.FormFactor))
        {
            return new CompatibilityResult(CompatibilityStatus.Compatible);
        }

        throw new ComponentsIncompatibilityException(
            $"Case does not support given motherboard form factor {motherboard.FormFactor}.");
    }
}