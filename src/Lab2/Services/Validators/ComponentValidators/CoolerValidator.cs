using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class CoolerValidator : IComponentValidator<Cooler>
{
    public void Validate(Cooler validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();

        stringValidator.Validate(validatable.Name, "Cooler name");
        intValidator.Validate(validatable.Width, "Cooler width");
        intValidator.Validate(validatable.Height, "Cooler height");
        intValidator.Validate(validatable.Lenght, "Cooler length");
        intValidator.Validate(validatable.Tdp, "Cooler tdp");
        validatable.CompatibleSockets.ToList().ForEach(
            cpuName => stringValidator.Validate(cpuName, "Compatible CPU name in Cooler"));
    }
}