using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class HddValidator : IComponentValidator<Hdd>
{
    public void Validate(Hdd validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();
        var doubleValidator = new PositiveNumberValidator<double>();

        stringValidator.Validate(validatable.Name, "HDD name");
        intValidator.Validate(validatable.MemorySize, "HDD memory size");
        intValidator.Validate(validatable.Rpm, "HDD RPM");
        doubleValidator.Validate(validatable.PowerConsumption, "HDD Power Consumption");
    }
}