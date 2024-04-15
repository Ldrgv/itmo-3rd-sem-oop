namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComponentValidators;

public interface IComponentValidator<in T>
{
    public void Validate(T validatable);
}