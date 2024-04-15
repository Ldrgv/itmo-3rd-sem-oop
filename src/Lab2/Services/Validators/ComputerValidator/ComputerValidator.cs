using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.CoolerValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.MotherboardValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PcCaseValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PowerSupplyValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator;

public class ComputerValidator : IComputerValidator
{
    private readonly List<IComponentsCompatibilityValidator> _validators;

    public ComputerValidator()
    {
        _validators = new List<IComponentsCompatibilityValidator>
        {
            new MotherboardCpuValidator(),
            new MotherboardRamsValidator(),
            new MotherboardGraphicsCardValidator(),
            new CoolerCpuValidator(),
            new PcCaseMotherboardValidator(),
            new PcCaseCoolerValidator(),
            new PcCaseGraphicsCardValidator(),
            new PowerSupplyPowerablesValidator(),
        };
    }

    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        var compatibilityResultBuilder = new CompatibilityResultBuilder();
        foreach (IComponentsCompatibilityValidator validator in _validators)
        {
            compatibilityResultBuilder.WithResult(validator.Validate(computer));
        }

        return compatibilityResultBuilder.Build();
    }
}