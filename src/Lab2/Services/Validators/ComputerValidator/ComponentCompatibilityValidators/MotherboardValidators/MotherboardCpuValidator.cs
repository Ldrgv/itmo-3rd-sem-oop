using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator.ComponentCompatibilityValidators.MotherboardValidators;

public class MotherboardCpuValidator : IComponentsCompatibilityValidator
{
    public CompatibilityResult Validate(Computer computer)
    {
        if (computer == null) throw new ArgumentNullException(nameof(computer));

        Motherboard motherboard = computer.Motherboard;
        Cpu cpu = computer.Cpu;
        Bios bios = computer.Motherboard.Bios;

        if (cpu.Socket != motherboard.CpuSocket)
        {
            throw new ComponentsIncompatibilityException(
                $"Motherboard CPU socket is {motherboard.CpuSocket}, but given CPU with socket {cpu.Socket}.");
        }

        if (bios.CompatibleCpuNames.Contains(cpu.Name.ToUpperInvariant()))
        {
            return new CompatibilityResult(CompatibilityStatus.Compatible);
        }

        throw new ComponentsIncompatibilityException(
                $"Bios {bios.Type} {bios.Version} does not support CPU {cpu.Name}.\n" +
                $"Compatible CPUs: {bios.CompatibleCpuNames}.");
    }
}