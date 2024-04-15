using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : IName
{
    public PowerSupply(string name, int wattage)
    {
        Name = name;
        Wattage = wattage;

        new NonEmptyStringValidator().Validate(name, "PSU name");
        new PositiveNumberValidator<int>().Validate(wattage, "PSU wattage");
    }

    public string Name { get; }
    public int Wattage { get; }
}