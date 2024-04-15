using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions.ValidatorExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

public class NonEmptyStringValidator : IPrimitiveValidator<string>
{
    public void Validate(string validatable, string name)
    {
        if (!validatable.Any())
            throw new ComponentValidatorException($"{name} is empty!");
    }
}