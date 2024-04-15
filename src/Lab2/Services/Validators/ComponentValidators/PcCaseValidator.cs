using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class PcCaseValidator : IComponentValidator<PcCase>
{
    public void Validate(PcCase validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();

        stringValidator.Validate(validatable.Name, "PC Case name");
        intValidator.Validate(validatable.Length, "PC Case length");
        intValidator.Validate(validatable.Width, "PC Case width");
        intValidator.Validate(validatable.Height, "PC Case height");
        validatable.CompatibleMotherboardFormFactors.ToList().ForEach(
            formFactor => stringValidator.Validate(formFactor, "PC Case compatible motherboard form factor"));
        intValidator.Validate(validatable.GraphicsCardMaxLength, "PC Case graphics card maximal length");
    }
}