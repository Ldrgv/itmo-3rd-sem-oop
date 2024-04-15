namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators.PrimitiveValidators;

public interface IPrimitiveValidator<in T>
{
    public void Validate(T validatable, string name);
}