using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class RamValidator : IComponentValidator<Ram>
{
    public void Validate(Ram validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();
        var doubleValidator = new PositiveNumberValidator<double>();

        stringValidator.Validate(validatable.Name, "RAM name");
        intValidator.Validate(validatable.MemorySize, "RAM memory size");
        intValidator.Validate(validatable.DdrStandard, "RAM DDR standard size");
        doubleValidator.Validate(validatable.PowerConsumption, "RAM power consumption");
    }
}