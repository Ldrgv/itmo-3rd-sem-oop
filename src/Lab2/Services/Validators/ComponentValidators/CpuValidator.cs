using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class CpuValidator : IComponentValidator<Cpu>
{
    public void Validate(Cpu validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var intValidator = new PositiveNumberValidator<int>();
        var doubleValidator = new PositiveNumberValidator<double>();

        intValidator.Validate(validatable.CoreCount, "CPU core count");
        doubleValidator.Validate(validatable.ClockSpeed, "CPU clock speed");
        intValidator.Validate(validatable.MaxRamSpeed, "CPU maximal RAM speed");
        intValidator.Validate(validatable.Tdp, "CPU TDP");
        doubleValidator.Validate(validatable.PowerConsumption, "CPU power consumption");
    }
}