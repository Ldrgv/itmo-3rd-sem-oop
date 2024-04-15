using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.CoolerValidators;

public class CoolerCpuValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        Cooler cooler = computer.Cooler;
        Cpu cpu = computer.Cpu;

        if (!cooler.CompatibleSockets.Contains(cpu.Socket))
        {
            throw new ComponentsIncompatibilityException(
                $"Cooler does not support given CPU's socket {cpu.Socket}.");
        }

        if (cooler.Tdp < cpu.Tdp)
        {
            return new CompatibilityResult(
                CompatibilityStatus.NoWarranty,
                $"Cooler's TDP={cooler.Tdp} is weaker than CPU's TDP={cpu.Tdp}.");
        }

        return new CompatibilityResult(CompatibilityStatus.Compatible);
    }
}