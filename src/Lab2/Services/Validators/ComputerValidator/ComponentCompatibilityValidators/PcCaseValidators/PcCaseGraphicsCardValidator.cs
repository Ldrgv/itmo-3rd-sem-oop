using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.PcCaseValidators;

public class PcCaseGraphicsCardValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        PcCase pcCase = computer.PcCase;
        GraphicsCard? graphicsCard = computer.GraphicsCard;

        if (graphicsCard == null) return new CompatibilityResult(CompatibilityStatus.Compatible);

        if (graphicsCard.Length <= pcCase.GraphicsCardMaxLength)
        {
            return new CompatibilityResult(CompatibilityStatus.Compatible);
        }

        throw new ComponentsIncompatibilityException(
            $"PC Case maximal length for graphics card id {pcCase.GraphicsCardMaxLength} " +
            $"but given graphic card with length {graphicsCard.Length}.");
    }
}