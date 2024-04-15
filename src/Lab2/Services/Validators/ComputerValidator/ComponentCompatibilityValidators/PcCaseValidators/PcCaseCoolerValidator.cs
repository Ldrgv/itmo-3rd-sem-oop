using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PcCaseValidators;

public class PcCaseCoolerValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        PcCase pcCase = computer.PcCase;
        Cooler cooler = computer.Cooler;

        if (cooler.Height <= pcCase.Width) return new CompatibilityResult(CompatibilityStatus.Compatible);

        throw new ComponentsIncompatibilityException(
            $"Cooler's height = {cooler.Height} is too big for given PC Case.");
    }
}