using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public class MotherboardValidator : IComponentValidator<Motherboard>
{
    public void Validate(Motherboard validatable)
    {
        if (validatable == null) throw new ArgumentNullException(nameof(validatable));

        var stringValidator = new NonEmptyStringValidator();
        var intValidator = new PositiveNumberValidator<int>();

        stringValidator.Validate(validatable.Name, "Motherboard name");
        stringValidator.Validate(validatable.FormFactor, "Motherboard form factor");
        stringValidator.Validate(validatable.CpuSocket, "Motherboard CPU socket");
        intValidator.Validate(validatable.DdrStandard, "Motherboard DDR standard");
        intValidator.Validate(validatable.RamCount, "Motherboard RAM count");
        intValidator.Validate(validatable.MaxRamSize, "Motherboard maximal RAM size");
        validatable.RamOperatingFrequencies.ToList().ForEach(
            frequency => intValidator.Validate(frequency, "Motherboard RAM operating frequency"));
        stringValidator.Validate(validatable.PcieVersion, "Motherboard PCI-E version");
        intValidator.Validate(validatable.PcieCount, "Motherboard PCI-E count");
        intValidator.Validate(validatable.SataCount, "Motherboard SATA count");
    }
}