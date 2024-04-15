using System.Numerics;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

public class PositiveNumberValidator<T> : IPrimitiveValidator<T>
    where T : INumber<T>
{
    public void Validate(T validatable, string name)
    {
        if (T.Sign(validatable) <= 0)
            throw new ComponentValidatorException($"{name} should be positive!");
    }
}