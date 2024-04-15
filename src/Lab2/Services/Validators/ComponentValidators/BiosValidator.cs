using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class BiosValidator : IComponentValidator<Bios>
{
    public void Validate(Bios validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();

        stringValidator.Validate(validatable.Type, "Bios type");
        stringValidator.Validate(validatable.Version, "Bios version");
        validatable.CompatibleCpuNames.ToList().ForEach(
            cpuName => stringValidator.Validate(cpuName, "Compatible CPU name in Bios"));
    }
}