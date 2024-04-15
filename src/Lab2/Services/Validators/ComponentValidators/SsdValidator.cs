using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class SsdValidator : IComponentValidator<Ssd>
{
    public void Validate(Ssd validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();
        var doubleValidator = new PositiveNumberValidator<double>();

        stringValidator.Validate(validatable.Name, "SSD name");
        intValidator.Validate(validatable.MemorySize, "SSD memory size");
        intValidator.Validate(validatable.Speed, "SSD speed");
        doubleValidator.Validate(validatable.PowerConsumption, "SSD power consumption");
    }
}