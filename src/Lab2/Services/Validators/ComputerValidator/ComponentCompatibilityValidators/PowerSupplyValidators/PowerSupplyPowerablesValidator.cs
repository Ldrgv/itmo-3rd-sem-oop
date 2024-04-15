using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PowerSupplyValidators;

public class PowerSupplyPowerablesValidator : IComponentsCompatibilityValidator
{
    private const double MaxPermittedExcess = 100;

    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        PowerSupply powerSupply = computer.PowerSupply;
        double requiredWattage = computer.PowerConsumtion;

        if (requiredWattage < powerSupply.Wattage)
        {
            return new CompatibilityResult(CompatibilityStatus.Compatible);
        }

        if (requiredWattage <= powerSupply.Wattage + MaxPermittedExcess)
        {
            return new CompatibilityResult(
                CompatibilityStatus.HasIssue,
                $"Required wattage for system is {requiredWattage}W but given PSU with {powerSupply.Wattage}W.");
        }

        throw new ComponentsIncompatibilityException(
            $"Insufficient wattage of given PSU {powerSupply.Wattage}W. Require {requiredWattage}W.");
    }
}