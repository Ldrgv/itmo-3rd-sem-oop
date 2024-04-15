using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class GraphicsCardValidator : IComponentValidator<GraphicsCard>
{
    public void Validate(GraphicsCard validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();
        var doubleValidator = new PositiveNumberValidator<double>();

        stringValidator.Validate(validatable.Name, "Graphics card name");
        intValidator.Validate(validatable.MemorySize, "Graphics card memory size");
        intValidator.Validate(validatable.ClockSpeed, "Graphics card clock speed");
        stringValidator.Validate(validatable.PcieVersion, "Graphics card PCI-E version");
        doubleValidator.Validate(validatable.PowerConsumption, "Graphics card power consumption");
        intValidator.Validate(validatable.Length, "Graphics card memory length");
        intValidator.Validate(validatable.Height, "Graphics card memory height");
    }
}